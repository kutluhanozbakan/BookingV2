using BookingV2.Domain.DTOs;
using BookingV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Domain.Repositories
{
    public interface ITokenRepository
    {
        TokenDto CreateToken(Person person);
    }
}
