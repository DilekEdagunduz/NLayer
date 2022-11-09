using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        [NonAction] //Action metod olmadığını belirtme
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                };
            return new ObjectResult(response) // eğer 200 ise ObjectResult 200 dönecek
            {
                StatusCode = response.StatusCode
            };
          
        }
    }
}
