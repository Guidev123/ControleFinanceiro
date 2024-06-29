using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Responses
{
    public class Service<TData>
    {
        private const int DEFAULT_STATUS_CODE = 200;
        private readonly int _code;

        [JsonConstructor]
        public Service() => _code = DEFAULT_STATUS_CODE;

        public Service(TData? data, int code = DEFAULT_STATUS_CODE, string? message = null)
        {
            Data = data;
            Message = message;
            _code = code;
        }
        public TData? Data { get; set; }
        public string? Message { get; set; } = string.Empty;

        [JsonIgnore] // EVITAR QUE O STATUS CODE SEJA EXIBIDO
        public bool IsSuccess => _code is >= 200 and <= 299;
    }
}
