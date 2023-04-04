using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21House.Core.Domain;

namespace TARge21House.Data
{
	public class TARge21HouseContext : DbContext
	{
		public TARge21HouseContext(DbContextOptions<TARge21HouseContext> options)
		: base(options) { }

		public DbSet<House> Houses { get; set; }
	}
}
