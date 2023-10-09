using BookingV2.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Domain.Entities
{
    public class Book : BaseEntity
    {
        public Book(string name, string isbn, int authorId)
        {
            this.name = name;
            this.isbn = isbn;
            this.authorId = authorId;
        }

        public string name { get; private set; }
        public string isbn { get; private set; }
        public int authorId { get; private set; }

    }
}
