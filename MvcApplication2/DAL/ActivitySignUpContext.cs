using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AcmeWidget.DAL
{
	public class ActivitySignUpContext : DbContext
	{
		public ActivitySignUpContext() : base("ActivitySignUpContext") { }

		public DbSet<ActivitySignUpContext> ActivitySignUps { get; set; }

		protected override void OnModelCreating ( DbModelBuilder modelBuilder )
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention> ( );
		}
	}
}