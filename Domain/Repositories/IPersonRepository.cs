using BookingV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Domain.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        //custom Repository varsa buraya gelecek.
        Task<Person> GetPersonInformationAsync(int id); 
    }
}
