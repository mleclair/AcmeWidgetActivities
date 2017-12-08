using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

using AcmeWidget.Models;

namespace AcmeWidget.DAL
{
    public class PersonalContactContext : DbContext
    {
        public PersonalContactContext()
            : base("PersonalContactContext")
        {
        }

        public DbSet<PersonalContactModel> PersonalContacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}