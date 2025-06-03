using System.Linq.Expressions;

namespace Domain.Models.Requests
{
    public record QueryableRequest<T>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public Expression<Func<T, bool>>? Filter { get; init; } = null;
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; init; } = null;
        public IEnumerable<Expression<Func<T, object>>>? Includes { get; init; } = null;
    }
}
