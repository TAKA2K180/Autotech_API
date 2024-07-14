using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotech.Common.Classes.Generics
{
    public class GenericFunctions
    {
        public async Task UpdateIfNullAsync<T>(object obj, string propertyName, Func<Task<T>> getEntityByIdAsync, Func<T, bool> isNull)
        {
            var property = obj.GetType().GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException($"Property {propertyName} not found on type {obj.GetType().Name}");
            }

            var entity = (T)property.GetValue(obj);

            if (isNull(entity))
            {
                var updatedEntity = await getEntityByIdAsync();
                if (updatedEntity != null)
                {
                    property.SetValue(obj, updatedEntity);
                }
            }
        }
    }
}
