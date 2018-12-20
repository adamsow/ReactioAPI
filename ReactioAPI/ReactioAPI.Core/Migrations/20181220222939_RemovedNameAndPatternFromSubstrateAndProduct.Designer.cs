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
    [Migration("20181220222939_RemovedNameAndPatternFromSubstrateAndProduct")]
    partial class RemovedNameAndPatternFromSubstrateAndProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReactioAPI.Core.Domain.AppSetting", b =>
                {
                    b.Property<string>("AppSettingKey")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppSettingValue");

                    b.HasKey("AppSettingKey");

                    b.ToTable("AppSetting");
                });

            modelBuilder.Entity("ReactioAPI.Core.Domain.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsGas");

                    b.Property<bool>("IsSediment");

                    b.Property<int>("Quantity");

                    b.Property<int>("ReactionID");

                    b.Property<int>("ReagentID");

                    b.HasKey("ID");

                    b.HasIndex("ReactionID");

                    b.HasIndex("ReagentID");

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

                    b.Property<string>("NamePL");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.ToTable("Reaction");
                });

            modelBuilder.Entity("ReactioAPI.Core.Domain.Reagent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("NamePL");

                    b.Property<string>("Pattern");

                    b.HasKey("ID");

                    b.ToTable("Reagent");
                });

            modelBuilder.Entity("ReactioAPI.Core.Domain.Substrate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Quantity");

                    b.Property<int>("ReactionID");

                    b.Property<int>("ReagentID");

                    b.HasKey("ID");

                    b.HasIndex("ReactionID");

                    b.HasIndex("ReagentID");

                    b.ToTable("Substrate");
                });

            modelBuilder.Entity("ReactioAPI.Core.Domain.Product", b =>
                {
                    b.HasOne("ReactioAPI.Core.Domain.Reaction", "Reaction")
                        .WithMany("Products")
                        .HasForeignKey("ReactionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReactioAPI.Core.Domain.Reagent", "Reagent")
                        .WithMany()
                        .HasForeignKey("ReagentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReactioAPI.Core.Domain.Substrate", b =>
                {
                    b.HasOne("ReactioAPI.Core.Domain.Reaction", "Reaction")
                        .WithMany("Substrates")
                        .HasForeignKey("ReactionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReactioAPI.Core.Domain.Reagent", "Reagent")
                        .WithMany()
                        .HasForeignKey("ReagentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
