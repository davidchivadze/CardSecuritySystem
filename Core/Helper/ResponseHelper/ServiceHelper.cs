using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace Core.Helpers
{
    public class ServiceHelper
    {
             

        protected ValidationResult Validate<TRequest>(TRequest request) where TRequest : class, new()
        {
            var validatorAttribute = typeof(TRequest).GetTypeInfo().GetCustomAttribute<ValidatorAttribute>(true);
            if (validatorAttribute != null)
            {
                AbstractValidator<TRequest> instance = (AbstractValidator<TRequest>)Activator.CreateInstance(validatorAttribute.ValidatorType);
                var modelState = instance.Validate(request ?? new TRequest());
                return modelState;
            }
            return new ValidationResult();
        }

        protected IResponse<TResponse> Fail<TResponse>(params string[] errorMessages)
        {
            var result = new AppServiceResponse<TResponse>();

            result.Ok = false;
            if (errorMessages != null)
            {
                result.Errors = errorMessages;
            }

            return result;
        }

        protected IResponse<TResponse> Fail<TResponse>(ValidationResult validationResult)
        {
            var result = new AppServiceResponse<TResponse>
            {
                Ok = false,
                Errors = validationResult.Errors.Select(error => error.ErrorMessage)
            };

            return result;
        }

        protected IResponse<TResponse> Ok<TResponse>(TResponse data)
        {
            var result = new AppServiceResponse<TResponse>
            {
                Data = data,
                Ok = true
            };

            return result;
        }
    }

}