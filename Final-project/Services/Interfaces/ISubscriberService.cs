using System;
using Final_project.Models;

namespace Final_project.Services.Interfaces
{
	public interface ISubscriberService
	{
        Task Create(Subscriber subscriber);
        Task Delete(Subscriber subscriber);
        Task<List<Subscriber>> GetAll();
        Task<Subscriber> GetById(int id);
    }
}

