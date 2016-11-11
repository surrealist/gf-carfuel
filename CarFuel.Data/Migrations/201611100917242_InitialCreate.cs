namespace CarFuel.Data.Migrations {
  using System;
  using System.Collections.Generic;
  using System.Data.Entity.Infrastructure.Annotations;
  using System.Data.Entity.Migrations;

  public partial class InitialCreate : DbMigration {
    public override void Up() {
      CreateTable(
          "dbo.Cars",
          c => new {
            Id = c.Guid(nullable: false, identity: true),
            Make = c.String(nullable: false, maxLength: 20),
            Model = c.String(nullable: false, maxLength: 30,
                      annotations: new Dictionary<string, AnnotationValues>
                      {
                                {
                                    "AuthorName",
                                    new AnnotationValues(oldValue: null, newValue: "Suthep S")
                                },
                      }),
          })
          .PrimaryKey(t => t.Id);

      CreateTable(
          "dbo.FillUps",
          c => new {
            Id = c.Int(nullable: false, identity: true),
            IsFull = c.Boolean(nullable: false),
            Liters = c.Double(nullable: false),
            Odometer = c.Int(nullable: false),
            NextFillUp_Id = c.Int(),
            Car_Id = c.Guid(),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.FillUps", t => t.NextFillUp_Id)
          .ForeignKey("dbo.Cars", t => t.Car_Id)
          .Index(t => t.NextFillUp_Id)
          .Index(t => t.Car_Id);

    }

    public override void Down() {
      DropForeignKey("dbo.FillUps", "Car_Id", "dbo.Cars");
      DropForeignKey("dbo.FillUps", "NextFillUp_Id", "dbo.FillUps");
      DropIndex("dbo.FillUps", new[] { "Car_Id" });
      DropIndex("dbo.FillUps", new[] { "NextFillUp_Id" });
      DropTable("dbo.FillUps");
      DropTable("dbo.Cars",
          removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
          {
                    {
                        "Model",
                        new Dictionary<string, object>
                        {
                            { "AuthorName", "Suthep S" },
                        }
                    },
          });
    }
  }
}
