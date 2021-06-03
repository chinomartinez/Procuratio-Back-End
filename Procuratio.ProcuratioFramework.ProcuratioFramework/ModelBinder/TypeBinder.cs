using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder
{
    public class TypeBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string PropertyName = bindingContext.ModelName;
            ValueProviderResult value = bindingContext.ValueProvider.GetValue(PropertyName);

            if (value == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            try
            {
                var DeserializedValue = JsonConvert.DeserializeObject<T>(value.FirstValue);
                bindingContext.Result = ModelBindingResult.Success(DeserializedValue);
            }
            catch (Exception)
            {
                bindingContext.ModelState.TryAddModelError(PropertyName, "El valor dado no es del tipo adecuado");
            }

            return Task.CompletedTask;
        }
    }
}
