using System.Diagnostics;

namespace TestComandosCega.Models
{
    public class HsmCommandExecutor
    {
        public static async Task<string> ExecuteCommandAsync(string command, string arguments, int timeoutMilliseconds = 5000)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = arguments,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process())
                {
                    process.StartInfo = processStartInfo;
                    process.Start();

                    string outputTask = await process.StandardOutput.ReadToEndAsync();
                    string errorTask = await process.StandardError.ReadToEndAsync();

                    await process.WaitForExitAsync();

                    if (process.ExitCode != 0)
                    {
                        throw new Exception($"Error ejecutando comando: {errorTask}");
                    }

                    return outputTask.ToString();
                }
            }
			catch (Exception ex)
			{
                return $"Error: {ex.Message}";
            }
        }   
    }
}
