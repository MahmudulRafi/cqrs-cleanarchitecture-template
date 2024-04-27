namespace Domain.Models
{
    public class PaginatedResponse<T>
    {
        public T? Data { get; set; }
        public int TotalCount { get; set; }
    }
}
