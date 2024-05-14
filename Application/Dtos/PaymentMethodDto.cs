using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class PaymentMethodDto
    {
        public string Name { get; set; } 
    }
    public class PaymentMethodViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
