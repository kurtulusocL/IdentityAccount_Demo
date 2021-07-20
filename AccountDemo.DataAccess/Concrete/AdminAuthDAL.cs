using AccountDemo.Core.DataAccess.EntityFramework;
using AccountDemo.Core.DTOs.AdminAuth;
using AccountDemo.Core.Identity.Microsoft;
using AccountDemo.DataAccess.Abstract;
using AccountDemo.DataAccess.Context;
using AccountDemo.Entities.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using System.Security.Claims;
using System.Web.Mvc;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Mail;
using System.Net;
using System.Web.Routing;

namespace AccountDemo.DataAccess.Concrete
{
    public class AdminAuthDAL : EfEntityBaseRepository<ApplicationUser, ApplicationDbContext>, IAdminAuthDAL
    {
        private UserManager<ApplicationUser> userManager;
        //private RoleManager<ApplicationRole> roleManager;
        public AdminAuthDAL()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            //roleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        public void AdminChangePassword(ChangePassword model)
        {
            IdentityUser user = userManager.FindByName(HttpContext.Current.User.Identity.Name);
            IdentityResult result = userManager.ChangePassword(user.Id, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                authenticationManager.SignOut();
            }
        }

        public void AdminChangeProfile(ChangeProfile model)
        {
            ApplicationUser user = userManager.FindByName(HttpContext.Current.User.Identity.Name);

            user.UserName = model.Username;
            user.RespondTitle = model.RespondTitle;
            user.Country = model.Country;
            user.Province = model.Province;
            user.City = model.City;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.UpdatedDate = model.UpdatedDate;
            user.IsConfirmed = model.IsConfirm;

            userManager.Update(user);
        }

        public void AdminForgotPassword(ForgotPassword model)
        {
            var user = userManager.FindByEmail(model.Email);
            if (user != null || !(userManager.IsEmailConfirmed(user.Id)))
            {
                var provider = new DpapiDataProtectionProvider("AccountDemo.WebUI");
                userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));
                var code = userManager.GeneratePasswordResetToken(user.Id);

                var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                var callbackUrl = urlHelper.Action("ResetPassword", "Account", new { UserId = user.Id, code = code });

                SmtpClient client = new SmtpClient("smtp.yandex.com.tr", 587);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("kurtulusocal@yandex.com", "www.website.com");
                mail.Priority = MailPriority.High;
                mail.Subject = "Forgot to My Password";
                mail.To.Add(new MailAddress(model.Email, ""));
                mail.Body = "Reset Password" + " " + "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>";
                mail.IsBodyHtml = true;

                NetworkCredential enter = new NetworkCredential("kurtulusocal@yandex.com", "wyhosanqytpqiucv");
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = enter;
                client.Send(mail);
            }
        }

        public void AdminLogin(Login model)
        {
            ApplicationUser user = userManager.Find(model.Username, model.Password);
            if (user != null)
            {
                if (user.IsConfirmed == true)
                {
                    var username = user.UserName;
                    IAuthenticationManager authManager = HttpContext.Current.GetOwinContext().Authentication;
                    ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    AuthenticationProperties authProps = new AuthenticationProperties();
                    authProps.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProps, identity);
                }
            }
        }

        public void AdminLogout()
        {
            IAuthenticationManager authManager = HttpContext.Current.GetOwinContext().Authentication;
            authManager.SignOut();
        }

        public void AdminRegister(Register model)
        {
            ApplicationUser user = new ApplicationUser();

            user.UserName = model.Username;
            user.NameLastname = model.NameSurname;
            user.Email = model.Email;
            user.Birthdate = model.Birthdate;
            user.City = model.City;
            user.Country = model.Country;
            user.Gender = model.Gender;
            user.PhoneNumber = model.PhoneNumber;
            user.CreatedDate = model.CreatedDate.ToLocalTime();
            user.Province = model.Province;
            user.RespondTitle = model.RespondTitle;

            IdentityResult iResult = userManager.Create(user, model.Password);
            if (iResult.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admin");
            }
        }

        public void AdminResetPassword(ResetPassword model)
        {
            ApplicationUser user = new ApplicationUser();
            user = userManager.FindByEmail(model.Email);
            if (user != null)
            {
                var provider = new DpapiDataProtectionProvider("AccountDemo.WebUI");
                userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));
                userManager.ResetPassword(user.Id, model.Code, model.Password);
            }
        }
    }
}
