﻿using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Common;

namespace Application.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<List<Event>> GetEventsAsync()
        {
            return _unitOfWork.Events.GetAllAsync();
        }
    }
}