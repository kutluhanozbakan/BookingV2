
using BookingV2.Application.PersonF.Queries;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.PersonF.QueryHandlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonById, Person>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonByIdHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> Handle(GetPersonById request, CancellationToken cancellationToken)
        {
            return await _personRepository.GetPersonInformationAsync(request.Id);
        }
    }
}
