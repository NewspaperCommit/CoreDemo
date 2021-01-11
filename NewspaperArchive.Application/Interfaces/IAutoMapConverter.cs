using System;
using System.Collections.Generic;
using System.Text;

namespace NewspaperArchive.Application.Interfaces
{
    public interface IAutoMapConverter<TSourceObj, TDestinationObj>
        where TSourceObj : class
        where TDestinationObj : class
    {
        TDestinationObj ConvertObject(TSourceObj srcObj);
        List<TDestinationObj> ConvertObjectCollection(IEnumerable<TSourceObj> srcObj);
    }
}
