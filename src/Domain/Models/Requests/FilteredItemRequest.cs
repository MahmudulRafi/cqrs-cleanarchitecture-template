using System.Linq.Expressions;

namespace Domain.Models.Requests
{
    public record FilteredItemRequest<T>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public Expression<Func<T, bool>>? Filter { get; set; } = null;
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; set; } = null;
        public IEnumerable<Expression<Func<T, object>>>? Includes { get; set; } = null;
    }
}
