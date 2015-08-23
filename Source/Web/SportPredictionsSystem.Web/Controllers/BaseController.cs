namespace SportPredictionsSystem.Web.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using SportPredictionsSystem.Common.Constants;
    using SportPredictionsSystem.Common.Models;
    using SportPredictionsSystem.Data;
    using SportPredictionsSystem.Data.Models;

    public class BaseController : Controller
    {
        protected BaseController(ISportPredictionsSystemData data)
        {
            this.Data = data;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User != null)
            {
                // Work with data before BeginExecute to prevent "NotSupportedException: A second operation started on this 
                // context before a previous asynchronous operation completed."
                this.UserProfile = this.Data.Users.All().Where(x => x.UserName == requestContext.HttpContext.User.Identity.Name);

                this.SetUserUiCulture(requestContext);
            }

            if (!requestContext.HttpContext.Request.IsAjaxRequest())
            {
                // Gets the current language for the language dropdown in the main nav
                this.ViewBag.UserLang = this.GetCurrentLanguage();
            }

            var result = base.BeginExecute(requestContext, callback, state);
            return result;
        }

        protected ISportPredictionsSystemData Data { get; set; }

        protected IQueryable<User> UserProfile { get; set; }

        protected SiteLanguage GetCurrentLanguage()
        {
            if (Thread.CurrentThread.CurrentUICulture.ThreeLetterISOLanguageName == GlobalConstants.ThreeLetterIsoBulgarianLanguageName)
            {
                return SiteLanguage.Bulgarian;
            }

            return SiteLanguage.English;
        }

        private void SetUserUiCulture(RequestContext requestContext)
        {
            if (this.UserProfile != null &&
                requestContext.HttpContext.Request.Cookies[GlobalConstants.LanguageCookieName] == null)
            {
                var acceptLanguageHeader = requestContext.HttpContext.Request.Headers["Accept-Language"];
                var preferedLanguage = this.GetPreferedLanguage(acceptLanguageHeader);
                if (preferedLanguage == GlobalConstants.BulgarianCultureInfoName || preferedLanguage == GlobalConstants.BulgarianCultureCookieValue)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(GlobalConstants.BulgarianCultureInfoName);
                    this.SetLanguageCookie(requestContext, GlobalConstants.BulgarianCultureCookieValue);
                    return;
                }

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(GlobalConstants.EnglishCultureInfoName);
                this.SetLanguageCookie(requestContext, GlobalConstants.EnglishCultureCookieValue);
                return;
            }

            this.SetUiCultureFromCookie(requestContext);
        }

        private void SetUiCultureFromCookie(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Cookies[GlobalConstants.LanguageCookieName] != null &&
                requestContext.HttpContext.Request.Cookies[GlobalConstants.LanguageCookieName].Value == GlobalConstants.EnglishCultureCookieValue)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(GlobalConstants.EnglishCultureInfoName);
                this.SetLanguageCookie(requestContext, GlobalConstants.EnglishCultureCookieValue);
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(GlobalConstants.BulgarianCultureInfoName);
                this.SetLanguageCookie(requestContext, GlobalConstants.BulgarianCultureCookieValue);
            }
        }

        private void SetLanguageCookie(RequestContext requestContext, string language)
        {
            var languageCookie = new HttpCookie(GlobalConstants.LanguageCookieName, language);
            requestContext.HttpContext.Response.SetCookie(languageCookie);
        }

        private string GetPreferedLanguage(string acceptLanguageHeader)
        {
            var preferedLanguage = acceptLanguageHeader.Split(',')[0];
            return preferedLanguage;
        }
    }
}