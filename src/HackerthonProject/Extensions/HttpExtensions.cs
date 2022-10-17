using System.Text.Json;

namespace HackerthonProject.Extensions
{
    public static class HttpExtensions
    {

        public static void AddPaginationHeader(this HttpResponse response, int currentPage,
          int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new
            {
                currentPage,
                itemsPerPage,
                totalItems,
                totalPages
            };
            response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationHeader));

        }
    }
}
