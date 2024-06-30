using ControleFinanceiro.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Services
{
    public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(TData? data, int code = 200, string? message = null) : base(data, code, message)
        {
            
        }

        public PagedResponse(TData? data, int totalCount, int currentPage, int pageSize)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage = 1;
            PageSize = pageSize = 25;
        }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int PageSize { get; set; } = 25;
        public int TotalCount { get; set; }
    }
}
