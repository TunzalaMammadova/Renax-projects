using System;
using Final_project.Models;

namespace Final_project.Services.Interfaces
{
    public interface IComplaintService
    {
        Task Create(ComplaintSuggest suggest);
        Task<List<ComplaintSuggest>> GetAllAsync();
        Task Delete(ComplaintSuggest suggest);
        Task<ComplaintSuggest> GetById(int id);
    }
}

