using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VVShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Product(Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                                 "Values('Caderno', 7.55, 'Caderno', 10, 'caderno.jpg', 1)");

            migrationBuilder.Sql("Insert into Product(Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                                 "Values('Caneta', 1.25, 'Caneta azul', 50, 'caneta.jpg', 1)");

            migrationBuilder.Sql("Insert into Product(Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                                 "Values('Lápis', 0.75, 'Lápis preto', 100, 'lapis.jpg', 1)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete fom Products");
        }
    }
}
