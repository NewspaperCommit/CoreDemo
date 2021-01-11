using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace NewspaperArchive.Infrastructure.Persistence
{
    public static class DataRecordExtensions
    {
        private static readonly ConcurrentDictionary<Type, object> Materializers = new ConcurrentDictionary<Type, object>();
        public static IList<T> Translate<T>(this DbDataReader reader) where T : new()
        {
            var materializer = (Func<IDataRecord, T>)Materializers.GetOrAdd(typeof(T), (Func<IDataRecord, T>)Materializer.Materialize<T>);
            return Translate(reader, materializer);
        }
        public static T TranslateSingle<T>(this DbDataReader reader) where T : new()
        {
            var materializer = (Func<IDataRecord, T>)Materializers.GetOrAdd(typeof(T), (Func<IDataRecord, T>)Materializer.Materialize<T>);
            return TranslateSingle(reader, materializer);
        }
        public static T TranslateMulti<T>(this DbDataReader reader) where T : new()
        {
            var materializer = (Func<IDataRecord, PropertyInfo, object>)Materializers.GetOrAdd(typeof(object), (Func<IDataRecord, PropertyInfo, object>)Materializer.Materialize<object>);
            return TranslateMulti<T>(reader, materializer);
        }
        private static T TranslateSingle<T>(this DbDataReader reader, Func<IDataRecord, T> objectMaterializer
             ) where T : new()
        {
            var results = new T();
            while (reader.Read())
            {
                var record = (IDataRecord)reader;
                results = objectMaterializer(record);
            }
            return results;
        }
        private static IList<T> Translate<T>(this DbDataReader reader, Func<IDataRecord, T> objectMaterializer
             ) where T : new()
        {
            var results = new List<T>();
            while (reader.Read())
            {
                var record = (IDataRecord)reader;
                var obj = objectMaterializer(record);
                results.Add(obj);
            }
            return results;
        }

        private static T TranslateMulti<T>(this DbDataReader reader, Func<IDataRecord, PropertyInfo, object> objectMaterializer
            ) where T : new()
        {
            var results = new T();
            foreach (var pro in typeof(T).GetProperties())
            {
                IList objList = null;
                if (!pro.PropertyType.IsValueType && pro.GetGetMethod().ReturnType.IsGenericType)
                    objList = (IList)Activator.CreateInstance(pro.PropertyType);

                while (reader.Read())
                {
                    var record = (IDataRecord)reader;
                    if (!pro.PropertyType.IsValueType && pro.GetGetMethod().ReturnType.IsGenericType)
                        objList.Add(objectMaterializer(record, pro));
                    else
                    {
                        var obj = objectMaterializer(record, pro);
                        pro.SetValue(results, obj);
                    }
                }
                if (!pro.PropertyType.IsValueType && pro.GetGetMethod().ReturnType.IsGenericType && objList.Count > 0)
                    pro.SetValue(results, objList);
                reader.NextResult();
            }
            return results;
        }
    }
}
