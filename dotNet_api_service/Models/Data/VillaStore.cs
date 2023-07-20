using dotNet_api_service.Models.Dto;

namespace dotNet_api_service.Models.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villasList = new List<VillaDTO>
            {
               new VillaDTO {Id=1, Name="SeaSide Villa", Occupancy=5, SquareFeet=100},
               new VillaDTO {Id=2, Name="NearForest Villa", Occupancy=10, SquareFeet=100},
               new VillaDTO { Id = 3, Name = "Sunrise Temple Villa", Occupancy=35, SquareFeet=150 },
               new VillaDTO { Id = 4, Name = "Moonlight Elegant Palace" , Occupancy=20, SquareFeet=250},
               new VillaDTO { Id = 5, Name = "BellaPlaza Villa", Occupancy=15, SquareFeet=230 },
               new VillaDTO { Id = 6, Name = "Paradise Residence Villa", Occupancy=8, SquareFeet=300 }
            };
    };
}
