using System;
using System.Collections.Generic;
using System.Text;

namespace NewspaperArchive.Application.Helper
{
   public interface IContextDataHandler
    {
        int GetIntegerValue(object obj, int defaultReturnValue);
        string GetStringValue(object obj, string defaultValue);



    }
}
