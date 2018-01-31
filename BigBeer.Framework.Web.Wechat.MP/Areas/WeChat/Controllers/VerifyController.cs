using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;

namespace BigBeer.Framework.Web.Wechat.MP.Areas.WeChat.Controllers
{
    /// <summary>
    /// 微信验证地址(微信进行Get请求)
    /// </summary>
    public class VerifyController : BaseController
    {
        IConfiguration Config { get; }
        string Token { get { return Config["weixin_mp_token"]; } }
        string AesKey { get { return Config["weixin_mp_aeskey"]; } }
        string AppId { get { return Config["weixin_mp_appid"]; } }

        public VerifyController(IConfiguration configuration)
        {
            Config = configuration;
        }

        /// <summary>
        /// 读取配置测试
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return Content($"{Token}{AesKey}{AppId}");
        }

        /// <summary>
        /// 微信验证网站是否可访问,GET请求
        /// </summary>
        /// <param name="model">接收微信集合</param>
        /// <param name="echostr">返回的随机字符串</param>
        /// <returns></returns>
        public IActionResult Message(PostModel model, string echostr)
        {
            if (CheckSignature.Check(model.Signature, model.Timestamp, model.Nonce, Token))
                return Content(echostr);
            else
                return Content("并非微信官方请求");
        }
    }
}