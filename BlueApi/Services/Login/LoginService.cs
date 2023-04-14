using BlueApi.Dtos.Login;
using BlueApi.Dtos.ResponseGenerico;
using System.Dynamic;
using System.Text.Json;

namespace BlueApi.Services.Login
{
    public class LoginService : ILoginService
    {
        public async Task<ResponseGenerico<LoginOutputDTO>> Login(LoginInputDTO loginInputDTO)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyBNLOJT9C_njeNWCoi3xPa7x6MO7qRuLSg");
            request.Content = JsonContent.Create(loginInputDTO);

            ResponseGenerico<LoginOutputDTO> response = new ResponseGenerico<LoginOutputDTO>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseFireBaseAuthentication = await client.SendAsync(request);

                response.httpStatusCode = responseFireBaseAuthentication.StatusCode;
                string responseString = await responseFireBaseAuthentication.Content.ReadAsStringAsync();
                if (responseFireBaseAuthentication.IsSuccessStatusCode)
                {
                    if (!String.IsNullOrEmpty(responseString))
                    {
                        LoginOutputDTO retorno = JsonSerializer.Deserialize<LoginOutputDTO>(responseString);
                        response.DadosRetorno = retorno;
                    }
                }
                else
                {
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(responseString);
                }
                return response;
                

            }
        }
    }
}
