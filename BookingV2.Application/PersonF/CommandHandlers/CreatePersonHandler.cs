


using BookingV2.Application.PersonF.Commands;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using BookingV2.Infrastructure.SeedWorks;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookingV2.Application.PersonF.CommandHandlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePerson, Person>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CreatePersonHandler(IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
        }


        public async Task<Person> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Name = request.Name,
                Email = request.Email
            };
            await _personRepository.AddAsync(person);
            await _unitOfWork.SaveChangesAsync();
            return person;
        }
    }
}
   

