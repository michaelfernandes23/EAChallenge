using System;
using System.Collections.Generic;
using System.Text;

namespace EAChallenge.Domain.Entities
{
    public class CarDetails
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int DescriptionId { get; set; }
        public int ShareMessageId { get; set; }
        public string ShareLink { get; set; }
        public int Year { get; set; }

        public virtual LocalizationSet Description { get; set; }
        public virtual LocalizationSet ShareMessage { get; set; }
    }
}
