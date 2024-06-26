﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using handydandy.Data;

#nullable disable

namespace handydandy.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240601191418_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("handydandy.Models.Case", b =>
                {
                    b.Property<int>("CaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AcceptedOfferID")
                        .HasColumnType("int");

                    b.Property<int>("CaseType")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time(6)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("SessionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CaseId");

                    b.HasIndex("UserId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("handydandy.Models.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.HasKey("ChatId");

                    b.HasIndex("CaseId")
                        .IsUnique();

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("handydandy.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<int>("SenderTradesmanId")
                        .HasColumnType("int");

                    b.Property<int>("SenderUserId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("handydandy.Models.Offer", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Accepted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("QuickDetials")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TradesmanId")
                        .HasColumnType("int");

                    b.HasKey("OfferId");

                    b.HasIndex("CaseId");

                    b.HasIndex("TradesmanId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("handydandy.Models.Tradesman", b =>
                {
                    b.Property<int>("TradesmanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("ProfileCompleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ServiceArea")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("longtext");

                    b.Property<int>("TradeOccupation")
                        .HasColumnType("int");

                    b.HasKey("TradesmanId");

                    b.ToTable("Tradesmans");
                });

            modelBuilder.Entity("handydandy.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("ProfileCompleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Zipcode")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("handydandy.Models.Case", b =>
                {
                    b.HasOne("handydandy.Models.User", "User")
                        .WithMany("Cases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("handydandy.Models.Chat", b =>
                {
                    b.HasOne("handydandy.Models.Case", "Case")
                        .WithOne("Chat")
                        .HasForeignKey("handydandy.Models.Chat", "CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");
                });

            modelBuilder.Entity("handydandy.Models.Message", b =>
                {
                    b.HasOne("handydandy.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("handydandy.Models.Offer", b =>
                {
                    b.HasOne("handydandy.Models.Case", "Case")
                        .WithMany("Offers")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("handydandy.Models.Tradesman", "Tradesman")
                        .WithMany("Offers")
                        .HasForeignKey("TradesmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");

                    b.Navigation("Tradesman");
                });

            modelBuilder.Entity("handydandy.Models.Case", b =>
                {
                    b.Navigation("Chat")
                        .IsRequired();

                    b.Navigation("Offers");
                });

            modelBuilder.Entity("handydandy.Models.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("handydandy.Models.Tradesman", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("handydandy.Models.User", b =>
                {
                    b.Navigation("Cases");
                });
#pragma warning restore 612, 618
        }
    }
}
