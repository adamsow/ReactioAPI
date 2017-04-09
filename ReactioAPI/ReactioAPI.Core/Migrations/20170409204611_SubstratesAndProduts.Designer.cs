using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ReactioAPI.Core.Data;

namespace ReactioAPI.Core.Migrations
{
    [DbContext(typeof(ReactioContext))]
    [Migration("20170409204611_SubstratesAndProduts")]
    partial class SubstratesAndProduts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reactio.Core.Domain.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Pattern");

                    b.Property<int>("ReactionID");

                    b.HasKey("ID");

                    b.HasIndex("ReactionID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Reactio.Core.Domain.Reaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Factor");

                    b.Property<bool>("IsEndothermic");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Reaction");
                });

            modelBuilder.Entity("Reactio.Core.Domain.Substrate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Pattern");

                    b.Property<int>("ReactionID");

                    b.HasKey("ID");

                    b.HasIndex("ReactionID");

                    b.ToTable("Substrate");
                });

            modelBuilder.Entity("Reactio.Core.Domain.Product", b =>
                {
                    b.HasOne("Reactio.Core.Domain.Reaction", "Reaction")
                        .WithMany("Products")
                        .HasForeignKey("ReactionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Reactio.Core.Domain.Substrate", b =>
                {
                    b.HasOne("Reactio.Core.Domain.Reaction", "Reaction")
                        .WithMany("Substrates")
                        .HasForeignKey("ReactionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
