using EAChallenge.Domain.DTO;
using EAChallenge.Domain.Entities;
using EAChallenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAChallenge.Infrastructure.Repositories
{
    public class CarDetailsRepository : ICarDetailsRepository
    {
        private readonly EAChallengeDBContext _dbContext;

        public CarDetailsRepository(EAChallengeDBContext eAChallengeDBContext)
        {
            _dbContext = eAChallengeDBContext;
        }

        public async Task<List<CarDetailsDTO>> GetAll(SearchParameters searchParameters)
        {
            try
            {
                var count = await _dbContext.CarDetails.CountAsync();
                var PageSize = searchParameters.PageSize;
                var TotalPages = (int)Math.Ceiling(count / (double)PageSize);
                var CurrentPage = searchParameters.PageNumber;
                var previousPage = CurrentPage > 1 ? "Yes" : "No";
                var nextPage = CurrentPage < TotalPages ? "Yes" : "No";
                var itemStart = (searchParameters.PageNumber - 1) * PageSize;
                var itemEnd = count < PageSize ? count : (searchParameters.PageNumber) * PageSize;

                var data = await (from b in _dbContext.CarDetails
                                  join lDescription in _dbContext.Localization on b.DescriptionId equals lDescription.LocalizationSetId
                                  join lShareMessage in _dbContext.Localization on b.ShareMessageId equals lShareMessage.LocalizationSetId
                                  join auctionDetails in _dbContext.AuctionDetails on b.Id equals auctionDetails.CarDetailsId
                                  join lCurrency in _dbContext.Localization on auctionDetails.CurrencyId equals lCurrency.LocalizationSetId
                                  where lDescription.CultureCode == searchParameters.Culture && 
                                        lShareMessage.CultureCode == searchParameters.Culture &&
                                        lCurrency.CultureCode == searchParameters.Culture &&
                                        (searchParameters.Description == null || lDescription.Value.Contains(searchParameters.Description)) &&
                                        (searchParameters.Year == 0 || b.Year == searchParameters.Year)
                                  select new CarDetailsDTO()
                                  {
                                      CarId = b.Id,
                                      ImagePath = b.ImagePath,
                                      Description = lDescription.Value,
                                      ShareMessage = lShareMessage.Value,
                                      ShareLink = b.ShareLink,
                                      AuctionInfo = new AuctionInfoDTO
                                      {
                                          Bids = auctionDetails.Bids,
                                          EndDate = auctionDetails.EndDate,
                                          CurrentPrice = auctionDetails.CurrentPrice,
                                          VinNumber = auctionDetails.VinNumber,
                                          Currency = lCurrency.Value
                                      }
                                  }).Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
