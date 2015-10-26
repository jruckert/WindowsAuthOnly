using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTest.Services.Api.Web
{
    [Route("api/test")]
    public class TestController : Controller
    {
        [HttpPost("update/document")]
        public IActionResult UpdateDocumentAndStatus(IFormFile document)
        {
            try
            {
                if (document == null)
                {
                    return HttpBadRequest();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return HttpBadRequest();
            }
        }
    }
}
