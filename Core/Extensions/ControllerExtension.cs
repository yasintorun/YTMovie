using Core.Utils.Results;
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
        public static object TempData { get; private set; }

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

        public static void SetMessage(this Controller controller, IResult result)
        {
            controller.ViewBag.Status = result == null || !result.Success ? true : false;
            controller.ViewBag.Message = result.Message ?? "";
        }
    }
}
