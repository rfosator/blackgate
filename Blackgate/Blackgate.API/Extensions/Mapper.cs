using System;
using System.Linq;
using System.Reflection;

namespace Blackgate.API.Extensions
{
    public static class Mapper
    {
        private static Func<PropertyInfo, PropertyInfo, bool> comparer = 
            (s, t) => s.Name.Equals(t.Name) && s.PropertyType.Equals(t.PropertyType);

        public static void CopyTo<Ttarget, Tsource>(
            Tsource source, Ttarget target)
        {
            CopyProperties(source, target);
        }

        public static Ttarget MapTo<Ttarget, TSource>(TSource source)
        {
            if (source == null)
                return default(Ttarget);

            var instance = Activator.CreateInstance<Ttarget>();
            CopyProperties(source, instance);

            return instance;
        }

        private static void CopyProperties<Ttarget, TSource>(
            TSource source, Ttarget instance, string[] exclude = null)
        {
            var targetProps = typeof(Ttarget).GetProperties();
            var sourceProps = source.GetType().GetProperties();

            foreach (var prop in targetProps)
            {
                var property = sourceProps.FirstOrDefault(s => comparer(s, prop));
                if (property != null)
                {                        
                    var value = property.GetValue(source);
                    prop.SetValue(instance, value);
                }
            }
        }        
    }
}