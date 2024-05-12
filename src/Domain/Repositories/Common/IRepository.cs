namespace Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all items of entity type(T) asynchronously
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>list of T</returns>
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
