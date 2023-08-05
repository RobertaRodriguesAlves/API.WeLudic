using System.Collections.Concurrent;
using FluentValidation;
using FluentValidation.Results;

namespace WeLudic.Application;

public static class LazyValidator
{
    private static readonly ConcurrentDictionary<string, Lazy<IValidator>> Cache = new();

    public static async Task<ValidationResult> ValidateAsync<TValidator>(object instanceToValidate)
        where TValidator : IValidator
    {
        var context = new ValidationContext<object>(instanceToValidate);
        var lazyValidator = CreateOrGetValidatorInstance<TValidator>();
        return await lazyValidator.Value.ValidateAsync(context);
    }


    private static Lazy<IValidator> CreateOrGetValidatorInstance<TValidator>() where TValidator : IValidator
    {
        var lazyValidator = new Lazy<IValidator>(() =>
            Activator.CreateInstance<TValidator>(), LazyThreadSafetyMode.ExecutionAndPublication);

        return Cache.GetOrAdd(typeof(TValidator).Name, _ => lazyValidator);
    }
}
