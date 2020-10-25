using EAChallenge.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAChallenge.Domain.Interfaces
{
    public interface ICarDetailsRepository
    {
        Task<List<CarDetailsDTO>> GetAll(SearchParameters searchParameters);
    }
}
