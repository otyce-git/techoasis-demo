using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Resumes.Api.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response, int currentPage,
            int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage,itemsPerPage,
                totalItems, totalPages);

            var fomatter = new JsonSerializerSettings();
            fomatter.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, fomatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}