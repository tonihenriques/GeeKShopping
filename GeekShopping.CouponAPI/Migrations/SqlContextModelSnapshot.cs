﻿// <auto-generated />
using GeekShopping.CouponAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeekShopping.CouponAPI.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GeekShopping.CouponAPI.Model.Coupon", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("coupon_code");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("discount_amount");

                    b.HasKey("Id");

                    b.ToTable("coupon");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CouponCode = "ERUDIO_2022_10",
                            DiscountAmount = 10m
                        },
                        new
                        {
                            Id = 2L,
                            CouponCode = "ERUDIO_2022_15",
                            DiscountAmount = 15m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
