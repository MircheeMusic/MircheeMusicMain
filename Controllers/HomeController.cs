
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MirchrrMusic.GitKit;

namespace MircheeMusic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public virtual JsonResult userStatus(string email)
        {
            string userName = Membership.GetUserNameByEmail(email);

            //if the user was switching accounts we need make sure we log out the previous user.
            Session.Abandon();
            FormsAuthentication.SignOut();

            if (userName != null)
            {
                var authUser = Membership.GetUser(userName);
                var user = new { displayName = authUser.UserName, photoUrl = "", registered = true, legacy = false };
                return Json(user);
            }
            else
            {
                var user = new { displayName = "", photoUrl = "", registered = false, legacy = false };
                return Json(user);
            }

        }

        public virtual ActionResult callback()
        {
            GitApiClient gitClient = new GitApiClient("964482664522-h7asjnmiigsvrbpuvoufuhqjvobcl16q");
            GitAssertion assertion = gitClient.Verify();
            string BaseSiteUrl = Request.Url.Scheme + "://" + Request.Url.Authority.TrimEnd('/');

            ViewBag.GitRedirectUrl = BaseSiteUrl + Url.Action("Index","Home"); // MVC.Home.Index()
            ViewBag.FederatedResponse = GitApiClient.FederatedError;

            if (!string.IsNullOrEmpty(assertion.VerifiedEmail))
            {
                var user = Membership.GetUser(assertion.VerifiedEmail);
                Session["GitAssertion"] = assertion;

                if (user == null)
                {
                    //create the new user
                    var newUser = Membership.CreateUser(assertion.VerifiedEmail, Guid.NewGuid().ToString());

                    FormsAuthentication.SetAuthCookie(newUser.UserName, true);

                    //if you wanted to collect more details before creating the user account,
                    // then specify the location of that page.
                    // ViewBag.GitRedirectUrl = BaseSiteUrl + Url.Action(MVC.Account.FederatedRegister());

                }
                else
                {
                    //you can decide how you want to manage the "remember me" boolean
                    FormsAuthentication.SetAuthCookie(user.UserName, true);

                }

                ViewBag.GitRedirectUrl = BaseSiteUrl + Url.Action("Index", "Home");

                ViewBag.FederatedResponse = GitApiClient.FederatedSuccess;
            }

            return View();
        }
    }
}