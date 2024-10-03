using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebUI.Data;

namespace WOD.WebUI.Migrations
{
	
    [DbContext(typeof(MainContext))]
	partial class MvcMovieContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "7.0.18")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);

			SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

			modelBuilder.Entity("WOD.Domain.Models.News", b =>
			{
				b.Property<int>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

				b.Property<string>("Text")
					.HasColumnType("text");

				b.Property<DateTime>("ReleaseDate")
					.HasColumnType("datetime2");

				b.Property<string>("Title")
					.HasColumnType("text");
				
				b.ToTable("News");
			});
#pragma warning restore 612, 618
		}
	}
}
