using System;
using Final_project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<VideoInfo> VideoInfos { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<RentalCondition> RentalConditions { get; set; }
        public DbSet<ServiceCondition> ServiceConditions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceDetail> ServiceDetails { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<ComplaintSuggest> ComplaintSuggests { get; set; }
    }
}

