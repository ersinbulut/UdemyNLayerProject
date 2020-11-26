using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Web.ApiService;
using UdemyNLayerProject.Web.DTOs;


namespace UdemyNLayerProject.Web.Filters
{

    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly CategoryApiService _categoryApiService;

        public NotFoundFilter(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context,
        ActionExecutionDelegate next)
        {
            int Id =(int) context.ActionArguments.Values.FirstOrDefault();
            var product = await _categoryApiService.GetByIdAsync(Id);
            if (product!=null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Errors.Add($"id'si {Id} olan kategori veritabanında bulunamadı");
                context.Result = new RedirectToActionResult("Error", "Home", errorDto);            }
        }



    }
}
