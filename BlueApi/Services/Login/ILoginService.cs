using BlueApi.Dtos.Login;
using BlueApi.Dtos.ResponseGenerico;

namespace BlueApi.Services.Login
{
    public interface ILoginService
    {
        Task<ResponseGenerico<LoginOutputDTO>> Login(LoginInputDTO loginInputDTO);
    }
}
