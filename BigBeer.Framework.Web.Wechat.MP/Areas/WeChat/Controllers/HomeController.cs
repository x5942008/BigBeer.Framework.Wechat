using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BigBeer.Framework.Web.Wechat.MP.Areas.WeChat.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return Content("微信页面");
        }
    }
}