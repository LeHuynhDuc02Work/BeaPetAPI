using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class SliderRepository : BaseRepository<Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext _context;
        public SliderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int Id)
        {
            var result = _context.Sliders.FirstOrDefaultAsync(x => x.Id == Id);
            return await result != null;
        }

        public async Task<Slider> GetSliderById(int Id)
        {
            return await _context.Sliders.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}