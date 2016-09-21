using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InvSys.RuleOne.State.EntityFramework;

namespace InvSys.RuleOne.State.EntityFramework.Migrations
{
    [DbContext(typeof(RuleOneContext))]
    [Migration("20160921055729_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvSys.RuleOne.Core.Models.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanySymbol");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsAwesome");

                    b.HasKey("Id");

                    b.ToTable("Ratings");
                });
        }
    }
}
