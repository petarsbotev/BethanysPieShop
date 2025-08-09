using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopDbContext _context;
        public PieRepository(BethanysPieShopDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Pie> AllPies => _context.Pies.Include(p => p.Category);
        public IEnumerable<Pie> PiesOfTheWeek => AllPies.Where(p => p.IsPieOfTheWeek);
        public Pie? GetPieById(int pieId) => _context.Pies.FirstOrDefault(p => p.PieId == pieId);
        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _context.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
