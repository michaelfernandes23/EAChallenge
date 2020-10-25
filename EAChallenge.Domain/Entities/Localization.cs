using System;
using System.Collections.Generic;
using System.Text;

namespace EAChallenge.Domain.Entities
{
    public class Localization
    {
        public int Id { get; set; }
        public int LocalizationSetId { get; set; }
        public string CultureCode { get; set; }
        public string Value { get; set; }

        public virtual LocalizationSet LocalizationSet { get; set; }
        public virtual Culture Culture { get; set; }
    }
}
