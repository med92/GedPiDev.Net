namespace GedPiDev.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courriers",
                c => new
                    {
                        CourrierId = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Sense = c.Boolean(nullable: false),
                        Etat = c.Boolean(nullable: false),
                        TypeCourrier = c.String(unicode: false),
                        ObjetCourrier = c.String(unicode: false),
                        Detail = c.String(unicode: false),
                        CorrespondentId = c.String(maxLength: 80, storeType: "nvarchar"),
                        sender = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CourrierId)
                .ForeignKey("dbo.Correspondents", t => t.CorrespondentId)
                .Index(t => t.CorrespondentId);
            
            CreateTable(
                "dbo.Attachements",
                c => new
                    {
                        AttachementId = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        NomFichier = c.String(unicode: false),
                        UrlFichier = c.String(unicode: false),
                        CourrierId = c.String(maxLength: 80, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.AttachementId)
                .ForeignKey("dbo.Courriers", t => t.CourrierId)
                .Index(t => t.CourrierId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        NomDocument = c.String(unicode: false),
                        Etat = c.Boolean(nullable: false),
                        CurrentStat = c.Int(nullable: false),
                        DateCreation = c.String(unicode: false),
                        WorkflowId = c.String(unicode: false),
                        CreationUser = c.String(unicode: false),
                        UdateUser = c.String(unicode: false),
                        UpdateDate = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Attachements", t => t.DocumentId)
                .Index(t => t.DocumentId);
            
            CreateTable(
                "dbo.Correspondents",
                c => new
                    {
                        CorrespondentId = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        NomCorrespondant = c.String(unicode: false),
                        Telephone = c.Int(nullable: false),
                        Email = c.String(unicode: false),
                        Fax = c.Int(nullable: false),
                        userId = c.String(unicode: false),
                        AdresseId = c.String(unicode: false),
                        Pays = c.String(unicode: false),
                        Ville = c.String(unicode: false),
                        CodePostal = c.Int(nullable: false),
                        Rue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CorrespondentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartementId = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        NomDepartement = c.String(unicode: false),
                        Responsable = c.String(unicode: false),
                        Telephone = c.Int(nullable: false),
                        Email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.DepartementId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        DepartmentId = c.Int(),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Email = c.String(maxLength: 80, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        department_DepartementId = c.String(maxLength: 80, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.department_DepartementId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.department_DepartementId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Workflows",
                c => new
                    {
                        WorkflowId = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.WorkflowId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.WorkflowDepartments",
                c => new
                    {
                        Workflow_WorkflowId = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Department_DepartementId = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.Workflow_WorkflowId, t.Department_DepartementId })
                .ForeignKey("dbo.Workflows", t => t.Workflow_WorkflowId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartementId, cascadeDelete: true)
                .Index(t => t.Workflow_WorkflowId)
                .Index(t => t.Department_DepartementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.WorkflowDepartments", "Department_DepartementId", "dbo.Departments");
            DropForeignKey("dbo.WorkflowDepartments", "Workflow_WorkflowId", "dbo.Workflows");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "department_DepartementId", "dbo.Departments");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courriers", "CorrespondentId", "dbo.Correspondents");
            DropForeignKey("dbo.Documents", "DocumentId", "dbo.Attachements");
            DropForeignKey("dbo.Attachements", "CourrierId", "dbo.Courriers");
            DropIndex("dbo.WorkflowDepartments", new[] { "Department_DepartementId" });
            DropIndex("dbo.WorkflowDepartments", new[] { "Workflow_WorkflowId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "department_DepartementId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Documents", new[] { "DocumentId" });
            DropIndex("dbo.Attachements", new[] { "CourrierId" });
            DropIndex("dbo.Courriers", new[] { "CorrespondentId" });
            DropTable("dbo.WorkflowDepartments");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Workflows");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Departments");
            DropTable("dbo.Correspondents");
            DropTable("dbo.Documents");
            DropTable("dbo.Attachements");
            DropTable("dbo.Courriers");
        }
    }
}
