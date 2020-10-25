using System;

namespace EAChallenge.Domain.DTO
{
    public class AuctionInfoDTO
    {
        public int Bids { get; set; }
        public int CurrentPrice { get; set; }
        public DateTime EndDate { get; set; }
        public string Currency { get; set; }
        public string Lot { get; set; }
        public string VinNumber { get; set; }
    }
}