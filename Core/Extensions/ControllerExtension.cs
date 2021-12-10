using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Extensions
{
    public static class ControllerExtension
    {
        public static bool Validate<T>(this Controller controller, AbstractValidator<T> rules, T t)
        {
            ValidationResult results = rules.Validate(t);
            if (results.IsValid)
            {
                return true;
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    controller.ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return false;
            }
        }
    }
}
