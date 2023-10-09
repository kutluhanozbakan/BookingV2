using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Domain.DTOs
{
    public class AddBookDto 
    {
        public string Name { get; set; }
        public string Isbn { get; set; }
        public int AuthorId { get; set; }
    }
}
