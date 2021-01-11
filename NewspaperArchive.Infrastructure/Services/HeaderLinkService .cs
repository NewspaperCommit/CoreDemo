using System;
using System.Collections.Generic;
using System.Text;
using NewspaperArchive.Infrastructure.Persistence.Contexts;
using NewspaperArchive.Infrastructure.Services;
using NewspaperArchive.Application.Model;
using System.Threading.Tasks;
using NewspaperArchive.Application.Services;
namespace NewspaperArchive.Infrastructure.Services
{
   public class HeaderLinkService: IHeaderLink
    {
        private readonly DemoDbContext context;

        //public HeaderLinkServices(DemoDbContext context)
        //{
        //    this.context = context;
        //}
        public async Task<HeaderLinksModel> GetHeaderLinkssinglecss()

        {
            var model = new HeaderLinksModel();
            // var result = context.EventList.FromSqlRaw("exec [dbo].[Sp_GetEventList]");
            return await Task.FromResult<HeaderLinksModel>(model);

        }
    }
}
