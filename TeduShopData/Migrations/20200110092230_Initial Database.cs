using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeduShopData.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(nullable: false),
                    ProductVersion = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    FullName = table.Column<string>(maxLength: 256, nullable: true),
                    Address = table.Column<string>(maxLength: 256, nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<bool>(nullable: true),
                    Gender = table.Column<bool>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEndDateUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Code = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    Website = table.Column<string>(maxLength: 250, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    Other = table.Column<string>(nullable: true),
                    Lat = table.Column<double>(nullable: true),
                    Lng = table.Column<double>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    Message = table.Column<string>(maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    URL = table.Column<string>(maxLength: 256, nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    ParentId = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    IconCss = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.Functions_dbo.Functions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Functions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    HomeOrder = table.Column<int>(nullable: true),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    Url = table.Column<string>(maxLength: 256, nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SupportOnlines",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Department = table.Column<string>(maxLength: 50, nullable: true),
                    Skype = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Yahoo = table.Column<string>(maxLength: 50, nullable: true),
                    Facebook = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportOnlines", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SystemConfigs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ValueString = table.Column<string>(maxLength: 50, nullable: true),
                    ValueInt = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfigs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VisitorStatistics",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    VisitedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IPAddress = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorStatistics", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.Announcements_dbo.AppUsers_AppUser_Id",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 128, nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    AppUser_Id = table.Column<Guid>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AppUserClaims", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_dbo.AppUserClaims_dbo.AppUsers_AppUser_Id",
                        column: x => x.AppUser_Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 128, nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    AppUser_Id = table.Column<Guid>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AppUserLogins", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_dbo.AppUserLogins_dbo.AppUsers_AppUser_Id",
                        column: x => x.AppUser_Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(maxLength: 128, nullable: false),
                    RoleId = table.Column<Guid>(maxLength: 128, nullable: false),
                    AppUser_Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    IdentityRole_Id = table.Column<Guid>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AppUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_dbo.AppUserRoles_dbo.AppUsers_AppUser_Id",
                        column: x => x.AppUser_Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.AppUserRoles_dbo.AppRoles_IdentityRole_Id",
                        column: x => x.IdentityRole_Id,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(maxLength: 256, nullable: false),
                    CustomerAddress = table.Column<string>(maxLength: 256, nullable: false),
                    CustomerEmail = table.Column<string>(maxLength: 256, nullable: false),
                    CustomerMobile = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerMessage = table.Column<string>(maxLength: 256, nullable: false),
                    PaymentMethod = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<Guid>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.Orders_dbo.AppUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(maxLength: 128, nullable: false),
                    FunctionId = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CanCreate = table.Column<bool>(nullable: false),
                    CanRead = table.Column<bool>(nullable: false),
                    CanUpdate = table.Column<bool>(nullable: false),
                    CanDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.Permissions_dbo.Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.Permissions_dbo.AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    HotFlag = table.Column<bool>(nullable: true),
                    ViewCount = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.Posts_dbo.PostCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "PostCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(maxLength: 256, nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    ThumbnailImage = table.Column<string>(maxLength: 256, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PromotionPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    IncludedVAT = table.Column<bool>(nullable: false),
                    Warranty = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    HotFlag = table.Column<bool>(nullable: true),
                    ViewCount = table.Column<int>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.Products_dbo.ProductCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "ProductCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementUsers",
                columns: table => new
                {
                    AnnouncementId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(maxLength: 128, nullable: false),
                    HasRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AnnouncementUsers", x => new { x.AnnouncementId, x.UserId });
                    table.ForeignKey(
                        name: "FK_dbo.AnnouncementUsers_dbo.Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.AnnouncementUsers_dbo.AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false),
                    TagID = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PostTags", x => new { x.PostID, x.TagID });
                    table.ForeignKey(
                        name: "FK_dbo.PostTags_dbo.Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.PostTags_dbo.Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.OrderDetails", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_dbo.OrderDetails_dbo.Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.OrderDetails_dbo.Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.OrderDetails_dbo.Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.OrderDetails_dbo.Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Path = table.Column<string>(maxLength: 250, nullable: true),
                    Caption = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.ProductImages_dbo.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductQuantities",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ProductQuantities", x => new { x.ProductId, x.SizeId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_dbo.ProductQuantities_dbo.Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.ProductQuantities_dbo.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.ProductQuantities_dbo.Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    TagID = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ProductTags", x => new { x.ProductID, x.TagID });
                    table.ForeignKey(
                        name: "FK_dbo.ProductTags_dbo.Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.ProductTags_dbo.Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "Announcements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementId",
                table: "AnnouncementUsers",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "AnnouncementUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Id",
                table: "AppUserClaims",
                column: "AppUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Id",
                table: "AppUserLogins",
                column: "AppUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Id",
                table: "AppUserRoles",
                column: "AppUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRole_Id",
                table: "AppUserRoles",
                column: "IdentityRole_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParentId",
                table: "Functions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorId",
                table: "OrderDetails",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SizeId",
                table: "OrderDetails",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionId",
                table: "Permissions",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleId",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryID",
                table: "Posts",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PostID",
                table: "PostTags",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_TagID",
                table: "PostTags",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorId",
                table: "ProductQuantities",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductId",
                table: "ProductQuantities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeId",
                table: "ProductQuantities",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductID",
                table: "ProductTags",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TagID",
                table: "ProductTags",
                column: "TagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "AnnouncementUsers");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductQuantities");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "SupportOnlines");

            migrationBuilder.DropTable(
                name: "SystemConfigs");

            migrationBuilder.DropTable(
                name: "VisitorStatistics");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
