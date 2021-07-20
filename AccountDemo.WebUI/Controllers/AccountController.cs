using AccountDemo.Business.Abstract;
using AccountDemo.Core.DTOs.AdminAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountDemo.WebUI.Controllers
{
    public class AccountController : Controller
    {        
        private readonly IAdminAuthService _adminAuth;
        public AccountController(IAdminAuthService adminAuth)
        {
            _adminAuth = adminAuth;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            try
            {
                _adminAuth.AdminLogin(model);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Login));
            }

        }

        [Authorize(Roles = "Admin, Asistant, Helper")]
        public ActionResult Logout()
        {
            try
            {
                _adminAuth.AdminLogout();
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                return View(TempData["error"] = "Error while doing logout");
            }
        }
        
        public ActionResult Register()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _adminAuth.AdminRegister(model);
                }
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Register));
            }
        }

        [Authorize(Roles = "Admin, Asistant, Helper")]
        public ActionResult ChangeProfile()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Asistant, Helper")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeProfile(ChangeProfile model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _adminAuth.AdminChangeProfile(model);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(ChangeProfile));
            }
        }

        [Authorize(Roles = "Admin, Asistant, Helper")]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Asistant, Helper")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePassword model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _adminAuth.AdminChangePassword(model);
                }
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(ChangePassword));
            }
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPassword model)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    _adminAuth.AdminForgotPassword(model);
                }
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(ForgotPassword));
            }
        }

        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPassword model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _adminAuth.AdminResetPassword(model);
                }
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(ResetPassword));
            }
        }
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}