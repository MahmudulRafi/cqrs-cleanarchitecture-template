namespace Domain.Models.Responses
{
    public class PaginatedResponse<T>
    {
        public T? Data { get; set; }
        public int TotalCount { get; set; }

        public PaginatedResponse(T data, int totalCount)
        {
            Data = data;
            TotalCount = totalCount;
        }
    }
}
