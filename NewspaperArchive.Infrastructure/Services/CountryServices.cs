using Microsoft.EntityFrameworkCore;
using NewspaperArchive.Application.Model;
using NewspaperArchive.Application.Services;
using NewspaperArchive.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using static NewspaperArchive.Application.Model.Country;

namespace NewspaperArchive.Infrastructure.Services
{
    class CountryServices : ICountryService
    {
        private readonly DemoDbContext context;

        public CountryServices(DemoDbContext context)
        {
            this.context = context;
        }
        public async Task<Apiresponsemodel> GetAllCountriesWithAbbr()
        {
            //var Dmodel = new DayHistoryHome();
            var model = new CountrysPublications();
            //var Countmd = new CountriesInformation();
            List<CountriesInformation> countrylist = new List<CountriesInformation>();
            List<DayHistoryHome> Dayhistory = new List<DayHistoryHome>();
            //List<CountrysPublications> list3 = new List<CountrysPublications>();
            Apiresponsemodel response = new Apiresponsemodel();
            var cmd = context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "sp_GetAllCountriesWithAbbr";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DbDataReader reader = null;

            try
            {
                if (context.Database.GetDbConnection().State == ConnectionState.Closed)
                {
                    context.Database.GetDbConnection().Open();
                }
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        countrylist.Add(new CountriesInformation()
                        {
                            CountryId = Convert.ToInt32(reader["CountryId"].ToString()),
                            ABBR = reader["ABBR"].ToString(),
                            CountryName = reader["CountryName"].ToString()
                        });


                    }
                }


                reader.NextResult();

                //var list1 = await context.DayHistoryHome.FromSqlRaw("exec [dbo].[sp_GetAllCountriesWithAbbr]").ToListAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Dayhistory.Add(new DayHistoryHome()
                        {
                            imageid = Convert.ToInt32(reader["imageid"].ToString()),
                            pubtitle = reader["pubtitle"].ToString(),
                            CountryName = reader["CountryName"].ToString(),
                            StateName = reader["StateName"].ToString(),
                            CityName = reader["CityName"].ToString(),
                            PubDate = reader["PubDate"].ToString(),
                            CountryAbbr = reader["CountryAbbr"].ToString(),
                            StateAbbr = reader["StateAbbr"].ToString(),
                        });


                    }
                }

                reader.NextResult();
                if (reader.HasRows)
                {
                   
                        while (reader.Read())
                        {
                            model.MaxPubdateYear = reader["MaxPubdateYear"].ToString();
                            model.MinPubDateYear = reader["MinPubDateYear"].ToString();
                            model.PublicationYearsCount = reader["PublicationYears"].ToString();
                        }


                    
                }

                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.USStateCount = reader["USStateCount"].ToString();
                    }
                }

                model.CountryList = countrylist;
                model.DayHistoryList = Dayhistory;

                response.Data = model;
                response.Message = "Successful";
                response.Status = 200;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.Status = 400;
            }
            return response;



        }
    }
}
