using System;
using System.Collections.Generic;
using System.Text;

namespace NewspaperArchive.Application.Model
{
    public class Country
    {

        public class CountrysPublications
        {
            public List<CountriesInformation> CountryList { get; set; }
            public List<DayHistoryHome> DayHistoryList { get; set; }
            public string MaxPubdateYear { get; set; }
            public string MinPubDateYear { get; set; }
            public string PublicationYearsCount { get; set; }
            public string USStateCount { get; set; }
        }

        public class CountriesInformation
        {
            //[Key]
            public int CountryId { get; set; }
            public string ABBR { get; set; }
            public string CountryName { get; set; }
        }


        public class DayHistoryHome
        {
            //[Keyless]


            public int imageid { get; set; }
            //public string destimagepath { get; set; }
            public string pubtitle { get; set; }
            //public string pubtitleurl { get; set; }
            public string CountryName { get; set; }
            public string StateName { get; set; }
            public string CityName { get; set; }
            public string PubDate { get; set; }
            public string CountryAbbr { get; set; }
            public string StateAbbr { get; set; }

            //public int CountryId { get; set; }
        }
    }


}

