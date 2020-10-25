using System;
using System.Collections.Generic;
using System.Text;

namespace EAChallenge.Domain.Entities
{
    public class LocalizationSet
    {
        public int Id { get; set; }
        public virtual ICollection<Localization> Localizations { get; set; }
    }
}
