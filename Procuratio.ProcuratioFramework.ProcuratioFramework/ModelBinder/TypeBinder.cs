using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder
{
    public class TypeBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string PropertyName = bindingContext.ModelName;
            ValueProviderResult value = bindingContext.ValueProvider.GetValue(PropertyName);

            if (value == ValueProviderResult.None) { return Task.CompletedTask; }

            try
            {
                var DeserializedValue = JsonConvert.DeserializeObject<T>(value.FirstValue);
                bindingContext.Result = ModelBindingResult.Success(DeserializedValue);
            }
            catch (Exception e)
            {
                bindingContext.ModelState.TryAddModelError(PropertyName, $"Value type not found. Message error: {e.Message}");
            }

            return Task.CompletedTask;
        }
    }
}
