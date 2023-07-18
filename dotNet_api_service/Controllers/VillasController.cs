using dotNet_api_service.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNet_api_service.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/villas")]
    [ApiController]
    public class VillasController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Villa> getVillas()
        {
            return new List<Villa>
            {
               new Villa{Id=1, Name="SeaSide Villa"},
               new Villa{Id=2, Name="NearForest Villa"},
               new Villa{Id=3, Name="Sunrise Temple Villa"},
               new Villa{Id=4, Name="Moonlight Elegant Palace"},
               new Villa{Id=5, Name="BellaPlaza Villa"},
               new Villa{Id=6, Name="Paradise Residence Villa"}
            };
        }
    }
}
