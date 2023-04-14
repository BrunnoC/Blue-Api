using System.Dynamic;
using System.Net;

namespace BlueApi.Dtos.ResponseGenerico
{
    public class ResponseGenerico<T> where T : class
    {
        public HttpStatusCode httpStatusCode { get; set; }
        public T? DadosRetorno { get; set; }
        public ExpandoObject? ErroRetorno { get; set; }
    }
}
