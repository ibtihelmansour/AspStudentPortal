using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspStudentPortal.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public DateTime? dateOfbirth { get; set; }
        public string address { get; set; }
        public string gender { get; set;  }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Classe> classes { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
    
        public DbSet<SchoolBranch> schoolBranches { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<ObjFile> objfiles { get; set; }
        public DbSet<Demand> demands { get; set; }


        //public DbSet<paymentMethod> paymentMethods { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}