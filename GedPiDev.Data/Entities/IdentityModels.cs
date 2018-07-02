using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace GedPiDev.Data.Entities
{
    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        [Key]
        public override string UserId { get; set; }
    }
    public class ApplicationUserClaim : IdentityUserClaim<string> { }
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        [Key]
        [Column(Order = 1)]
        public override string UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public override string RoleId { get; set; }

    }


    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<string, ApplicationUserLogin,
    ApplicationUserRole, ApplicationUserClaim>
    {
        //Constructeur
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        //Costum Properties
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Cin { get; set; }
        public string Adresse { get; set; }

        public string DateNaissance { get; set; }
        public string DateEmbauche { get; set; }

        //Foreign Key
        [ForeignKey("Departement")]
        public string DepartementId { get; set; }

        //Navigation properties
        public virtual Department Departement { get; set; }


        public async Task<ClaimsIdentity>
    GenerateUserIdentityAsync(ApplicationUserManager manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined 
            // in CookieAuthenticationOptions.AuthenticationType
            var userIdentity =
                await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole<string, ApplicationUserRole>
    {
        public ApplicationRole()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }

        // Add any custom Role properties/code here
    }

}