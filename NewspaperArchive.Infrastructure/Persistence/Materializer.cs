using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NewspaperArchive.Infrastructure.Persistence
{
    public static class Materializer
    {
        public static T Materialize<T>(IDataRecord record) where T : new()
        {
            var t = new T();
            Type type = typeof(T);
            if (!type.IsValueType)
                BindDataWithProperties(record, t, type);
            else
                t = (T)record[0];
            return t;
        }
        public static T Materialize<T>(IDataRecord record, PropertyInfo pro) where T : new()
        {
            T t;
            if (!pro.PropertyType.IsValueType)
            {
                if (pro.GetGetMethod().ReturnType.IsGenericType)
                    t = (T)Activator.CreateInstance(pro.PropertyType.GetGenericArguments().FirstOrDefault());
                else
                    t = (T)Activator.CreateInstance(pro.PropertyType);
                Type type = t.GetType();
                BindDataWithProperties(record, t, type);
            }
            else
                t = (T)record[0];
            return t;
        }
        private static void BindDataWithProperties<T>(IDataRecord record, T t, Type type) where T : new()
        {
            foreach (var prop in type.GetProperties())
            {
                // 1). If entity reference, bypass it.
                if (prop.PropertyType.Namespace == type.Namespace)
                {
                    continue;
                }
                // 2). If collection, bypass it.
                if (prop.PropertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                {
                    continue;
                }
                // 3). If property is NotMapped, bypass it.
                if (Attribute.IsDefined(prop, typeof(NotMappedAttribute)))
                {
                    continue;
                }
                if (prop.GetGetMethod().IsVirtual)
                {
                    continue;
                }
                try
                {
                    var dbValue1 = record[prop.Name];
                    if (dbValue1 is DBNull) continue;
                }
                catch (Exception ex)
                {
                    continue;
                }

                var dbValue = record[prop.Name];
                if (dbValue is DBNull) continue;
                if (prop.PropertyType.IsConstructedGenericType &&
                    prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    var baseType = prop.PropertyType.GetGenericArguments()[0];
                    var baseValue = Convert.ChangeType(dbValue, baseType);
                    var value = Activator.CreateInstance(prop.PropertyType, baseValue);
                    prop.SetValue(t, value);
                }
                else
                {
                    var value = Convert.ChangeType(dbValue, prop.PropertyType);
                    prop.SetValue(t, value);
                }
            }
        }
    }
}
