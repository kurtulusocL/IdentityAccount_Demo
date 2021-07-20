using AccountDemo.Core.DataAccess;
using AccountDemo.Core.DTOs.AdminAuth;
using AccountDemo.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDemo.DataAccess.Abstract
{
    public interface IAdminAuthDAL : IEntityRepository<ApplicationUser>
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
