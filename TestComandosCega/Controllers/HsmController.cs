using Microsoft.AspNetCore.Mvc;
using TestComandosCega.Models;

namespace TestComandosCega.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HsmController : Controller
        
    {
        string command = "";
        string arguments = "";
        //ejecuta csadm GetState
        [HttpGet("state")]
        public IActionResult GetHsmState()
        {
            command = "csadm"; // asigna el comando csadm
            arguments = "Dev=3001@127.0.0.1 GetState"; // asigna la direccion ip del host y ejecuta GetState

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
        //ejecuta csadm GetInfo
        [HttpGet("info")]
        public IActionResult GetHsmInfo()
        {
            command = "csadm"; // asigna el comando csadm
            arguments = "Dev=3001@127.0.0.1 GetInfo"; // asigna la direccion ip del host y ejecuta GetInfo
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
