using AspStudentPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspStudentPortal.Startup))]
namespace AspStudentPortal
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
            CreateRoles();
            CreateUsers();

        }
        public void CreateUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new Admin();
            user.Email = "ibtihelmansour@gmail.com";
            user.UserName = "ibtihelmansour";
           // user.salary = 1200; 
            var check = userManager.Create(user, "123456M/pp");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admins");
            }



        }
        public void CreateRoles()
        {
            //rolemanager pour gérer les roles 
            //identityRole object of roles  
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);

            }
            if (!roleManager.RoleExists("Students"))
            {
                role = new IdentityRole();
                role.Name = "Students";
                roleManager.Create(role);

            }
            if (!roleManager.RoleExists("Instructors"))
            {
                role = new IdentityRole();
                role.Name = "Instructors";
                roleManager.Create(role);

            }

        }
    }
}
