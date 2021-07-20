using AccountDemo.Core.Entities;
using AccountDemo.Entities.Abstract;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AccountDemo.Entities.User
{
    public class ApplicationUser : IdentityUser, IEntity, IApplicationUser
    {
        public async Task<ClaimsIdentity> GenereteUserIdentityIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public string NameLastname { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string RespondTitle { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsDeleted { get; set; }
        public void SetCreatedDate()
        {
            CreatedDate = DateTime.Now.ToLocalTime();
        }
        public void SetIsDeleted()
        {
            IsDeleted = false;
        }
        public void SetIsConfirmed()
        {
            IsConfirmed = true;
        }
        public ApplicationUser()
        {
            EmailConfirmed = true;
            PhoneNumberConfirmed = true;
            SetCreatedDate();
            SetIsConfirmed();
            SetIsDeleted();
        }
    }
}
