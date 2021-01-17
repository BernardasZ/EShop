using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModel.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coupon",
                columns: table => new
                {
                    coupon_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    barcode = table.Column<string>(type: "varchar(20)", nullable: false),
                    coupon_type = table.Column<byte>(type: "tinyint", nullable: false),
                    description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    coupon_value = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    dt_from = table.Column<DateTime>(type: "datetime", nullable: true),
                    dt_to = table.Column<DateTime>(type: "datetime", nullable: true),
                    ins_dt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupon", x => x.coupon_id);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_code = table.Column<string>(type: "varchar(20)", nullable: false),
                    item_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    item_price = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ins_dt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    row_version = table.Column<byte[]>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.item_id);
                });

            migrationBuilder.CreateTable(
                name: "provider",
                columns: table => new
                {
                    provider_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    vat_code = table.Column<string>(type: "varchar(20)", nullable: false),
                    email = table.Column<string>(type: "varchar(250)", nullable: false),
                    mobile = table.Column<string>(type: "varchar(12)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    zip_code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ins_dt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provider", x => x.provider_id);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    user_role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role", x => x.user_role_id);
                });

            migrationBuilder.CreateTable(
                name: "CouponItem",
                columns: table => new
                {
                    CouponsCouponId = table.Column<int>(type: "int", nullable: false),
                    ItemsItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponItem", x => new { x.CouponsCouponId, x.ItemsItemId });
                    table.ForeignKey(
                        name: "FK_CouponItem_coupon_CouponsCouponId",
                        column: x => x.CouponsCouponId,
                        principalTable: "coupon",
                        principalColumn: "coupon_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponItem_item_ItemsItemId",
                        column: x => x.ItemsItemId,
                        principalTable: "item",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemProvider",
                columns: table => new
                {
                    ItemsItemId = table.Column<int>(type: "int", nullable: false),
                    ProvidersProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemProvider", x => new { x.ItemsItemId, x.ProvidersProviderId });
                    table.ForeignKey(
                        name: "FK_ItemProvider_item_ItemsItemId",
                        column: x => x.ItemsItemId,
                        principalTable: "item",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemProvider_provider_ProvidersProviderId",
                        column: x => x.ProvidersProviderId,
                        principalTable: "provider",
                        principalColumn: "provider_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_role_id = table.Column<int>(type: "int", nullable: false),
                    login = table.Column<string>(type: "varchar(250)", nullable: false),
                    pass = table.Column<string>(type: "varchar(250)", nullable: false),
                    reg_dt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_user_user_role_user_role_id",
                        column: x => x.user_role_id,
                        principalTable: "user_role",
                        principalColumn: "user_role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer_form",
                columns: table => new
                {
                    customer_form_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    customer_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    customer_surname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    email = table.Column<string>(type: "varchar(250)", nullable: false),
                    mobile = table.Column<string>(type: "varchar(12)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    zip_code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ins_dt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_form", x => x.customer_form_id);
                    table.ForeignKey(
                        name: "FK_customer_form_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_form_id = table.Column<int>(type: "int", nullable: false),
                    order_status = table.Column<byte>(type: "tinyint", nullable: false),
                    order_dt = table.Column<DateTime>(type: "datetime", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_order_customer_form_customer_form_id",
                        column: x => x.customer_form_id,
                        principalTable: "customer_form",
                        principalColumn: "customer_form_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    item_price = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    item_discount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_item", x => new { x.order_id, x.item_id });
                    table.ForeignKey(
                        name: "FK_order_item_item_item_id",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_item_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CouponItem_ItemsItemId",
                table: "CouponItem",
                column: "ItemsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_form_user_id",
                table: "customer_form",
                column: "user_id",
                unique: true,
                filter: "[user_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ItemProvider_ProvidersProviderId",
                table: "ItemProvider",
                column: "ProvidersProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_order_customer_form_id",
                table: "order",
                column: "customer_form_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_item_id",
                table: "order_item",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_user_role_id",
                table: "user",
                column: "user_role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponItem");

            migrationBuilder.DropTable(
                name: "ItemProvider");

            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "coupon");

            migrationBuilder.DropTable(
                name: "provider");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "customer_form");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "user_role");
        }
    }
}
