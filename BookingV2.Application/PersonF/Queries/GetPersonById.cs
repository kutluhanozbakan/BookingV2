using BookingV2.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.PersonF.Queries
{
    public class GetPersonById : IRequest<Person>
    {
        public int Id { get; set; }
    }
}
