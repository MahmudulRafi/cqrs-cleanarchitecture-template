namespace Domain.Models.Responses
{
    public record PaginatedResponse<T>(T Data, int TotalCount)
    {
        public T? Data { get; init; } = Data;
        public int TotalCount { get; init; } = TotalCount;
    }
}
