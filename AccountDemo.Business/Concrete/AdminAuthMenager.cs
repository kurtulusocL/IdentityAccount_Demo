using AccountDemo.Business.Abstract;
using AccountDemo.Core.DTOs.AdminAuth;
using AccountDemo.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDemo.Business.Concrete
{
    public class AdminAuthMenager : IAdminAuthService
    {
        private readonly IAdminAuthDAL _adminAuth;
        public AdminAuthMenager(IAdminAuthDAL adminAuth)
        {
            _adminAuth = adminAuth;
        }
        public void AdminChangePassword(ChangePassword model)
        {
            _adminAuth.AdminChangePassword(model);
        }

        public void AdminChangeProfile(ChangeProfile model)
        {
            _adminAuth.AdminChangeProfile(model);
        }

        public void AdminForgotPassword(ForgotPassword model)
        {
            _adminAuth.AdminForgotPassword(model);
        }

        public void AdminLogin(Login model)
        {
            _adminAuth.AdminLogin(model);
        }

        public void AdminLogout()
        {
            _adminAuth.AdminLogout();
        }

        public void AdminRegister(Register model)
        {
            _adminAuth.AdminRegister(model);
        }

        public void AdminResetPassword(ResetPassword model)
        {
            _adminAuth.AdminResetPassword(model);
        }
    }
}
