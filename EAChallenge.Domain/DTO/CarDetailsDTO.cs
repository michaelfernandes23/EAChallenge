using System;
using System.Collections.Generic;
using System.Text;

namespace EAChallenge.Domain.DTO
{
    public class CarDetailsDTO
    {
        public int CarId { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ShareLink { get; set; }
        public string ShareMessage { get; set; }
        public AuctionInfoDTO AuctionInfo { get; set; }
    }
}
