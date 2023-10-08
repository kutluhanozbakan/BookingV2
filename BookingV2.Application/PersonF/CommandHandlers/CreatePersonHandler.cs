


using BookingV2.Application.PersonF.Commands;
using BookingV2.Domain.DTOs;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using BookingV2.Infrastructure.SeedWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookingV2.Application.PersonF.CommandHandlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePerson, Person>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Person> _userManager;


        public CreatePersonHandler(IPersonRepository personRepository, IUnitOfWork unitOfWork, UserManager<Person> userManager = null)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _userManager = userManager;
        }

        public async Task<Person> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Email = request.Email,
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(person, request.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(r => r.Description).ToList();
                throw new Exception("hata");
            }
            // yerine automapper gelebilir
            return person;
        }
    }
}


