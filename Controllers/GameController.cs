using Microsoft.AspNetCore.Mvc;
using Video_Game_CRUD_AP_ShowersZ.Models;
using Video_Game_CRUD_AP_ShowersZ.Services;

namespace Video_Game_CRUD_AP_ShowersZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameServices _game;
        public GameController(IGameServices game)
        {
            _game = game;
        }

        [HttpGet("GetAll")]
        public ActionResult GetAllCargo()
        {
            return Ok(_game.GetAll());
        }

        [HttpGet("GetByGenre/{genre}")]
        public ActionResult<List<GameItem>> GetByGenre(string genre)
        {
            List<GameItem> items = _game.GetByGenre(genre);

            return Ok(items);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<GameItem> GetById(int id)
        {
            GameItem? item = _game.GetById(id);

            if(item == null)
            {
                return NotFound($"There is no game with ID {id}.");
            }

            return Ok(item);
        }

        [HttpPost("create")]
        public ActionResult<GameItem> Create([FromBody] GameItem item)
        {
            GameItem newItem = _game.Create(item);

            return CreatedAtAction(
                nameof(GetById),
                new {id = newItem.Id},
                newItem
            );
        }
// {
//     "id": 5, 
//     "title": "Among US", 
//     "rating": "E10+", 
//     "genre": "Sussy", 
//     "isavailable": false
// }

        [HttpPut("update/{id}")]
        public ActionResult<bool> UpdateCargo(int id, GameItem item)
        {
            bool updated = _game.Update(id, item);

            if(updated == false)
            {
                return NotFound($"There is no game with ID {id}.");
            }
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> DeleteItem(int id)
        {
            bool deleted = _game.Delete(id);

            if(deleted == false)
            {
                return NotFound($"There is no game with ID {id}.");
            }

            return NoContent();
        }

        [HttpGet("IsAvailable/{isavailable}")]
        public ActionResult<List<GameItem>> IsAvailable(bool isavailable)
        {
            List<GameItem> items = _game.IsAvailable(isavailable);

            return Ok(items);
        }
    }
}