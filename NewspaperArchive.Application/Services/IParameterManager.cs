using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NewspaperArchive.Application.Services
{
    public interface IParameterManager
    {

        IDataParameter Get(object value);
        IDataParameter Get(string paramName, object value);
        IDataParameter Get(string paramName, object value, ParameterDirection direction);
        IDataParameter Get(string paramName, object value, ParameterDirection direction, DbType type);
        IDataParameter GetNew(string paramName, object value, ParameterDirection direction, SqlDbType type);
    }
}
