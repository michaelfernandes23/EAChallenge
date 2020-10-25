using EAChallenge.Domain.DTO;
using EAChallenge.Domain.Interfaces;
using EAChallenge.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EAChallenge.Services
{
    public class CarDetailsService : ICarDetailsService
    {
        private readonly ICarDetailsRepository _carDetailsRepository;
        public CarDetailsService(ICarDetailsRepository carDetailsRepository)
        {
            _carDetailsRepository = carDetailsRepository;
        }

        public async Task<List<CarDetailsDTO>> GetCarDetails(SearchParameters searchParameters)
        {
            return await _carDetailsRepository.GetAllCarsWithAuctionDetails(searchParameters);
        }
    }
}
