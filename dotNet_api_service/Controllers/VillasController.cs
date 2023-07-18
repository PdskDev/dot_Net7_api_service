using dotNet_api_service.Models;
using dotNet_api_service.Models.Data;
using dotNet_api_service.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace dotNet_api_service.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/villas")]
    [ApiController]
    public class VillasController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> getVillas()
        {
            return VillaStore.villasList;
        }
    }
}
