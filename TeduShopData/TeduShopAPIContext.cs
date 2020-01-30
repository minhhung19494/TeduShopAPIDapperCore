using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TeduShopData.Models.DynamicAttribute;

namespace TeduShopData.Models
{
    public partial class TeduShopAPIContext : DbContext
    {
        public TeduShopAPIContext()
        {
        }

        public TeduShopAPIContext(DbContextOptions<TeduShopAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnnouncementUsers> AnnouncementUsers { get; set; }
        public virtual DbSet<Announcements> Announcements { get; set; }
        public virtual DbSet<AppRoles> AppRoles { get; set; }
        public virtual DbSet<AppUserClaims> AppUserClaims { get; set; }
        public virtual DbSet<AppUserLogins> AppUserLogins { get; set; }
        public virtual DbSet<AppUserRoles> AppUserRoles { get; set; }
        public virtual DbSet<AppUsers> AppUsers { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<ContactDetails> ContactDetails { get; set; }
        public virtual DbSet<Errors> Errors { get; set; }
        public virtual DbSet<Feedbacks> Feedbacks { get; set; }
        public virtual DbSet<Footers> Footers { get; set; }
        public virtual DbSet<Functions> Functions { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<PostCategories> PostCategories { get; set; }
        public virtual DbSet<PostTags> PostTags { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<ProductCategories> ProductCategories { get; set; }
        public virtual DbSet<ProductImages> ProductImages { get; set; }
        public virtual DbSet<ProductQuantities> ProductQuantities { get; set; }
        public virtual DbSet<ProductTags> ProductTags { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sizes> Sizes { get; set; }
        public virtual DbSet<Slides> Slides { get; set; }
        public virtual DbSet<SupportOnlines> SupportOnlines { get; set; }
        public virtual DbSet<SystemConfigs> SystemConfigs { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<VisitorStatistics> VisitorStatistics { get; set; }
        public virtual DbSet<Actions> Actions { get; set; }
        public virtual DbSet<ActionsInFunction> ActionsInFunctions {get; set;}
        public virtual DbSet<Attributes> Attributes { get; set; }
        public virtual DbSet<AttributeOptions> AttributeOptions { get; set; }
        public virtual DbSet<AttributeOptionValues> AttributeOptionValues { get; set; }
        public virtual DbSet<AttributeValueInts> AttributeValueInts { get; set; }
        public virtual DbSet<AttributeValueDateTimes> AttributeValueDateTimes { get; set; }
        public virtual DbSet<AttributeValueText> AttributeValueText { get; set; }
        public virtual DbSet<AttributeValueVarchars> AttributeValueVarchars { get; set; }
        public virtual DbSet<AttributeValueDecimals> AttributeValueDecimals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= MINH-HUNG; Database=TeduShopAPI; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttributeValueDateTimes>(entity =>
            {
                entity.HasOne(d=>d.Attributes)
                    .WithMany(p=>p.AttributeValueDateTimes)
                    .HasForeignKey(d=>d.AttributeId)
                    .HasConstraintName("FK_dbo.AttributeValueDatTime_dbo.Attributes_AttributeId");
                entity.HasOne(d => d.Products)
                    .WithMany(p => p.AttributeValueDateTimes)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.AttributeValueDatTime_dbo.Attributes_ProductId");
            });
            modelBuilder.Entity<AttributeValueText>(entity =>
            {
                entity.HasOne(d => d.Attributes)
                    .WithMany(p => p.AttributeValueText)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_dbo.AttributeValueText_dbo.Attributes_AttributeId");
                entity.HasOne(d => d.Products)
                    .WithMany(p => p.AttributeValueText)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.AttributeValueText_dbo.Attributes_ProductId");
            });
            modelBuilder.Entity<AttributeValueVarchars>(entity =>
            {
                entity.HasOne(d => d.Attributes)
                    .WithMany(p => p.AttributeValueVarchars)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_dbo.AttributeValueVarchars_dbo.Attributes_AttributeId");
                entity.HasOne(d => d.Products)
                    .WithMany(p => p.AttributeValueVarchars)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.AttributeValueVarchars_dbo.Attributes_ProductId");
            });
            modelBuilder.Entity<AttributeValueDecimals>(entity =>
            {
                entity.HasOne(d => d.Attributes)
                    .WithMany(p => p.AttributeValueDecimals)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_dbo.AttributeValueDecimals_dbo.Attributes_AttributeId");
                entity.HasOne(d => d.Products)
                    .WithMany(p => p.AttributeValueDecimals)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.AttributeValueDecimals_dbo.Attributes_ProductId");
            });
            modelBuilder.Entity<AttributeValueInts>(entity =>
            {
                entity.HasOne(d => d.Attributes)
                    .WithMany(p => p.AttributeValueInts)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_dbo.AttributeValueInts_dbo.Attributes_AttributeId");
                entity.HasOne(d => d.Products)
                    .WithMany(p => p.AttributeValueInts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.AttributeValueInts_dbo.Attributes_ProductId");
            });
            modelBuilder.Entity<AttributeOptionValues>(entity =>
            {
                entity.HasOne(d => d.AttributeOptions)
                    .WithMany(p => p.AttributeOptionValues)
                    .HasForeignKey(d => d.OptionId)
                    .HasConstraintName("FK_dbo.AttributeOptionValues_dbo.AttributeOptions_OptionId");
            });
            modelBuilder.Entity<AttributeOptions>(entity =>
            {
                entity.HasOne(d => d.Attributes)
                    .WithMany(p => p.AttributeOptions)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_dbo.AttributeOptions_dbo.Attributes_AttributeId");
            });
            modelBuilder.Entity<ActionsInFunction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.ActionId);
                entity.Property(e => e.FunctionId);
                entity.HasOne(d => d.Functions)
                    .WithMany(p => p.ActionsInFunction)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK_dbo.Funtions_dbo.ActionsInFunction_FunctionId");
                entity.HasOne(d => d.Actions)
                    .WithMany(p => p.ActionsInFunction)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("FK_dbo.Actions_dbo.ActionsInFunction_ActionId");
            });
            modelBuilder.Entity<Actions>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(true);
                entity.Property(e => e.Code)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<AnnouncementUsers>(entity =>
            {
                entity.HasKey(e => new { e.AnnouncementId, e.UserId })
                    .HasName("PK_dbo.AnnouncementUsers");

                entity.HasIndex(e => e.AnnouncementId)
                    .HasName("IX_AnnouncementId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Announcement)
                    .WithMany(p => p.AnnouncementUsers)
                    .HasForeignKey(d => d.AnnouncementId)
                    .HasConstraintName("FK_dbo.AnnouncementUsers_dbo.Announcements_AnnouncementId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AnnouncementUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AnnouncementUsers_dbo.AppUsers_UserId")
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Announcements>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Announcements_dbo.AppUsers_AppUser_Id");
            });

            modelBuilder.Entity<AppRoles>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

            });

            modelBuilder.Entity<AppUserClaims>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_dbo.AppUserClaims");

                entity.HasIndex(e => e.AppUserId)
                    .HasName("IX_AppUser_Id");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.AppUserId)
                    .HasColumnName("AppUser_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AppUserClaims)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK_dbo.AppUserClaims_dbo.AppUsers_AppUser_Id");
            });

            modelBuilder.Entity<AppUserLogins>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_dbo.AppUserLogins");

                entity.HasIndex(e => e.AppUserId)
                    .HasName("IX_AppUser_Id");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.AppUserId)
                    .HasColumnName("AppUser_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AppUserLogins)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK_dbo.AppUserLogins_dbo.AppUsers_AppUser_Id");
            });

            modelBuilder.Entity<AppUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AppUserRoles");

                entity.HasIndex(e => e.AppUserId)
                    .HasName("IX_AppUser_Id");

                entity.HasIndex(e => e.IdentityRoleId)
                    .HasName("IX_IdentityRole_Id");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.Property(e => e.AppUserId)
                    .HasColumnName("AppUser_Id")
                    .HasMaxLength(128);

                entity.Property(e => e.IdentityRoleId)
                    .HasColumnName("IdentityRole_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AppUserRoles)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK_dbo.AppUserRoles_dbo.AppUsers_AppUser_Id");

                entity.HasOne(d => d.IdentityRole)
                    .WithMany(p => p.AppUserRoles)
                    .HasForeignKey(d => d.IdentityRoleId)
                    .HasConstraintName("FK_dbo.AppUserRoles_dbo.AppRoles_IdentityRole_Id");
            });

            modelBuilder.Entity<AppUsers>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<Colors>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<ContactDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(250);
            });

            modelBuilder.Entity<Errors>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Feedbacks>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Message).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Footers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.Content).IsRequired();
            });

            modelBuilder.Entity<Functions>(entity =>
            {
                entity.HasIndex(e => e.ParentId)
                    .HasName("IX_ParentId");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(256);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_dbo.Functions_dbo.Functions_ParentId");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_dbo.OrderDetails");

                entity.HasIndex(e => e.ColorId)
                    .HasName("IX_ColorId");

                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderID");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_ProductID");

                entity.HasIndex(e => e.SizeId)
                    .HasName("IX_SizeId");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_dbo.OrderDetails_dbo.Colors_ColorId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_dbo.OrderDetails_dbo.Orders_OrderID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.OrderDetails_dbo.Products_ProductID");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_dbo.OrderDetails_dbo.Sizes_SizeId");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_CustomerId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerId).HasMaxLength(128);

                entity.Property(e => e.CustomerMessage)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerMobile)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PaymentMethod).HasMaxLength(256);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_dbo.Orders_dbo.AppUsers_CustomerId");
            });

            modelBuilder.Entity<Pages>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.HasIndex(e => e.FunctionId)
                    .HasName("IX_FunctionId");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FunctionId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.Property(e => e.ActionId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK_dbo.Permissions_dbo.Functions_FunctionId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.Permissions_dbo.AppRoles_RoleId");
                entity.HasOne(d=>d.Action)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("FK_dbo.Permissions_dbo.Actions_ActionId");
            });

            modelBuilder.Entity<PostCategories>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PostTags>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.TagId })
                    .HasName("PK_dbo.PostTags");

                entity.HasIndex(e => e.PostId)
                    .HasName("IX_PostID");

                entity.HasIndex(e => e.TagId)
                    .HasName("IX_TagID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.TagId)
                    .HasColumnName("TagID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_dbo.PostTags_dbo.Posts_PostID");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_dbo.PostTags_dbo.Tags_TagID");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasIndex(e => e.CategoryId)
                    .HasName("IX_CategoryID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_dbo.Posts_dbo.PostCategories_CategoryID");
            });

            modelBuilder.Entity<ProductCategories>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductImages>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_ProductId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Caption).HasMaxLength(250);

                entity.Property(e => e.Path).HasMaxLength(250);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.ProductImages_dbo.Products_ProductId");
            });

            modelBuilder.Entity<ProductQuantities>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.SizeId, e.ColorId })
                    .HasName("PK_dbo.ProductQuantities");

                entity.HasIndex(e => e.ColorId)
                    .HasName("IX_ColorId");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_ProductId");

                entity.HasIndex(e => e.SizeId)
                    .HasName("IX_SizeId");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ProductQuantities)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_dbo.ProductQuantities_dbo.Colors_ColorId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductQuantities)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.ProductQuantities_dbo.Products_ProductId");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ProductQuantities)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_dbo.ProductQuantities_dbo.Sizes_SizeId");
            });

            modelBuilder.Entity<ProductTags>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.TagId })
                    .HasName("PK_dbo.ProductTags");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_ProductID");

                entity.HasIndex(e => e.TagId)
                    .HasName("IX_TagID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.TagId)
                    .HasColumnName("TagID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.ProductTags_dbo.Products_ProductID");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_dbo.ProductTags_dbo.Tags_TagID");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.CategoryId)
                    .HasName("IX_CategoryID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IncludedVat).HasColumnName("IncludedVAT");

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PromotionPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ThumbnailImage).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_dbo.Products_dbo.ProductCategories_CategoryID");
            });

            modelBuilder.Entity<Sizes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Slides>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Url).HasMaxLength(256);
            });

            modelBuilder.Entity<SupportOnlines>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Facebook).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Skype).HasMaxLength(50);

                entity.Property(e => e.Yahoo).HasMaxLength(50);
            });

            modelBuilder.Entity<SystemConfigs>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValueString).HasMaxLength(50);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VisitorStatistics>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.VisitedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
