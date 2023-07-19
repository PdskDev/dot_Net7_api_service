using dotNet_api_service.Logging;
using dotNet_api_service.Models.Data;
using dotNet_api_service.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace dotNet_api_service.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/villas")]
    [ApiController]
    public class VillasController : ControllerBase
    {
        private readonly ILogging _logger;

        public VillasController(ILogging logger)
        {
          _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.Log("Get All: Getting all villas", "runtime");

            return Ok(VillaStore.villasList);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if(id == 0)
            {
                _logger.Log("Get by Id: Get Villa Error with id " + id, "error");
                return BadRequest();
            }

            var villa = VillaStore.villasList.FirstOrDefault(v => v.Id == id);

            if(villa == null)
            {
                _logger.Log("Get by Id: Get Villa is Null", "error");
                return NotFound();
            }

            _logger.Log("Get by Id: Get Villa is retrieved", "info");
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (VillaStore.villasList.FirstOrDefault(v => v.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                _logger.Log("Post: Villa already exist", "error");
                ModelState.AddModelError("CustomError", "Villa already exists");
                return BadRequest(ModelState);
            }

            if(villaDTO == null)
            {
                _logger.Log("Post: Posted Villa is Null", "error");
                return BadRequest(villaDTO);
            }

            if(villaDTO.Id > 0)
            {
                _logger.Log("Post: Posted Villa Id is not equal to 0", "error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villaDTO.Id = VillaStore.villasList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            VillaStore.villasList.Add(villaDTO);
            //return Ok(villaDTO);

            _logger.Log("Post: New Villa is created with success", "info");
            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVille(int id)
        {

            if (id == 0)
            {
                _logger.Log("Delete: Posted Villa Id is not equal to 0", "error");
                return BadRequest();
            }

            var villa = VillaStore.villasList.FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                _logger.Log("Delete: Posted Villa not found", "error");
                return NotFound();
            }

            VillaStore.villasList.Remove(villa);

            _logger.Log("Delete: Posted Villa has been deleted", "info");
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaToUpdate)
        {
            if(villaToUpdate == null || id!= villaToUpdate.Id)
            {
                _logger.Log("Put: Posted Villa is null or is id is different", "error");
                return BadRequest();
            }

            var villa = VillaStore.villasList.FirstOrDefault(v => v.Id == villaToUpdate.Id);
            villa.Name = villaToUpdate.Name;
            villa.Occupancy = villaToUpdate.Occupancy;
            villa.SquartFeet = villaToUpdate.SquartFeet;

            //return NoContent();
            return Ok(villa);
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, [FromBody] JsonPatchDocument<VillaDTO> villaToPatch)
        {
            if (villaToPatch == null || id == 0)
            {
                _logger.Log("Patch: Posted Villa is null or id is null", "error");
                return BadRequest();
            }

            var villa = VillaStore.villasList.FirstOrDefault(v => v.Id == id);

            if(villa == null)
            {
                _logger.Log("Patch: Posted Villa not found", "error");
                return NotFound();
            }

            villaToPatch.ApplyTo(villa, ModelState);

            if(!ModelState.IsValid)
            {
                _logger.Log("Patch: ModelState is not valid", "error");
                return BadRequest(ModelState);
            }

            //return NoContent();
            return Ok(villa);
        }


    }
}
