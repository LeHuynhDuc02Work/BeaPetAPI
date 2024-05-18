using Application.Contracts;
using Application.Dtos;
using Application.Helpers;
using AutoMapper;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<ReviewViewDto>> GetAllByProductId(int id)
        {
            var reviews = _unitOfWork.ReviewRepository.GetAll()
                            .Where(x => x.ProductId == id)
                            .OrderByDescending(x => x.Id);

            var ReviewMap = _mapper.Map<List<ReviewViewDto>>(reviews);
            foreach (var review in ReviewMap)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id.Trim() == review.UserId.Trim());
                review.UserName = user.UserName;
            }
            return ReviewMap;

        }
        public async Task<ReviewViewDto> Create(ReviewDto reviewCreate)
        {
            if (reviewCreate == null)
                throw new ApplicationException("NoContent");

            var _review = _mapper.Map<Review>(reviewCreate);
            await _unitOfWork.ReviewRepository.Create(_review);
            await _unitOfWork.ReviewRepository.SaveChange();

            return _mapper.Map<ReviewViewDto>(_review);
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReviewViewDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ReviewViewDto> GetByProductId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewViewDto> Update(ReviewDto reviewUpdate)
        {
            throw new NotImplementedException();
        }
    }
}