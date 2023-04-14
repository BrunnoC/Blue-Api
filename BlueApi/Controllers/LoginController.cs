using BlueApi.Dtos.Login;
using BlueApi.Dtos.ResponseGenerico;
using BlueApi.Services.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection.Metadata.Ecma335;

namespace BlueApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ResponseGenerico<LoginOutputDTO>>> Login([FromServices]ILoginService service, [FromBody]LoginInputDTO login)
        {
            ResponseGenerico<LoginOutputDTO> retorno = await service.Login(login);
            return Ok(retorno);
        }
    }
}
