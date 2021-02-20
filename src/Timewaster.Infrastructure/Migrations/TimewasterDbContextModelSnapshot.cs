﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Timewaster.Infrastructure.DataAccess;

namespace Timewaster.Infrastructure.Migrations
{
    [DbContext(typeof(TimewasterDbContext))]
    partial class TimewasterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Timewaster.Core.Entities.Accounts.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IssueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Issue", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ReferenceNumber")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Tag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IssueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Socials.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiscussionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DiscussionId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Socials.Discussion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("ClosedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("IssueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OpenById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("OpenedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.HasIndex("OpenById");

                    b.ToTable("Discussions");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Accounts.User", b =>
                {
                    b.HasOne("Timewaster.Core.Entities.Boards.Issue", null)
                        .WithMany("AssignedUser")
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Tag", b =>
                {
                    b.HasOne("Timewaster.Core.Entities.Boards.Issue", null)
                        .WithMany("Tags")
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Socials.Comment", b =>
                {
                    b.HasOne("Timewaster.Core.Entities.Accounts.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Timewaster.Core.Entities.Socials.Discussion", null)
                        .WithMany("Comments")
                        .HasForeignKey("DiscussionId");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Socials.Discussion", b =>
                {
                    b.HasOne("Timewaster.Core.Entities.Boards.Issue", null)
                        .WithMany("Discussions")
                        .HasForeignKey("IssueId");

                    b.HasOne("Timewaster.Core.Entities.Accounts.User", "OpenBy")
                        .WithMany()
                        .HasForeignKey("OpenById");

                    b.Navigation("OpenBy");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Issue", b =>
                {
                    b.Navigation("AssignedUser");

                    b.Navigation("Discussions");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Socials.Discussion", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
