using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WOD.Domain.Models;
using WOD.WebUI.Services;

namespace WebUI.Data;
public class MainContext : DbContext
{
	public virtual DbSet<FootballClub> FootballClubs { get; set; }
	public virtual DbSet<News> News { get; set; } 
	public MainContext(DbContextOptions<MainContext> options)
		: base(options)
	{
			
	}

	
}
