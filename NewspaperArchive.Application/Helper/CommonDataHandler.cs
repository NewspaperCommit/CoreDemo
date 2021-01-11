using System;
using System.Collections.Generic;
using System.Text;

namespace NewspaperArchive.Application.Helper
{
    public class CommonDataHandler: IContextDataHandler
    {

        public string GetStringValue(object obj, string defaultValue)
        {
            if (!(obj == null || obj == DBNull.Value))
                defaultValue = obj.ToString();
            return defaultValue;
        }

        public int GetIntegerValue(object obj, int defaultReturnValue)
        {
            try
            {
                if (obj != null)
                {
                    string objvalue = ClearSpecialChar(Convert.ToString(obj));
                    int x;
                    if (int.TryParse(objvalue, out x))
                    {
                        defaultReturnValue = x;
                    }

                }
            }
            catch
            {
                throw new NotImplementedException();
            }
            return defaultReturnValue;
        }

        public string ClearSpecialChar(string TextWithoutSpecialChar)
        {
            return TextWithoutSpecialChar
                    .Replace("/", "")
                    .Replace("//", "")
                    .Replace("\\", "")
                    .Replace("<", "")
                    .Replace(">", "")

                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("[", "")
                    .Replace("]", "")
                    .Replace("{", "")
                    .Replace("}", "")
                    .Replace("¦", "")
                    ;
        }
    }
}
