﻿namespace Domain.Repositories.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
    }
}