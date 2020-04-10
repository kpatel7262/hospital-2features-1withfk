using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Hospitalproject.Models;

namespace Hospitalproject.Data
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class HospitalContext : IdentityDbContext<ApplicationUser>
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public HospitalContext() : base("name=HospitalContext")
        {
        }
        public static HospitalContext Create()
        {
            return new HospitalContext();
        }

        public System.Data.Entity.DbSet<Hospitalproject.Models.Doctor> Doctors { get; set; }

        public System.Data.Entity.DbSet<Hospitalproject.Models.Speciality> Specialities { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }

        /*Krishna's features*/
        public DbSet<HomeRemedies> HomeRemedies { get; set; }

        public DbSet<RemedySource> RemedySource { get; set; }
        public DbSet<SocialServiceClubs> SocialServiceClubs { get; set; }
        public DbSet<AreaServed> AreaServed { get; set; }

    }
}