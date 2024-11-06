using Microsoft.AspNetCore.Mvc;
using RestWoodPellets.Repository;
using RestWoodPellets.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWoodPellets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WoodPelletController : ControllerBase
    {
        private readonly WoodPelletRepository _repo;

        public WoodPelletController(WoodPelletRepository repo) //dependency injection
        {
            _repo = repo;
        }



        // GET: api/<WoodPelletController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<WoodPellet>> Get()
        {
            if (_repo.GetAllWoodPellets().Count == 0)
            {
                return NotFound("No items in the list");
            }
            return Ok(_repo.GetAllWoodPellets());

        }

        // GET api/<WoodPelletController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<WoodPellet> Get(int id)
        {
            WoodPellet woodpellet = _repo.GetWoodPelletById(id);
            if (woodpellet == null)
            {
                return NotFound("No such item, id " + id);
            }
            return Ok(woodpellet);
        }

        // POST api/<WoodPelletController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult<WoodPellet> Post([FromBody] WoodPellet value)
        {
            if (value == null)
            {
                return BadRequest("WoodPellet data is null."); // Return 400 if data is missing or invalid
            }

            try
            {
                // Validate the WoodPellet object
                value.Validate();
            }
            catch (Exception ex)
            {
                return BadRequest($"Validation failed: {ex.Message}");  // Return 400 with validation error message
            }

            var addedWoodPellet = _repo.AddWoodPellet(value);


            // If book is successfully added, return 201 and the created object
            return CreatedAtAction(nameof(Get), new { id = addedWoodPellet.Id }, addedWoodPellet);
        }

        // PUT api/<WoodPelletController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]  // For successful update
        [ProducesResponseType(StatusCodes.Status400BadRequest)]  // For invalid input
        [ProducesResponseType(StatusCodes.Status404NotFound)]  // When WoodPellet is not found
        [HttpPut("{id}")]
        public ActionResult<WoodPellet> Put(int id, [FromBody] WoodPellet value)
        {
            if (value == null)
            {
                return BadRequest("WoodPellet data is null.");  // Return 400 if no data is provided
            }
            // Validate the input data

            // Validate the input data
            try
            {
                // Validate the WoodPellet object
                value.Validate();
            }
            catch (Exception ex)
            {
                return BadRequest($"Validation failed: {ex.Message}");  // Return 400 with validation error message
            }


            var existingwoodpellet = _repo.GetWoodPelletById(id);

            if (existingwoodpellet == null)
            {
                return NotFound($"Woodpellet with ID {id} not found."); // Return 404 if the Woodpellet doesn't exist
            }

            var updatedWoodpellet = _repo.UpdateWoodPellet(value);

            return Ok(updatedWoodpellet); // Return 200 with the updated book object
        }

        // DELETE api/<WoodPelletController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
