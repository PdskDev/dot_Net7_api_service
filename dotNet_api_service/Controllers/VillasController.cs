using dotNet_api_service.Models;
using dotNet_api_service.Models.Data;
using dotNet_api_service.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotNet_api_service.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/villas")]
    [ApiController]
    public class VillasController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public VillasController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            //return Ok(VillaStore.villasList);
            return Ok(_db.Villas.ToList());
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            //var villa = VillaStore.villasList.FirstOrDefault(v => v.Id == id);
            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

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

            //if (VillaStore.villasList.FirstOrDefault(v => v.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            if (_db.Villas.FirstOrDefault(v => v.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already exists");
                return BadRequest(ModelState);
            }

            if(villaDTO == null)
            {
                return BadRequest(villaDTO);
            }

            if(villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            //villaDTO.Id = VillaStore.villasList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            //VillaStore.villasList.Add(villaDTO);
            //return Ok(villaDTO);

            Villa modelVilla = new()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Amenity = villaDTO.Amenity,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Rate = villaDTO.Rate,
                SquareFeet = villaDTO.SquareFeet
            };

            _db.Villas.Add(modelVilla);
            _db.SaveChanges();

            VillaDTO returnModelDTO = new()
            {
                Id = modelVilla.Id,
                Name = modelVilla.Name,
                Details = modelVilla.Details,
                Amenity = modelVilla.Amenity,
                Occupancy = modelVilla.Occupancy,
                ImageUrl = modelVilla.ImageUrl,
                Rate = modelVilla.Rate,
                SquareFeet = modelVilla.SquareFeet
            };

            return CreatedAtRoute("GetVilla", new { id = returnModelDTO.Id }, returnModelDTO);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVille(int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }

            //var villa = VillaStore.villasList.FirstOrDefault(v => v.Id == id);
            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            //VillaStore.villasList.Remove(villa);
            _db.Villas.Remove(villa);
            _db.SaveChanges();

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
                return BadRequest();
            }

            //var villa = VillaStore.villasList.FirstOrDefault(v => v.Id == villaToUpdate.Id);
            //villa.Name = villaToUpdate.Name;
            //villa.Occupancy = villaToUpdate.Occupancy;
            //villa.SquareFeet = villaToUpdate.SquareFeet;
            //return NoContent();

            var existVilla = _db.Villas.FirstOrDefault(v => v.Id == villaToUpdate.Id);
           
            if (existVilla == null)
            {
                return NotFound();
            }


            // Id = villaToUpdate.Id,
            existVilla.Name = villaToUpdate.Name;
            existVilla.Details = villaToUpdate.Details;
            existVilla.Amenity = villaToUpdate.Amenity;
            existVilla.Occupancy = villaToUpdate.Occupancy;
            existVilla.ImageUrl = villaToUpdate.ImageUrl;
            existVilla.Rate = villaToUpdate.Rate;
            existVilla.SquareFeet = villaToUpdate.SquareFeet;
            

            _db.Villas.Update(existVilla);
            _db.SaveChanges();
            return Ok(villaToUpdate);
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, [FromBody] JsonPatchDocument<VillaDTO> partialVillaDTO)
        {
            if (partialVillaDTO == null || id == 0)
            {
                return BadRequest();
            }

            //var villa = VillaStore.villasList.FirstOrDefault(v => v.Id == id);
            var villa = _db.Villas.AsNoTracking().FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            VillaDTO villaDTO = new VillaDTO()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Amenity = villa.Amenity,
                Occupancy = villa.Occupancy,
                ImageUrl = villa.ImageUrl,
                Rate = villa.Rate,
                SquareFeet = villa.SquareFeet
            };

            partialVillaDTO.ApplyTo(villaDTO, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Villa patchVillaToDB = new()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Amenity = villaDTO.Amenity,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Rate = villaDTO.Rate,
                SquareFeet = villaDTO.SquareFeet
            };

            _db.Villas.Update(patchVillaToDB);
            _db.SaveChanges();

            //return NoContent();
            return Ok(villaDTO);
        }


    }
}
