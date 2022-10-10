﻿// <auto-generated />
using CreateYourOwnAdventure.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CreateYourOwnAdventure.Infrastructure.Migrations
{
    [DbContext(typeof(AdventureContext))]
    partial class AdventureContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("CreateYourOwnAdventure.Core.Entities.MyAdventure", b =>
                {
                    b.Property<int>("MyAdventureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BinaryTreeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Steps")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MyAdventureId");

                    b.ToTable("MyAdventures");

                    b.HasData(
                        new
                        {
                            MyAdventureId = 1,
                            BinaryTreeId = 1,
                            Steps = "[\"L\",\"L\",\"R\",\"L\"]"
                        });
                });

            modelBuilder.Entity("CreateYourOwnAdventure.Core.Entities.BinaryTree<CreateYourOwnAdventure.Core.Entities.Question>", b =>
                {
                    b.Property<int>("BinaryTreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Root")
                        .HasColumnType("TEXT");

                    b.HasKey("BinaryTreeId");

                    b.ToTable("Adventures");

                    b.HasData(
                        new
                        {
                            BinaryTreeId = 1,
                            Root = "{\"Yes\":{\"Yes\":{\"Yes\":{\"Data\":{\"Text\":\"Get it\"}},\"No\":{\"Data\":{\"Text\":\"Do jumping jacks first!\"}},\"Data\":{\"Text\":\"Are you sure?\"}},\"No\":{\"Yes\":{\"Data\":{\"Text\":\"What are you waiting for? Grab it now.\"}},\"No\":{\"Data\":{\"Text\":\"Wait till you find a sinful, unforgettable doughnut.\"}},\"Data\":{\"Text\":\"Is it a good donut?\"}},\"Data\":{\"Text\":\"Do I deserve it?\"}},\"No\":{\"Data\":{\"Text\":\"Maybe you want an apple?\"}},\"Data\":{\"Text\":\"Do I want a Donut?\"}}"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
