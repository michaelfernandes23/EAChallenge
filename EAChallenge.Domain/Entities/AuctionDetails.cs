using System;
using System.Collections.Generic;
using System.Text;

namespace EAChallenge.Domain.Entities
{
    public class AuctionDetails
    {
        public int Id { get; set; }
        public int CarDetailsId { get; set; }
        public int Bids { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentPrice { get; set; }
        public int CurrencyId { get; set; }
        public string VinNumber { get; set; }

        public virtual LocalizationSet Currency { get; set; }
    }
}
