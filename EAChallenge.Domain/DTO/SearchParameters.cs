using System;
using System.Collections.Generic;
using System.Text;

namespace EAChallenge.Domain.DTO
{
    public class SearchParameters
    {
        public string Culture { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
