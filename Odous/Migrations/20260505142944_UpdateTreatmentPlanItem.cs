using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Odous.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTreatmentPlanItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "TreatmentPlanItems",
                newName: "PricePerUnit");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercent",
                table: "TreatmentPlanItems",
                type: "numeric(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTeeth",
                table: "TreatmentPlanItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "TreatmentPlanItems");

            migrationBuilder.DropColumn(
                name: "NumberOfTeeth",
                table: "TreatmentPlanItems");

            migrationBuilder.RenameColumn(
                name: "PricePerUnit",
                table: "TreatmentPlanItems",
                newName: "Discount");
        }
    }
}
