using NewspaperArchive.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperArchive.Application.Services
{
    public interface ICountryService
    {
        //CountrysPublications GetAllCountriesWithAbbr();
        Task<Apiresponsemodel> GetAllCountriesWithAbbr();

    }
}
