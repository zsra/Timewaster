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

            modelBuilder.HasSequence("comment")
                .IncrementsBy(10);

            modelBuilder.HasSequence("discussion")
                .IncrementsBy(10);

            modelBuilder.HasSequence("issue")
                .IncrementsBy(10);

            modelBuilder.HasSequence("project")
                .IncrementsBy(10);

            modelBuilder.HasSequence("sprint")
                .IncrementsBy(10);

            modelBuilder.HasSequence("status")
                .IncrementsBy(10);

            modelBuilder.HasSequence("story")
                .IncrementsBy(10);

            modelBuilder.HasSequence("tag")
                .IncrementsBy(10);

            modelBuilder.HasSequence("user")
                .IncrementsBy(10);

            modelBuilder.Entity("Timewaster.Core.Entities.Accounts.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "user")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("IssueId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PartitionKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "issue")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DiscussionId")
                        .HasColumnType("int");

                    b.Property<string>("PartitionKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReferenceNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SprintId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("StoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("SprintId");

                    b.HasIndex("StatusId");

                    b.HasIndex("StoryId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Sprint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "sprint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime>("ClosingAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiscussionId")
                        .HasColumnType("int");

                    b.Property<string>("PartitionKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ReferenceKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "status")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PartitionKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SprintId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SprintId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "story")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DiscussionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PartitionKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SprintId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("SprintId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "tag")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int?>("IssueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PartitionKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Projects.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "project")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PartitionKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RefernceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Socials.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "comment")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<int?>("DiscussionId")
                        .HasColumnType("int");

                    b.Property<string>("PartitionKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DiscussionId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Socials.Discussion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "discussion")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTimeOffset>("ClosedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("OpenById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("OpenedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PartitionKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OpenById");

                    b.ToTable("Discussions");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Accounts.User", b =>
                {
                    b.HasOne("Timewaster.Core.Entities.Boards.Issue", null)
                        .WithMany("AssignedUsers")
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Issue", b =>
                {
                    b.HasOne("Timewaster.Core.Entities.Socials.Discussion", "Discussion")
                        .WithMany()
                        .HasForeignKey("DiscussionId");

                    b.HasOne("Timewaster.Core.Entities.Boards.Sprint", null)
                        .WithMany("Issues")
                        .HasForeignKey("SprintId");

                    b.HasOne("Timewaster.Core.Entities.Boards.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("Timewaster.Core.Entities.Boards.Story", "Story")
                        .WithMany("Issues")
                        .HasForeignKey("StoryId");

                    b.Navigation("Discussion");

                    b.Navigation("Status");

                    b.Navigation("Story");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Sprint", b =>
                {
                    b.HasOne("Timewaster.Core.Entities.Socials.Discussion", "Discussion")
                        .WithMany()
                        .HasForeignKey("DiscussionId");

                    b.HasOne("Timewaster.Core.Entities.Projects.Project", null)
                        .WithMany("Sprints")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Discussion");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Status", b =>
                {
                    b.HasOne("Timewaster.Core.Entities.Boards.Sprint", null)
                        .WithMany("Statuses")
                        .HasForeignKey("SprintId");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Story", b =>
                {
                    b.HasOne("Timewaster.Core.Entities.Socials.Discussion", "Discussion")
                        .WithMany()
                        .HasForeignKey("DiscussionId");

                    b.HasOne("Timewaster.Core.Entities.Boards.Sprint", "Sprint")
                        .WithMany("Stories")
                        .HasForeignKey("SprintId");

                    b.Navigation("Discussion");

                    b.Navigation("Sprint");
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
                    b.HasOne("Timewaster.Core.Entities.Accounts.User", "OpenBy")
                        .WithMany()
                        .HasForeignKey("OpenById");

                    b.Navigation("OpenBy");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Issue", b =>
                {
                    b.Navigation("AssignedUsers");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Sprint", b =>
                {
                    b.Navigation("Issues");

                    b.Navigation("Statuses");

                    b.Navigation("Stories");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Boards.Story", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Projects.Project", b =>
                {
                    b.Navigation("Sprints");
                });

            modelBuilder.Entity("Timewaster.Core.Entities.Socials.Discussion", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
