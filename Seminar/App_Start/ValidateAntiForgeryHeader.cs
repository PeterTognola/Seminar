using System;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Seminar
{
    public class ValidateAntiForgeryHeader : FilterAttribute, IAuthorizationFilter
    {
        private const string KeyName = "__RequestVerificationToken";

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var clientToken = filterContext.RequestContext.HttpContext.Request.Headers.Get(KeyName);
            if (clientToken == null) throw new HttpAntiForgeryException(String.Format("Header does not contain {0}", KeyName));

            var serverToken = filterContext.HttpContext.Request.Cookies.Get(KeyName).Value;
            if (serverToken == null) throw new HttpAntiForgeryException(String.Format("Cookies does not contain {0}", KeyName));

            AntiForgery.Validate(serverToken, clientToken);
        }
    }
}