using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBeer.Framework.Web.Wechat.MP.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return Content("首页");
        }
    }
}
