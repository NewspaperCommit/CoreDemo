using AutoMapper;
using NewspaperArchive.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewspaperArchive.Infrastructure.Services
{
    public class AutoMapConverter<TSourceObj, TDestinationObj> : IAutoMapConverter<TSourceObj, TDestinationObj>
         where TSourceObj : class
         where TDestinationObj : class
    {
        private AutoMapper.IMapper mapper;

        public AutoMapConverter()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSourceObj, TDestinationObj>().ReverseMap();
                
            });
            mapper = config.CreateMapper();
        }



        public TDestinationObj ConvertObject(TSourceObj srcObj)
        {
            return mapper.Map<TSourceObj, TDestinationObj>(srcObj);
        }

        public List<TDestinationObj> ConvertObjectCollection(IEnumerable<TSourceObj> srcObjList)
        {
            if (srcObjList == null) return null;
            var destList = srcObjList.Select(item => this.ConvertObject(item));
            return destList.ToList();
        }
    }

    //public class AutoMapperProfile : Profile
    //{
    //    public AutoMapperProfile()
    //    {
    //        CreateMap<Model1, Model2>().ReverseMap();
    //    }
    //}
}
