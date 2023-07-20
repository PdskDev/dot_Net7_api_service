using Microsoft.EntityFrameworkCore;

namespace dotNet_api_service.Models.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
        }
       
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "SeaSide Villa",
                    Details = "Amazing villa",
                    Rate = 10,
                    Occupancy = 25,
                    SquareFeet = 300,
                    ImageUrl = "https://www.bailypearl.com/wp-content/uploads/2021/05/villa-la-croix-valmer-facade-2-2-2560x1633.jpg",
                    Amenity = "",
                    CreateDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "NearForest Villa",
                    Details = "Amazing villa",
                    Rate = 10,
                    Occupancy = 50,
                    SquareFeet = 150,
                    ImageUrl = "https://www.villas-melrose.fr/wp-content/themes/villas-melrose/assets/images/hp/bg-contact-grand.jpg",
                    Amenity = "",
                    CreateDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Sunrise Temple Villa",
                    Details = "Amazing villa",
                    Rate = 9,
                    Occupancy = 25,
                    SquareFeet = 250,
                    ImageUrl = "https://www.explorenicecotedazur.com/content/uploads/2021/11/Ephrussi-scaled.jpg",
                    Amenity = "",
                    CreateDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Moonlight Elegant Palace",
                    Details = "Amazing villa",
                    Rate = 10,
                    Occupancy = 100,
                    SquareFeet = 280,
                    ImageUrl = "https://i.ytimg.com/vi/Fw1IBJxcgc4/maxresdefault.jpg",
                    Amenity = "",
                    CreateDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 5,
                    Name = "BellaPlaza Villa",
                    Details = "Amazing villa",
                    Rate = 9,
                    Occupancy = 100,
                    SquareFeet = 450,
                    ImageUrl = "https://www.marbella-ev.com/wp-content/uploads/2021/03/Most-Luxury-Villla-in-Marbella.jpg",
                    Amenity = "",
                    CreateDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 6,
                    Name = "Paradise Residence Villa",
                    Details = "Amazing villa",
                    Rate = 8,
                    Occupancy = 120,
                    SquareFeet = 500,
                    ImageUrl = "https://www.villasleona.fr/public/img/big/27099456jpg_6352a08f482b3.jpg",
                    Amenity = "",
                    CreateDate = DateTime.Now
                }
                );
        }
    }
}
