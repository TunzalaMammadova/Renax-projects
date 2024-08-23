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
        public DbSet<Reservation> Reservations { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Brand>()
        //                .HasData(
        //    new Brand
        //    {
        //        Id = 1,
        //        Image = "client1.png",
        //    },

        //    new Brand
        //    {
        //        Id = 2,
        //        Image = "client2.png",
        //    },

        //    new Brand
        //    {
        //        Id = 3,
        //        Image = "client3.png",
        //    },

        //    new Brand
        //    {
        //        Id = 4,
        //        Image = "client4.png",
        //    },

        //    new Brand
        //    {
        //        Id = 5,
        //        Image = "client5.png",
        //    },

        //    new Brand
        //    {
        //        Id = 6,
        //        Image = "client6.png",
        //    },

        //    new Brand
        //    {
        //        Id = 7,
        //        Image = "client7.png",
        //    },

        //    new Brand
        //    {
        //        Id = 8,
        //        Image = "client8.png",
        //    });


        //    modelBuilder.Entity<About>()
        //                .HasData(
        //    new About
        //    {
        //        Id = 1,
        //        Title = "A Car Rental Company",
        //        SubTitle = "Rentax",
        //        Description = "Are you looking for the best rent a car Baku? Then, of course, " +
        //                      "Emirate Cars is here for you! A wide variety of dependable " +
        //                      "automobiles are available for your use. We are glad to announce " +
        //                      "that we will be providing automobile rental services in all of the " +
        //                      "Azerbaijan Republic's locations. Therefore, you will be able to compare " +
        //                      "various car rental options to locate the most suitable vehicle at the most " +
        //                      "competitive price. You can reassure us at any moment that our rates are the most " +
        //                      "lucrative and cheaper than those charged by automobile rental businesses. Rent a car " +
        //                      "Baku from Emirate Cars assures you that we will make your journey as affordable" +
        //                      " and comfortable as possible for you.",

        //        Image = "about.jpg"
        //    });


        //    modelBuilder.Entity<CarImage>()
        //                .HasData(
        //    new CarImage
        //    {
        //        Id = 8,
        //        Image = "7edead6c-44bb-4a66-899c-7f3a805303bd-DBX.jpg",
        //        IsMain = true,
        //        CarId = 8
        //    },

        //     new CarImage
        //     {
        //         Id = 9,
        //         Image = "759e0535-6f29-45da-bcb8-6fc34819c338-W16.jpg",
        //         IsMain = true,
        //         CarId = 9
        //     },

        //     new CarImage
        //     {
        //         Id = 10,
        //         Image = "f771312f-1ec2-4fb9-8074-9df25d05878d-Bentayga.jpg",
        //         IsMain = true,
        //         CarId = 10
        //     },

        //     new CarImage
        //     {
        //         Id = 11,
        //         Image = "30a198da-552e-405c-aa5d-79da5d3d01f5-Cullinan.jpg",
        //         IsMain = true,
        //         CarId = 11
        //     },

        //     new CarImage
        //     {
        //         Id = 12,
        //         Image = "849c35ad-95fb-43f1-b328-c82af5ba6c85-continental.jpg",
        //         IsMain = true,
        //         CarId = 12
        //     },

        //     new CarImage
        //     {
        //         Id = 13,
        //         Image = "719bbc9c-3b50-492c-a294-ceeda9623f12-RS7.jpg",
        //         IsMain = true,
        //         CarId = 13
        //     },

        //     new CarImage
        //     {
        //         Id = 14,
        //         Image = "137bf2b8-a78b-4287-a277-02102afcfe2e-Q8.jpg",
        //         IsMain = true,
        //         CarId = 14
        //     },

        //     new CarImage
        //     {
        //         Id = 15,
        //         Image = "27c76d10-e64b-431d-8b69-0871855ddac7-W16.jpg",
        //         IsMain = true,
        //         CarId = 15
        //     },

        //     new CarImage
        //     {
        //         Id = 1018,
        //         Image = "3bb7a964-6d4f-4fa0-a0a5-430ec3af46f0-2.jpg",
        //         IsMain = true,
        //         CarId = 7
        //     },

        //     new CarImage
        //     {
        //         Id = 4022,
        //         Image = "ae91f262-5b0f-4373-bb9f-d37ed412ca52-bental.jpg",
        //         IsMain = false,
        //         CarId = 10
        //     },

        //     new CarImage
        //     {
        //         Id = 4023,
        //         Image = "8ff31710-0dea-45eb-9ffc-8b41481b7ec7-urusss.webp",
        //         IsMain = false,
        //         CarId = 7
        //     },

        //     new CarImage
        //     {
        //         Id = 4024,
        //         Image = "68cb4657-2eb6-4728-af81-fd175490bf72-astonmar.webp",
        //         IsMain = false,
        //         CarId = 8
        //     },

        //     new CarImage
        //     {
        //         Id = 4025,
        //         Image = "f9918f65-2998-474a-817a-0e33f518e28b-ww.jpg",
        //         IsMain = false,
        //         CarId = 9
        //     },

        //     new CarImage
        //     {
        //         Id = 4026,
        //         Image = "f6455772-463a-428f-ae4e-dbb4f647e180-rr.jpg",
        //         IsMain = false,
        //         CarId = 11
        //     });



        //    modelBuilder.Entity<Car>()
        //                .HasData(
        //    new Car
        //    {
        //        Id = 7,
        //        Name = "Lamborghini Urus",
        //        Price = 750,
        //        Door = 4,
        //        Passenger = 5,
        //        Description = "The Lamborghini Urus is a luxury SUV manufactured by " +
        //                      "Italian automobile manufacturer Lamborghini.",
        //        Transmission = "Auto",
        //        Luggage = "2 Bags",
        //        AirCondition = "Yes",
        //        Age = 25,
        //        CategoryId = 4,
        //    },

        //    new Car
        //    {
        //        Id = 7,
        //        Name = "Aston Martin DBX",
        //        Price = 600,
        //        Door = 4,
        //        Passenger = 5,
        //        Description = "The DBX uses Mercedes-AMG's M177 4.0-litre twin-turbocharged " +
        //                      "V8 engine that has a power output of 55",
        //        Transmission = "Auto",
        //        Luggage = "2 Bags",
        //        AirCondition = "Yes",
        //        Age = 25,
        //        CategoryId = 3,
        //    },

        //    new Car
        //    {
        //        Id = 9,
        //        Name = "Bugatti Mistral W16",
        //        Price = 800,
        //        Door = 4,
        //        Passenger = 5,
        //        Description = "The Bugatti Mistral, also called the Bugatti W16 Mistral, is a mid-engine two-seater sports car manufactured in Molsheim, " +
        //                      "France, by French automobile manufacturer Bugatti Automobiles S.A.S. It was revealed on 19 August 2022.",
        //        Transmission = "Auto",
        //        Luggage = "2 Bags",
        //        AirCondition = "Yes",
        //        Age = 25,
        //        CategoryId = 4,
        //    },

        //    new Car
        //    {
        //        Id = 10,
        //        Name = "Bentley Bentayga",
        //        Price = 560,
        //        Door = 4,
        //        Passenger = 5,
        //        Description = "Bentley's first SUV was previewed as the Bentley EXP 9 F " +
        //                      "concept car at the 2012 Geneva Motor Show.",
        //        Transmission = "Auto",
        //        Luggage = "2 Bags",
        //        AirCondition = "Yes",
        //        Age = 25,
        //        CategoryId = 2,
        //    },

        //    new Car
        //    {
        //        Id = 11,
        //        Name = "Rolls Royce Cullinan",
        //        Price = 670,
        //        Door = 4,
        //        Passenger = 5,
        //        Description = "The Rolls-Royce Cullinan is a full-sized luxury sport utility vehicle (SUV) " +
        //                      "manufactured by Rolls-Royce Motor Cars as the brand's first all-wheel drive vehicle. " +
        //                      "It is named after the Cullinan Diamond, the largest gem-quality rough diamond ever discovered.",
        //        Transmission = "Auto",
        //        Luggage = "2 Bags",
        //        AirCondition = "Yes",
        //        Age = 25,
        //        CategoryId = 2,
        //    },

        //    new Car
        //    {
        //        Id = 12,
        //        Name = "Bentley Continental",
        //        Price = 500,
        //        Door = 4,
        //        Passenger = 5,
        //        Description = "Following the break brought about by the Second World War, Bentley resumed production " +
        //                      "of civilian automobiles, relocating its plant from Derby to Crewe. There, Bentley engineers " +
        //                      "produced R-Type Continentals for three years, from June 1952 to April 1955.",
        //        Transmission = "Auto",
        //        Luggage = "2 Bags",
        //        AirCondition = "Yes",
        //        Age = 25,
        //        CategoryId = 3,
        //    },

        //    new Car
        //    {
        //        Id = 13,
        //        Name = "Audi RS7 Sportback",
        //        Price = 800,
        //        Door = 4,
        //        Passenger = 5,
        //        Description = "The 2025 RS7 shows the spicy side of Audi, backed by its " +
        //                      "milder S7 and A7 stablemates. This sleek hatchback sedan not only looks " +
        //                      "the part of a serious performer, it's legitimately potent with 621 horsepower.",
        //        Transmission = "Auto",
        //        Luggage = "2 Bags",
        //        AirCondition = "Yes",
        //        Age = 25,
        //        CategoryId = 4,
        //    },

        //    new Car
        //    {
        //        Id = 14,
        //        Name = "AUDI Q8",
        //        Price = 720,
        //        Door = 4,
        //        Passenger = 5,
        //        Description = "The Q8 is slightly shorter than the Q7 in terms of both length and height but is slightly wider. " +
        //                      "The Q8 has less cargo space than the Q7 due to its sloped roofline, " +
        //                      "and unlike the Q7, the Q8 is not available with third-row seats.",
        //        Transmission = "Auto",
        //        Luggage = "2 Bags",
        //        AirCondition = "Yes",
        //        Age = 25,
        //        CategoryId = 2,
        //    },

        //    new Car
        //    {
        //        Id = 15,
        //        Name = "Aston Martin DBS",
        //        Price = 650,
        //        Door = 4,
        //        Passenger = 5,
        //        Description = "2023 Aston Martin DBS Horsepower & Engine Specs.Engine: 5.2-L Twin Turbo V-12. " +
        //                      "Horsepower: 715 hp. Torque: 663 lb-ft. Drivetrain: Rear Wheel Drive.",
        //        Transmission = "Auto",
        //        Luggage = "2 Bags",
        //        AirCondition = "Yes",
        //        Age = 25,
        //        CategoryId = 2,
        //    });


        //    modelBuilder.Entity<Category>()
        //                .HasData(
        //    new Category
        //    {
        //        Id = 2,
        //        Name = "Suv Cars",
        //        Image = "type1.jpg"
        //    },

        //    new Category
        //    {
        //        Id = 3,
        //        Name = "Sport Cars",
        //        Image = "type2.jpg"
        //    },

        //    new Category
        //    {
        //        Id = 4,
        //        Name = "Luxury Cars",
        //        Image = "type6.jpg"
        //    });


        //    modelBuilder.Entity<Process>()
        //                .HasData(
        //    new Process
        //    {
        //        Id = 1,
        //        Title = "Choose a Car",
        //        Description = "View our range of cars, find your perfect car for the coming days.",
        //        Number = 1,
        //    },

        //    new Process
        //    {
        //        Id = 2,
        //        Title = "Come In Contact",
        //        Description = "Our advisor team is ready to help you with the booking process.",
        //        Number = 2
        //    },

        //    new Process
        //    {
        //        Id = 3,
        //        Title = "Enjoy Driving",
        //        Description = "Receive the key and enjoy your car. We treat all our cars with respect.",
        //        Number = 3
        //    });


        //    modelBuilder.Entity<RentalCondition>()
        //                .HasData(
        //    new RentalCondition
        //    {
        //        Id = 1,
        //        Title = "Contract and Annexes",
        //        Description = "In addition to the car rental contract to be signed at the time of delivery, " +
        //                      "a credit card is required from our individual customers. We request our commercial " +
        //                      "customers to submit their company documents (tax plate, signature slip, ID photocopy).",
        //        CarId = 7,
        //    },

        //    new RentalCondition
        //    {
        //        Id = 2,
        //        Title = "Driving License and Age",
        //        Description = "The tenant must be 25 years of age and have a 5-year local or valid international " +
        //                      "driver's license for group A, B, C, D vehicles at the time of the rental agreement.",
        //        CarId = 8,
        //    },

        //    new RentalCondition
        //    {
        //        Id = 3,
        //        Title = "Price",
        //        Description = "The total rental fee is collected at the time of rental. " +
        //                      "The shortest rental period is 72 hours, and in case of delay, 1/3 of the fee" +
        //                      " is charged for each additional hour. Delays exceeding 3 " +
        //                      "hours in total are calculated as a full day. A deposit is required from a valid credit card.",
        //        CarId = 9,
        //    },

        //    new RentalCondition
        //    {
        //        Id = 4,
        //        Title = "Delivery",
        //        Description = "Delivery is free of charge where our Rent a car company is located. " +
        //                       "Delivery in these cities is possible with prior notice; hotel, workplace, station, port etc. " +
        //                       "It can be done in places. For vehicle deliveries and returns in cities where our office is " +
        //                       "not located, a delivery fee of 0.2 Euro/km is applied, starting from the rented location.",
        //        CarId = 10,
        //    },

        //    new RentalCondition
        //    {
        //        Id = 5,
        //        Title = "Traffic fines",
        //        Description = "Traffic fines toll and illegal toll fees belong to the customer. " +
        //                      "If the vehicles are detained by traffic, this period is included in the rental period. " +
        //                      "In necessary cases, we may change these conditions and information and the vehicle type " +
        //                      "specified in the reservation without prior notice. Our vehicles cannot be taken abroad.",
        //        CarId = 11,
        //    },

        //    new RentalCondition
        //    {
        //        Id = 6,
        //        Title = "Contract and Annexes",
        //        Description = "In addition to the car rental contract to be signed at the time of delivery, " +
        //                      "a credit card is required from our individual customers. We request our commercial " +
        //                      "customers to submit their company documents (tax plate, signature slip, ID photocopy).",
        //        CarId = 12,
        //    },

        //    new RentalCondition
        //    {
        //        Id = 7,
        //        Title = "Price",
        //        Description = "The total rental fee is collected at the time of rental. " +
        //                      "The shortest rental period is 72 hours, and in case of delay, 1/3 of the fee" +
        //                      " is charged for each additional hour. Delays exceeding 3 " +
        //                      "hours in total are calculated as a full day. A deposit is required from a valid credit card.",
        //        CarId = 13,
        //    },

        //    new RentalCondition
        //    {
        //        Id = 8,
        //        Title = "Payments",
        //        Description = "The total rental fee is collected at the time of rental. " +
        //                      "The shortest rental period is 72 hours, and in case of delay, 1/3 of" +
        //                      " the fee is charged for each additional hour. Delays exceeding 3 hours " +
        //                      "in total are calculated as a full day. A deposit is required from a valid credit card.",
        //        CarId = 14,
        //    },

        //    new RentalCondition
        //    {
        //        Id = 9,
        //        Title = "Driving License and Age",
        //        Description = "The tenant must be 25 years of age and have a 5-year local or valid international " +
        //                      "driver's license for group A, B, C, D vehicles at the time of the rental agreement.",
        //        CarId = 15,
        //    });


        //    modelBuilder.Entity<ServiceCondition>()
        //                .HasData(
        //    new ServiceCondition
        //    {
        //        Id = 1,
        //        Title = "Security and Licensing",
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua rana the miss sustion consation porttitor orci sit amet iaculis nisan. " +
        //                      "Lorem pretium fermentum quam sit amet cursus ante solicitune velention fermen " +
        //                      "morbinetion consesua the risus the porttiton.",
        //        ServiceId = 3,
        //    },

        //    new ServiceCondition
        //    {
        //        Id = 2,
        //        Title = "Local Currency and Tips",
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua rana the miss sustion consation porttitor orci sit amet iaculis nisan. " +
        //                      "Lorem pretium fermentum quam sit amet cursus ante solicitune velention fermen " +
        //                      "morbinetion consesua the risus the porttiton.",
        //        ServiceId = 2,
        //    },

        //    new ServiceCondition
        //    {
        //        Id = 3,
        //        Title = "Security and Licensing",
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua rana the miss sustion consation porttitor orci sit amet iaculis nisan. " +
        //                      "Lorem pretium fermentum quam sit amet cursus ante solicitune velention fermen " +
        //                      "morbinetion consesua the risus the porttiton.",
        //        ServiceId = 2,
        //    },

        //    new ServiceCondition
        //    {
        //        Id = 4,
        //        Title = "Accessibility",
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua rana the miss sustion consation porttitor orci sit amet iaculis nisan. " +
        //                      "Lorem pretium fermentum quam sit amet cursus ante solicitune velention fermen " +
        //                      "morbinetion consesua the risus the porttiton.",
        //        ServiceId = 4,
        //    },

        //    new ServiceCondition
        //    {
        //        Id = 5,
        //        Title = "Local Currency and Tips",
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua rana the miss sustion consation porttitor orci sit amet iaculis nisan. " +
        //                      "Lorem pretium fermentum quam sit amet cursus ante solicitune velention fermen " +
        //                      "morbinetion consesua the risus the porttiton.",
        //        ServiceId = 7,
        //    },

        //    new ServiceCondition
        //    {
        //        Id = 6,
        //        Title = "Security and Licensing",
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua rana the miss sustion consation porttitor orci sit amet iaculis nisan. " +
        //                      "Lorem pretium fermentum quam sit amet cursus ante solicitune velention fermen " +
        //                      "morbinetion consesua the risus the porttiton.",
        //        ServiceId = 5,
        //    },

        //    new ServiceCondition
        //    {
        //        Id = 7,
        //        Title = "Communication",
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua rana the miss sustion consation porttitor orci sit amet iaculis nisan. " +
        //                      "Lorem pretium fermentum quam sit amet cursus ante solicitune velention fermen " +
        //                      "morbinetion consesua the risus the porttiton.",
        //        ServiceId = 3,
        //    },

        //    new ServiceCondition
        //    {
        //        Id = 8,
        //        Title = "Accessibility",
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua rana the miss sustion consation porttitor orci sit amet iaculis nisan. " +
        //                      "Lorem pretium fermentum quam sit amet cursus ante solicitune velention fermen " +
        //                      "morbinetion consesua the risus the porttiton.",
        //        ServiceId = 6,
        //    });


        //    modelBuilder.Entity<ServiceDetail>()
        //                .HasData(
        //    new ServiceDetail
        //    {
        //        Id = 1,
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                      "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",
        //        Options = "Options for Airport Transfer",
        //        OptionDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                            "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                            "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        Booking = "Booking in Advance",
        //        BookingDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                             "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                             "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        Luggage = "Luggage Handling",
        //        LuggageDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                      "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        ServiceId = 4
        //    },

        //    new ServiceDetail
        //    {
        //        Id = 2,
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                      "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",
        //        Options = "Options for Airport Transfer",
        //        OptionDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                            "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                            "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        Booking = "Booking in Advance",
        //        BookingDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                             "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                             "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        Luggage = "Luggage Handling",
        //        LuggageDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                      "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        ServiceId = 3
        //    },

        //    new ServiceDetail
        //    {
        //        Id = 3,
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                      "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",
        //        Options = "Options for Airport Transfer",
        //        OptionDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                            "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                            "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        Booking = "Booking in Advance",
        //        BookingDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                             "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                             "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        Luggage = "Luggage Handling",
        //        LuggageDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                      "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        ServiceId = 2
        //    },

        //    new ServiceDetail
        //    {
        //        Id = 4,
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                      "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",
        //        Options = "Options for Airport Transfer",
        //        OptionDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                            "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                            "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        Booking = "Booking in Advance",
        //        BookingDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                             "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                             "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        Luggage = "Luggage Handling",
        //        LuggageDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                      "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        ServiceId = 5
        //    },

        //    new ServiceDetail
        //    {
        //        Id = 5,
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                      "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",
        //        Options = "Options for Airport Transfer",
        //        OptionDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                            "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                            "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        Booking = "Booking in Advance",
        //        BookingDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                             "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                             "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        Luggage = "Luggage Handling",
        //        LuggageDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                      "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        ServiceId = 6
        //    },

        //    new ServiceDetail
        //    {
        //        Id = 6,
        //        Description = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                      "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",
        //        Options = "Options for Airport Transfer",
        //        OptionDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                            "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                            "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        Booking = "Booking in Advance",
        //        BookingDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                             "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                             "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        Luggage = "Luggage Handling",
        //        LuggageDescription = "Lorem pretium fermentum quam, sit amet cursus ante sollicitudin velen morbi " +
        //                      "consesua the miss sustion consation miss orcisition amet iaculis nisan. Lorem pretium fermentum " +
        //                      "quam sit amet cursus ante sollicitudin velen fermen orbinetion consesua the risus consequation.",,
        //        ServiceId = 7
        //    });


        //    modelBuilder.Entity<Service>()
        //                .HasData(

        //    new Service
        //    {
        //        Id = 2,
        //        Name = "Corporate Car Rental",
        //        Description = "Lorem ipsum dolor sit amet the consectetur adipiscing " +
        //                      "elit entesque hendrerit elit nisan lacinia feugiat nunc eu aucton.",
        //        Image = "slider5.jpg"
        //    },

        //    new Service
        //    {
        //        Id = 3,
        //        Name = "Car Rental with Driver",
        //        Description = "Lorem ipsum dolor sit amet the consectetur adipiscing " +
        //                      "elit entesque hendrerit elit nisan lacinia feugiat nunc eu aucton.",
        //        Image = "slider3.jpg"
        //    },

        //    new Service
        //    {
        //        Id = 4,
        //        Name = "Airport Transfer",
        //        Description = "Lorem ipsum dolor sit amet the consectetur adipiscing " +
        //                      "elit entesque hendrerit elit nisan lacinia feugiat nunc eu aucton.",
        //        Image = "slider2.jpg"
        //    },

        //    new Service
        //    {
        //        Id = 5,
        //        Name = "Fleet Leasing",
        //        Description = "Lorem ipsum dolor sit amet the consectetur adipiscing " +
        //                      "elit entesque hendrerit elit nisan lacinia feugiat nunc eu aucton.",
        //        Image = "slider1.jpg"
        //    },

        //    new Service
        //    {
        //        Id = 6,
        //        Name = "VIP Transfer",
        //        Description = "Lorem ipsum dolor sit amet the consectetur adipiscing " +
        //                      "elit entesque hendrerit elit nisan lacinia feugiat nunc eu aucton.",
        //        Image = "7.jpg"
        //    },

        //    new Service
        //    {
        //        Id = 7,
        //        Name = "Private Transfer",
        //        Description = "Lorem ipsum dolor sit amet the consectetur adipiscing " +
        //                      "elit entesque hendrerit elit nisan lacinia feugiat nunc eu aucton.",
        //        Image = "slider6.jpg"
        //    });

        //    modelBuilder.Entity<Setting>()
        //                .HasData(

        //    new Setting
        //    {
        //        Id = 1,
        //        Value = "+971 52-333-4444",
        //        Key = "Call us"
        //    },

        //    new Setting
        //    {
        //        Id = 2,
        //        Value = "info@renax.com",
        //        Key = "Write to us"
        //    },

        //    new Setting
        //    {
        //        Id = 3,
        //        Value = "Dubai, Water Tower, Office 123",
        //        Key = "Address"
        //    },

        //    new Setting
        //    {
        //        Id = 4,
        //        Value = "Mon-Sun: 8 AM - 7 PM",
        //        Key = "Opening Hours"
        //    },

        //    new Setting
        //    {
        //        Id = 5,
        //        Value = "info@renax.com",
        //        Key = "Email us"
        //    });


        //    modelBuilder.Entity<Team>()
        //                .HasData(

        //    new Team
        //    {
        //        Id = 1,
        //        Image = "team1.jpg",
        //        Name = "Dan Martin",
        //        Description = "Sales Consultant"
        //    },

        //    new Team
        //    {
        //        Id = 2,
        //        Image = "team4.jpg",
        //        Name = "Emily Arla",
        //        Description = "Sales Consultant"
        //    },

        //    new Team
        //    {
        //        Id = 3,
        //        Image = "team5.jpg",
        //        Name = "Oliva White",
        //        Description = "Sales Consultant"
        //    },

        //    new Team
        //    {
        //        Id = 4,
        //        Image = "team2.jpg",
        //        Name = "Margaret Nancy",
        //        Description = "Sales Department"
        //    },

        //    new Team
        //    {
        //        Id = 5,
        //        Image = "team6.jpg",
        //        Name = "Mia Jane",
        //        Description = "Finance Department"
        //    },

        //    new Team
        //    {
        //        Id = 6,
        //        Image = "team3.jpg",
        //        Name = "Micheal Brown",
        //        Description = "Sales Consultant"
        //    });

        //    modelBuilder.Entity<VideoInfo>()
        //                .HasData(

        //    new VideoInfo
        //    {
        //        Id = 1,
        //        SubTitle = "* Premium",
        //        Title = "Rental Car",
        //        Name = "Bugatti Mistral W16",
        //        Price = 800
        //    });


        //    modelBuilder.Entity<Video>()
        //              .HasData(

        //    new Video
        //    {
        //        Id = 1,
        //        BackgroundVideo = "video.mp4"
        //    });
        //}
    }
}
