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
        public ActionResult<IEnumerable<VillaDTO>> getVillas()
        {
            return Ok(VillaStore.villasList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(VillaDTO))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult getVillas(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var villa = VillaStore.villasList.FirstOrDefault(v => v.Id == id);

            if(villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }
    }
}
