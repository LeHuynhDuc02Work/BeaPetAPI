using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ReviewDto
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string? Content { get; set; }
        //public int Like { get; set; }
        //public int Dislike { get; set; }
    }
    public class ReviewViewDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }
        public string? Content { get; set; }
        //public int Like { get; set; }
        //public int Dislike { get; set; }
    }
}
