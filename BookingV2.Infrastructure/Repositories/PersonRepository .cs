
using BookingV2.Domain;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Infrastructure.Repositories
{
    public class PersonRepository : GenericRepository<Person>,IPersonRepository
    {

        public PersonRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task<Person> GetPersonInformationAsync(int id)
        {
            return await _appDbContext.Person.FindAsync(id);
        }

    }
}
