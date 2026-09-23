using Video_Game_CRUD_AP_ShowersZ.Models;

namespace Video_Game_CRUD_AP_ShowersZ.Services
{
    public interface IGameServices
    {
        List<GameItem> GetAll();

        List<GameItem> GetByGenre(string Genre);

        List<GameItem> IsAvailable(bool isavailable);

        GameItem GetById(int id);

        GameItem Create(GameItem item);

        bool Update(int id, GameItem item);

        bool Delete(int id);
    }
}