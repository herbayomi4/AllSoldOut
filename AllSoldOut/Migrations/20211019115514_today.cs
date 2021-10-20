﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllSoldOut.Migrations
{
    public partial class today : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    guid = table.Column<string>(nullable: false),
                    productId = table.Column<int>(nullable: false),
                    productName = table.Column<string>(nullable: true),
                    productImageName = table.Column<string>(nullable: true),
                    productPrice = table.Column<decimal>(nullable: false),
                    quantity = table.Column<decimal>(nullable: false),
                    total = table.Column<decimal>(nullable: false)
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salesId = table.Column<int>(nullable: false),
                    firstName = table.Column<string>(maxLength: 50, nullable: false),
                    lastName = table.Column<string>(maxLength: 50, nullable: false),
                    email = table.Column<string>(nullable: true),
                    contact = table.Column<string>(maxLength: 11, nullable: true),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    available = table.Column<bool>(nullable: false),
                    productCategory = table.Column<string>(nullable: true),
                    productName = table.Column<string>(maxLength: 50, nullable: false),
                    productPrice = table.Column<decimal>(nullable: false),
                    productColor = table.Column<string>(nullable: true),
                    productDescription = table.Column<string>(maxLength: 150, nullable: false),
                    productImageName = table.Column<string>(nullable: true),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    inStock = table.Column<int>(nullable: true),
                    quantityAvailable = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    roleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    salesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(nullable: false),
                    salesDate = table.Column<DateTime>(nullable: false),
                    unitPrice = table.Column<decimal>(nullable: false),
                    quantity = table.Column<decimal>(nullable: false),
                    salesPrice = table.Column<decimal>(nullable: false),
                    paymentPlatform = table.Column<string>(nullable: true),
                    customerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.salesId);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    launchDate = table.Column<DateTime>(nullable: false),
                    bodyDimension = table.Column<string>(nullable: true),
                    bodyWeight = table.Column<string>(nullable: true),
                    displayResolution = table.Column<string>(nullable: true),
                    displaySize = table.Column<double>(nullable: false),
                    platformOS = table.Column<string>(nullable: true),
                    ram = table.Column<double>(nullable: false),
                    internalMemory = table.Column<double>(nullable: false),
                    camera = table.Column<double>(nullable: false),
                    batteryStandbyTime = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    roleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "cartItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(nullable: false),
                    CartId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_cartItems_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneCreateViewModel",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productsproductId = table.Column<int>(nullable: true),
                    specificationsproductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneCreateViewModel", x => x.productId);
                    table.ForeignKey(
                        name: "FK_PhoneCreateViewModel_products_productsproductId",
                        column: x => x.productsproductId,
                        principalTable: "products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneCreateViewModel_Specifications_specificationsproductId",
                        column: x => x.specificationsproductId,
                        principalTable: "Specifications",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneListViewModel",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productsproductId = table.Column<int>(nullable: true),
                    specificationsproductId = table.Column<int>(nullable: true),
                    cartsguid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneListViewModel", x => x.productId);
                    table.ForeignKey(
                        name: "FK_PhoneListViewModel_carts_cartsguid",
                        column: x => x.cartsguid,
                        principalTable: "carts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneListViewModel_products_productsproductId",
                        column: x => x.productsproductId,
                        principalTable: "products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneListViewModel_Specifications_specificationsproductId",
                        column: x => x.specificationsproductId,
                        principalTable: "Specifications",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutViewModel",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerId = table.Column<int>(nullable: true),
                    cartguid = table.Column<string>(nullable: true),
                    userId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutViewModel", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_CheckoutViewModel_carts_cartguid",
                        column: x => x.cartguid,
                        principalTable: "carts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckoutViewModel_customers_customerId",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckoutViewModel_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "phoneMakers",
                columns: table => new
                {
                    makerName = table.Column<string>(nullable: false),
                    makerId = table.Column<int>(nullable: false),
                    makerCategory = table.Column<string>(nullable: true),
                    PhoneCreateViewModelproductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phoneMakers", x => x.makerName);
                    table.ForeignKey(
                        name: "FK_phoneMakers_PhoneCreateViewModel_PhoneCreateViewModelproductId",
                        column: x => x.PhoneCreateViewModelproductId,
                        principalTable: "PhoneCreateViewModel",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "phoneMakers",
                columns: new[] { "makerName", "PhoneCreateViewModelproductId", "makerCategory", "makerId" },
                values: new object[,]
                {
                    { "Apple", null, "Iphone", 1 },
                    { "Samsung", null, "Android", 2 },
                    { "Tecno", null, "Android", 3 },
                    { "Infinix", null, "Android", 4 },
                    { "Itel", null, "Android", 5 },
                    { "Nokia", null, "Android", 6 }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "roleId", "roleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Customer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_ProductId",
                table: "cartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutViewModel_cartguid",
                table: "CheckoutViewModel",
                column: "cartguid");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutViewModel_customerId",
                table: "CheckoutViewModel",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutViewModel_userId",
                table: "CheckoutViewModel",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCreateViewModel_productsproductId",
                table: "PhoneCreateViewModel",
                column: "productsproductId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCreateViewModel_specificationsproductId",
                table: "PhoneCreateViewModel",
                column: "specificationsproductId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneListViewModel_cartsguid",
                table: "PhoneListViewModel",
                column: "cartsguid");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneListViewModel_productsproductId",
                table: "PhoneListViewModel",
                column: "productsproductId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneListViewModel_specificationsproductId",
                table: "PhoneListViewModel",
                column: "specificationsproductId");

            migrationBuilder.CreateIndex(
                name: "IX_phoneMakers_PhoneCreateViewModelproductId",
                table: "phoneMakers",
                column: "PhoneCreateViewModelproductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartItems");

            migrationBuilder.DropTable(
                name: "CheckoutViewModel");

            migrationBuilder.DropTable(
                name: "PhoneListViewModel");

            migrationBuilder.DropTable(
                name: "phoneMakers");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "PhoneCreateViewModel");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "Specifications");
        }
    }
}
