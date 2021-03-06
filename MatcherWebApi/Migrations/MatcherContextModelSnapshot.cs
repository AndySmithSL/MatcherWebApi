﻿// <auto-generated />
using System;
using MatcherWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatcherWebApi.Migrations
{
    [DbContext(typeof(MatcherContext))]
    partial class MatcherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MatcherWebApi.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber");

                    b.Property<string>("Name");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MatcherWebApi.Models.OrderBookItem", b =>
                {
                    b.Property<int>("OrderBookItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("OrderType");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderBookItemId");

                    b.HasIndex("AccountId");

                    b.ToTable("OrderBook");
                });

            modelBuilder.Entity("MatcherWebApi.Models.OrderHistoryItem", b =>
                {
                    b.Property<int>("OrderHistoryItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderType");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderHistoryItemId");

                    b.HasIndex("AccountId");

                    b.ToTable("OrderHistory");
                });

            modelBuilder.Entity("MatcherWebApi.Models.Trade", b =>
                {
                    b.Property<int>("TradeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExistingOrderId");

                    b.Property<int>("NewOrderId");

                    b.Property<DateTime>("TradeDate");

                    b.HasKey("TradeId");

                    b.HasIndex("ExistingOrderId");

                    b.HasIndex("NewOrderId");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("MatcherWebApi.Models.OrderBookItem", b =>
                {
                    b.HasOne("MatcherWebApi.Models.Account", "Account")
                        .WithMany("OrderBook")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MatcherWebApi.Models.OrderHistoryItem", b =>
                {
                    b.HasOne("MatcherWebApi.Models.Account", "Account")
                        .WithMany("OrderHistory")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MatcherWebApi.Models.Trade", b =>
                {
                    b.HasOne("MatcherWebApi.Models.OrderBookItem", "ExistingOrder")
                        .WithMany()
                        .HasForeignKey("ExistingOrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MatcherWebApi.Models.OrderBookItem", "NewOrder")
                        .WithMany()
                        .HasForeignKey("NewOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
