using Microsoft.AspNetCore.Mvc;
using TestComandosCega.Models;

namespace TestComandosCega.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HsmController : Controller
    {
        [HttpGet("info")]
        public IActionResult GetHsmInfo()
        {
            string command = "cxitool"; // Cambia esto por el comando adecuado
            string arguments = "Dev=3001@127.0.0.1 LogonPass=usuario1,123456 Name=Key2 Group=usuario1 DeleteKey"; // Cambia esto por los argumentos que necesites

            Console.WriteLine("Ejecutando comando");
            HsmCommandExecutor hsmCommandExecutor = new HsmCommandExecutor();
            string result = HsmCommandExecutor.ExecuteCommandAsync(command, arguments).Result;
            Console.WriteLine(result);

            if (result.StartsWith("Error:"))
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
