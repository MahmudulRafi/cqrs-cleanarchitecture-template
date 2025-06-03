namespace Domain.Models.Responses
{
<<<<<<< HEAD
    public record PaginatedResponse<T>(T Data, int TotalCount)
    {
        public T? Data { get; init; } = Data;
        public int TotalCount { get; init; } = TotalCount;
=======
    public class PaginatedResponse<T>
    {
        public T? Data { get; set; }
        public int TotalCount { get; set; }

        public PaginatedResponse(T data, int totalCount)
        {
            Data = data;
            TotalCount = totalCount;
        }
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
    }
}
