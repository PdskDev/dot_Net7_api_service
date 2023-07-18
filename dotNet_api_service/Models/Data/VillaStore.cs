using dotNet_api_service.Models.Dto;

namespace dotNet_api_service.Models.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villasList = new List<VillaDTO>
            {
               new VillaDTO {Id=1, Name="SeaSide Villa"},
               new VillaDTO {Id=2, Name="NearForest Villa"},
               new VillaDTO { Id = 3, Name = "Sunrise Temple Villa" },
               new VillaDTO { Id = 4, Name = "Moonlight Elegant Palace" },
               new VillaDTO { Id = 5, Name = "BellaPlaza Villa" },
               new VillaDTO { Id = 6, Name = "Paradise Residence Villa" }
            };


    };
}
