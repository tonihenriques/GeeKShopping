﻿// <auto-generated />
using System;
using GeekShopping.OrderAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeekShopping.OrderAPI.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20220928232101_geeksh")]
    partial class geeksh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GeekShopping.OrderAPI.Model.OrderDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("count");

                    b.Property<long>("OrderHeaderId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("ProductId");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("product_name");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeaderId");

                    b.ToTable("order_detail");
                });

            modelBuilder.Entity("GeekShopping.OrderAPI.Model.OrderHeader", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("CVV")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cvv");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("card_number");

                    b.Property<int>("CartTotalItens")
                        .HasColumnType("int")
                        .HasColumnName("total_itens");

                    b.Property<string>("CouponCode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("coupon_code");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("purchase_date");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("discount_amount");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("ExpiryMonthYear")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("expiry_month_year");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("order_time");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit")
                        .HasColumnName("payment_status");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone_number");

                    b.Property<decimal>("PurchaseAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("purchase_amount");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("order_header");
                });

            modelBuilder.Entity("GeekShopping.OrderAPI.Model.OrderDetail", b =>
                {
                    b.HasOne("GeekShopping.OrderAPI.Model.OrderHeader", "OrderHeader")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderHeader");
                });

            modelBuilder.Entity("GeekShopping.OrderAPI.Model.OrderHeader", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
