using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "Image", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, null, "Description brand 1", ".//./brand1", "Brand 1", null, null },
                    { 2, null, null, "Description brand 1", ".//./brand1", "Brand 2", null, null },
                    { 3, null, null, "Description brand 1", ".//./brand1", "Brand 3", null, null },
                    { 4, null, null, "Description brand 1", ".//./brand1", "Brand 4", null, null },
                    { 5, null, null, "Description brand 1", ".//./brand1", "Brand 5", null, null }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "Name", "Position", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, null, "Description Menu 1", "Menu 1", 1, null, null },
                    { 2, null, null, "Description Menu 2", "Menu 2", 2, null, null },
                    { 3, null, null, "Description Menu 3", "Menu 3", 3, null, null },
                    { 4, null, null, "Description Menu 4", "Menu 4", 4, null, null },
                    { 5, null, null, "Description Menu 5", "Menu 5", 5, null, null },
                    { 6, null, null, "Description Menu 6", "Menu 6", 6, null, null }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "Detail", "Image", "Title", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, null, "Description Title 1", "Detail New 1", ".//./brand1", "Title 1", null, null },
                    { 2, null, null, "Description Title 2", "Detail New 2", ".//./brand1", "Title 2", null, null },
                    { 3, null, null, "Description Title 3", "Detail New 3", ".//./brand1", "Title 3", null, null },
                    { 4, null, null, "Description Title 4", "Detail New 4", ".//./brand1", "Title 4", null, null },
                    { 5, null, null, "Description Title 5", "Detail New 5", ".//./brand1", "Title 5", null, null },
                    { 6, null, null, "Description Title 6", "Detail New 6x", ".//./brand1", "Title 6", null, null }
                });

            migrationBuilder.InsertData(
                table: "OrderAddresses",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedOn", "NameCustomer", "Phone", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "Ha Nam", null, null, "Duc Le 1", "02882828", null, null },
                    { 2, "Ha Nam", null, null, "Duc Le 2", "02882828", null, null },
                    { 3, "Ha Nam", null, null, "Duc Le 3", "02882828", null, null },
                    { 4, "Ha Nam", null, null, "Duc Le 4", "02882828", null, null },
                    { 5, "Ha Nam", null, null, "Duc Le 5", "02882828", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "Icon", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, null, "Mo ta cate 1", "../../iicon1", "Name cate 1", null, null },
                    { 2, null, null, "Mo ta cate 2", "../../iicon1", "Name cate 2", null, null },
                    { 3, null, null, "Mo ta cate 3", "../../iicon1", "Name cate 3", null, null },
                    { 4, null, null, "Mo ta cate 4", "../../iicon1", "Name cate 4", null, null },
                    { 5, null, null, "Mo ta cate 5", "../../iicon1", "Name cate 5", null, null },
                    { 6, null, null, "Mo ta cate 6", "../../iicon1", "Name cate 6", null, null }
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "Image", "Link", "Title", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, null, "Descrip slider", "../..//", "./././", " Title slider", null, null },
                    { 2, null, null, "Descrip slider", "../..//", "./././", " Title slider", null, null },
                    { 3, null, null, "Descrip slider", "../..//", "./././", " Title slider", null, null },
                    { 4, null, null, "Descrip slider", "../..//", "./././", " Title slider", null, null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressId", "Code", "CreatedBy", "CreatedOn", "Quantity", "TotalAmount", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null, 30, 100.02, null, null },
                    { 2, 2, 2, null, null, 30, 200.02000000000001, null, null },
                    { 3, 4, 3, null, null, 40, 300.01999999999998, null, null },
                    { 4, 5, 4, null, null, 20, 400.01999999999998, null, null },
                    { 5, 3, 5, null, null, 10, 500.01999999999998, null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedBy", "CreatedOn", "Description", "Detail", "Image", "Name", "Price", "ProductCategoryId", "Quantity", "SalePrice", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, null, null, "An nhieu lam", "1m1", "././.cho1", "Cho 1", 100.0, 1, 10, 80.0, null, null },
                    { 2, 2, null, null, "An nhieu lam", "1m1", "././.cho1", "Cho 1", 100.0, 1, 10, 80.0, null, null },
                    { 3, 3, null, null, "An nhieu lam", "1m1", "././.cho1", "Cho 1", 100.0, 1, 10, 80.0, null, null },
                    { 4, 4, null, null, "An nhieu lam", "1m1", "././.cho1", "Cho 1", 100.0, 1, 10, 80.0, null, null },
                    { 5, 5, null, null, "An nhieu lam", "1m1", "././.cho1", "Cho 1", 100.0, 1, 10, 80.0, null, null }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId", "Id", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 100.0, 10 },
                    { 2, 2, 2, 100.0, 10 },
                    { 1, 3, 3, 100.0, 10 },
                    { 2, 4, 4, 100.0, 10 },
                    { 1, 5, 5, 100.0, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderAddresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderAddresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderAddresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderAddresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderAddresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
