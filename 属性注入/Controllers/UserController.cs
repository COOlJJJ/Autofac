using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace 属性注入.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [AutowiredProperty]
        private IUserService userService { get; set; }


        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            string name = userService.GetUserName();
            return Content(name);
        }
    }
}
