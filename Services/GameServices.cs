using Video_Game_CRUD_AP_ShowersZ.Models;

namespace Video_Game_CRUD_AP_ShowersZ.Services
{
    public class GameServices : IGameServices
    {
        private static List<GameItem> _manafest = [
            new GameItem {Id = 1, Title = "Sonic Unleashed", Rating = "E10+", Genre = "Adventure", IsAvailable = true},
            new GameItem {Id = 2, Title = "LEGO Dimensions", Rating = "E10+", Genre = "Puzzle", IsAvailable = false},
            new GameItem {Id = 3, Title = "Super Smash Bros. Brawl", Rating = "T", Genre = "Fighting", IsAvailable = true},
            new GameItem {Id = 4, Title = "Super Meat Boy", Rating = "T", Genre = "Platform", IsAvailable = true},
            new GameItem {Id = 5, Title = "Undertale", Rating = "E10+", Genre = "RPG", IsAvailable = true},
            new GameItem {Id = 6, Title = "Deltarune", Rating = "T", Genre = "RPG", IsAvailable = true},
            new GameItem {Id = 7, Title = "Antonblast", Rating = "T", Genre = "Platform", IsAvailable = true},
            new GameItem {Id = 8, Title = "Jet Set Radio", Rating = "T", Genre = "Platform", IsAvailable = false},
            new GameItem {Id = 9, Title = "ULTIMATE Marvel vs. Capcom 3", Rating = "T", Genre = "Fighting", IsAvailable = true},
            new GameItem {Id = 10, Title = "MINECRAFT", Rating = "10+", Genre = "Adventure", IsAvailable = true}
        ];

        static int newId = 11;

        public List<GameItem> GetAll()
        {
            return _manafest;
        }

        public List<GameItem> GetByGenre(string genre)
        {
            IEnumerable<GameItem> result = _manafest;

            result = result.Where(c => c.Genre == genre);

            return result.ToList();
        }

        public GameItem GetById(int id)
        {
            GameItem? item = _manafest.FirstOrDefault(c => c.Id == id);

            return item;
        }

        public GameItem Create(GameItem item)
        {
            item.Id = newId;
            newId++;

            _manafest.Add(item);

            return item;
        }

        public bool Update(int id, GameItem item)
        {
            GameItem? existing = _manafest.FirstOrDefault(i => i.Id == id);

            if(existing == null)
            {
                return false;
            }

            existing.Title = item.Title;
            existing.Rating = item.Rating;
            existing.Genre = item.Genre;
            existing.IsAvailable = item.IsAvailable;

            return true;
        }

        public bool Delete(int id)
        {
            GameItem? existingItem = _manafest.FirstOrDefault(t => t.Id == id);

            if (existingItem == null)
            {
                return false;
            }

            _manafest.Remove(existingItem);

            return true;
        }


        public List<GameItem> IsAvailable(bool isavailable)
        {
            IEnumerable<GameItem> result = _manafest;

            result = result.Where(c => c.IsAvailable == isavailable);

            return result.ToList();
        }
    }
}