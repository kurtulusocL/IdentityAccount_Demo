using AccountDemo.Core.DTOs.AdminAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDemo.Business.Abstract
{
    public interface IAdminAuthService
    {
        void AdminLogin(Login model);
        void AdminRegister(Register model);
        void AdminChangePassword(ChangePassword model);
        void AdminForgotPassword(ForgotPassword model);
        void AdminResetPassword(ResetPassword model);
        void AdminChangeProfile(ChangeProfile model);
        void AdminLogout();
    }
}
