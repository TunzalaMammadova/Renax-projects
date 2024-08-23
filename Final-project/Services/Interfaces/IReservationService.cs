using System;
using Final_project.Data;
using Final_project.Models;

namespace Final_project.Services.Interfaces
{
	public interface IReservationService
	{
        Task Create(Reservation rez);
        Task<List<Reservation>> GetAll();
        Task<Reservation> GetById(int id);
        Task Edit(int id, Reservation rez);
    }
}

