using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WOD.Domain.Models;

namespace WebUI.Data
{
	public class MainContext : Microsoft.EntityFrameworkCore.DbContext
    {
		public MainContext(DbContextOptions<MainContext> options)
			: base(options)
		{
		}

		public DbSet<News> News { get; set; } = default!;
	}
}
