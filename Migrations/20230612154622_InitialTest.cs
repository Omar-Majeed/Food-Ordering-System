using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Ordering_Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
            //        Email = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
            //        Password = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
            //        Phone = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Customer__3214EC07869F2465", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
