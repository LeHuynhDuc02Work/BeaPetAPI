﻿using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int Id)
        {
            var result = _context.Reviews.FirstOrDefaultAsync(x => x.Id == Id);
            return await result != null;
        }

        public async Task<Review> GetReviewById(int Id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}