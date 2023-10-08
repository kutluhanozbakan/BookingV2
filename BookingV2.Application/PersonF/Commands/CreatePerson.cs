using MediatR;
using System;
using System.Collections.Generic;
using BookingV2.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.PersonF.Commands
{
    public class CreatePerson : IRequest<Person>
    {
        public string? Name { get; set; }

        public string? Email { get; set; }
    }
}
