using Final_project.Helpers;
using Final_project.Models;
using Final_project.ViewModels.Cars;

namespace Final_project.ViewModels
{
	public class HomeVM
	{
        public List<Process> Proccesses { get; set; }
        public List<VideoInfo> VideoInfos { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
        public List<Video> Videos { get; set; }
        public List<Models.About> Abouts { get; set; }
        public List<Service> Services { get; set; }
        public List<Car> Cars { get; set; }
        public Car Car { get; set; }
        public List<Team> Teams { get; set; }
        public Paginate<CarVM> PaginateCar { get; set; }
        public RentalCondition Conditions { get; set; }
        public ServiceDetail ServiceDetails { get; set; }
        public Models.ServiceCondition ServiceConditions { get; set; }
        public Service Service { get; set; }
        public Dictionary<string, string> Settings { get; set; }
        public List<CarVM> CarVM { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
    }
}

