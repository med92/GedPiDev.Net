namespace GedPiDev.Data.Migrations
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GedPiDev.Data.GedPiDevContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GedPiDev.Data.GedPiDevContext context)
        {
            this.AddUserAndRoles();
        }
        bool AddUserAndRoles()
        {
            bool success = false;

            var idManager = new IdentityManager();
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;

            success = idManager.CreateRole("canEdit");
            if (!success == true) return success;

            success = idManager.CreateRole("user");
            if (!success) return success;

            success = idManager.CreateRole("canAdd");
            if (!success) return success;


            var NefziUser = new ApplicationUser()
            {
                UserName = "MedNefzi",
                FirstName = "Med",
                LastName = "Nefzi",
                Email = "med.Nefzi@gmail.com"
            };
            var OnsUser = new ApplicationUser()
            {
                UserName = "Ons",
                FirstName = "Ons",
                LastName = "Mechergui",
                Email = "mercherguions@gmail.com"
            };
            var MehdiUser = new ApplicationUser()
            {
                UserName = "Mehdi",
                FirstName = "Medhi",
                LastName = "Med",
                Email = "med.mehdi@gmail.com"
            };
            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            success = idManager.CreateUser(NefziUser, "esprit");
            if (!success) return success;

            success = idManager.AddUserToRole(NefziUser.Id, "Admin");
            if (!success) return success;

            success = idManager.AddUserToRole(NefziUser.Id, "CanEdit");
            if (!success) return success;

            success = idManager.AddUserToRole(NefziUser.Id, "User");
            if (!success) return success;
            ///ONS
            success = idManager.CreateUser(OnsUser, "ons123");
            if (!success) return success;

            success = idManager.AddUserToRole(OnsUser.Id, "Admin");
            if (!success) return success;

            success = idManager.AddUserToRole(OnsUser.Id, "CanEdit");
            if (!success) return success;

            success = idManager.AddUserToRole(OnsUser.Id, "User");
            if (!success) return success;
            //Mehdi
            success = idManager.CreateUser(MehdiUser, "mehdi123");
            if (!success) return success;

            success = idManager.AddUserToRole(MehdiUser.Id, "Admin");
            if (!success) return success;

            success = idManager.AddUserToRole(MehdiUser.Id, "CanEdit");
            if (!success) return success;

            success = idManager.AddUserToRole(MehdiUser.Id, "User");
            if (!success) return success;
            return success;
        }
    }
}
