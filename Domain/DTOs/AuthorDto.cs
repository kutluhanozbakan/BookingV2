using BookingV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Domain.DTOs
{
    public class AuthorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
