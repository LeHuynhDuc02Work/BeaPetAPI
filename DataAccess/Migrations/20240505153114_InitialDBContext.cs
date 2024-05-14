using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    SalePrice = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedOn", "NameCustomer", "Phone", "UpdatedBy", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { 1, "Ha Nam", null, null, "Duc Le 1", "02882828", null, null, null },
                    { 2, "Ha Nam", null, null, "Duc Le 2", "02882828", null, null, null },
                    { 3, "Ha Nam", null, null, "Duc Le 3", "02882828", null, null, null },
                    { 4, "Ha Nam", null, null, "Duc Le 4", "02882828", null, null, null },
                    { 5, "Ha Nam", null, null, "Duc Le 5", "02882828", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 100.0, 1, 10 },
                    { 2, 2, 100.0, 2, 10 },
                    { 3, 1, 100.0, 3, 10 },
                    { 4, 2, 100.0, 4, 10 },
                    { 5, 1, 100.0, 5, 10 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressId", "Code", "CreatedBy", "CreatedOn", "PaymentMethodId", "Quantity", "Status", "TotalAmount", "UpdatedBy", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null, null, 30, null, 100.02, null, null, null },
                    { 2, 2, 2, null, null, null, 30, null, 200.02000000000001, null, null, null },
                    { 3, 4, 3, null, null, null, 40, null, 300.01999999999998, null, null, null },
                    { 4, 5, 4, null, null, null, 20, null, 400.01999999999998, null, null, null },
                    { 5, 3, 5, null, null, null, 10, null, 500.01999999999998, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "Icon", "Name", "Quantity", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, null, "Mo ta cate 1", "../../iicon1", "Name cate 1", 0, null, null },
                    { 2, null, null, "Mo ta cate 2", "../../iicon1", "Name cate 2", 0, null, null },
                    { 3, null, null, "Mo ta cate 3", "../../iicon1", "Name cate 3", 0, null, null },
                    { 4, null, null, "Mo ta cate 4", "../../iicon1", "Name cate 4", 0, null, null },
                    { 5, null, null, "Mo ta cate 5", "../../iicon1", "Name cate 5", 0, null, null },
                    { 6, null, null, "Mo ta cate 6", "../../iicon1", "Name cate 6", 0, null, null }
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
                table: "Sliders",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "Image", "Link", "Title", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, null, "Descrip slider", "../..//", "./././", " Title slider", null, null },
                    { 2, null, null, "Descrip slider", "../..//", "./././", " Title slider", null, null },
                    { 3, null, null, "Descrip slider", "../..//", "./././", " Title slider", null, null },
                    { 4, null, null, "Descrip slider", "../..//", "./././", " Title slider", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "OrderAddresses");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShopCarts");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
