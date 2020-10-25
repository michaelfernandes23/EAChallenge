using EAChallenge.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EAChallenge.Services.Interfaces
{
    public interface ICarDetailsService
    {
        Task<List<CarDetailsDTO>> GetCarDetails(SearchParameters searchParameters);
    }
}
