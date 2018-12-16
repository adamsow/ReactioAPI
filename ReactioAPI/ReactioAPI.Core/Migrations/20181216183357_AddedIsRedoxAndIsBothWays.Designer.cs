using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ReactioAPI.Core.Data;
using ReactioAPI.Core.Domain;

namespace ReactioAPI.Core.Migrations
{
    [DbContext(typeof(ReactioContext))]
    [Migration("20181216183357_AddedIsRedoxAndIsBothWays")]
    partial class AddedIsRedoxAndIsBothWays
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReactioAPI.Core.Domain.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsSediment");

                    b.Property<string>("Name");

                    b.Property<string>("Pattern");

                    b.Property<int>("Quantity");

                    b.Property<int>("ReactionID");

                    b.HasKey("ID");

                    b.HasIndex("ReactionID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ReactioAPI.Core.Domain.Reaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Factor");

                    b.Property<bool>("IsBothWays");

                    b.Property<bool>("IsEndothermic");

                    b.Property<bool>("IsRedox");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.ToTable("Reaction");
                });

            modelBuilder.Entity("ReactioAPI.Core.Domain.Substrate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Pattern");

                    b.Property<int>("Quantity");

                    b.Property<int>("ReactionID");

                    b.HasKey("ID");

                    b.HasIndex("ReactionID");

                    b.ToTable("Substrate");
                });

            modelBuilder.Entity("ReactioAPI.Core.Domain.Product", b =>
                {
                    b.HasOne("ReactioAPI.Core.Domain.Reaction", "Reaction")
                        .WithMany("Products")
                        .HasForeignKey("ReactionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReactioAPI.Core.Domain.Substrate", b =>
                {
                    b.HasOne("ReactioAPI.Core.Domain.Reaction", "Reaction")
                        .WithMany("Substrates")
                        .HasForeignKey("ReactionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
