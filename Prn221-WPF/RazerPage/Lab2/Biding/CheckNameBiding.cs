using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lab2.Biding
{
    public class CheckNameBiding : IModelBinder
    {

        private readonly ILogger<CheckNameBiding> _logger;

        public CheckNameBiding(ILogger<CheckNameBiding> logger)
        {
            this._logger = logger;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));

            }
            //Get model
            string modelName = bindingContext.ModelName;
            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            //Set modelState for the value binding
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            string value = valueProviderResult.FirstValue;
            if (String.IsNullOrEmpty(value)) { return Task.CompletedTask; }

            var s = value.ToUpper();
            if (value.ToUpper().Contains("XXX"))
            {
                bindingContext.ModelState.TryAddModelError(
                    modelName, "Cannot contain this pattern xxx");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(s.Trim());
            return Task.CompletedTask;
        }
    }
}
