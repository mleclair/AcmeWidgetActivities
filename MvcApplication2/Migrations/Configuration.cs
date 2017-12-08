namespace AcmeWidget.Migrations
{
	using AcmeWidget.Models;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using System.Web.Security;
	using WebMatrix.WebData;

	internal sealed class Configuration : DbMigrationsConfiguration<AcmeWidget.DAL.PersonalContactContext>
	{
		public Configuration ( )
		{
			AutomaticMigrationsEnabled = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		protected override void Seed ( AcmeWidget.DAL.PersonalContactContext context )
		{
			var contacts = new List<PersonalContactModel>
			{
				new PersonalContactModel{Id=1,UserName="asd",FirstName="Eugene",LastName="Cernan",HomePhone="123-456-7890",AddressId=1,PersonalEmail="gene.cernan@fast.ca"},
				new PersonalContactModel{Id=2,UserName="asd",FirstName="Harrison",LastName="Schmidt",HomePhone="321-654-0987",AddressId=1,PersonalEmail="harry@fast.ca"},
				new PersonalContactModel{Id=3,UserName="asd",FirstName="Scott",LastName="Carpenter",HomePhone="222-444-6868",AddressId=1,PersonalEmail="scotty@fast.ca"},
				new PersonalContactModel{Id=4,UserName="asd",FirstName="Charlie",LastName="Duke",HomePhone="131-313-1313",AddressId=1,PersonalEmail="duke@fast.ca"},
				new PersonalContactModel{Id=5,UserName="asd",FirstName="Michael",LastName="Collins",HomePhone="123-785-0000",AddressId=1,PersonalEmail="mikey@fast.ca"},
				new PersonalContactModel{Id=6,UserName="asd",FirstName="Buzz",LastName="Aldrin",HomePhone="898-456-4578",AddressId=1,PersonalEmail="buzz@fast.ca"},
				new PersonalContactModel{Id=7,UserName="asd",FirstName="Neil",LastName="Armstrong",HomePhone="222-012-7896",AddressId=1,PersonalEmail="armstrong@fast.ca"},

				new PersonalContactModel{Id=8,UserName="email",FirstName="Tony",LastName="Bennett",PersonalEmail="bennett@singer.jz"},
				new PersonalContactModel{Id=9,UserName="email",FirstName="Frank",LastName="Sinatra",PersonalEmail="sinatra@singer.jz"},
				new PersonalContactModel{Id=10,UserName="email",FirstName="Mel",LastName="Torme",PersonalEmail="torme@singer.jz"},
				new PersonalContactModel{Id=11,UserName="email",FirstName="Frankie",LastName="Avalon",PersonalEmail="avalon@singer.jz"},
				new PersonalContactModel{Id=12,UserName="email",FirstName="Dean",LastName="Martin",PersonalEmail="dean@singer.jz"},
				new PersonalContactModel{Id=13,UserName="email",FirstName="Sammy",LastName="Davis Jr.",PersonalEmail="sammy@singer.jz"},

				new PersonalContactModel{Id=14,UserName="User",FirstName="Mr.",LastName="Email"},
				new PersonalContactModel{Id=15,UserName="User",FirstName="Ascot",LastName="Dingleberry"}
			};

			contacts.ForEach ( s => context.PersonalContacts.AddOrUpdate ( s ) );

			context.SaveChanges ( );

			var activityContext = new AcmeWidget.DAL.ActivityContext();

			var activities = new List<ActivityModel>
			{
				new ActivityModel { ActivityType="Christmas Party" , Description = "Lots of Egg Nog"},
				new ActivityModel { ActivityType="Corporate Retreat" , Description = "R & R"},
				new ActivityModel { ActivityType="Beer Pong" , Description = "Beer. And pong."},
				new ActivityModel { ActivityType="Beer Yoga" , Description = ""},
				new ActivityModel { ActivityType="Inappropriate Valentine's Day cards" , Description = "More HR dictum."},
				new ActivityModel { ActivityType="Group Hugs" , Description = "Postponed indefinitely.  Thanks Gary:("},
				new ActivityModel { ActivityType="Bring your kids to work day" , Description = ""},
				new ActivityModel { ActivityType="Bring your pets to work day" , Description = ""},
				new ActivityModel { ActivityType="Evil HR ladies' Team Building Exercise" , Description = "You had me at evil."},
				new ActivityModel { ActivityType="Annual desk-a-thon" , Description = "Clean it or lose it."}
			};

			activities.ForEach ( a => activityContext.Activities.AddOrUpdate ( a ) );

			activityContext.SaveChanges ( );

			SeedMembership ( );
		}

		/// <summary>
		/// 
		/// </summary>
		private void SeedMembership ( )
		{
			WebSecurity.InitializeDatabaseConnection (
				"DefaultConnection" ,
					"UserProfile" ,
						"UserId" ,
							"UserName" ,
								autoCreateTables: true );

			var roles = new SimpleRoleProvider ( Roles.Provider );

			var membership = ( SimpleMembershipProvider )Membership.Provider;

			if ( !roles.RoleExists ( "User" ) )
			{
				roles.CreateRole ( "User" );
			}

			if ( membership.GetUser ( "asd" , false ) == null )
			{
				membership.CreateUserAndAccount ( "asd" , "qwe123" );
			}

			if ( !roles.GetRolesForUser ( "asd" ).Contains ( "User" ) )
			{
				roles.AddUsersToRoles ( new [ ] { "asd" } , new [ ] { "User" } );
			}

			if ( !roles.RoleExists ( "Admin" ) )
			{
				roles.CreateRole ( "Admin" );
			}

			if ( membership.GetUser ( "email" , false ) == null )
			{
				membership.CreateUserAndAccount ( "email" , "sha256" );
			}

			if ( !roles.GetRolesForUser ( "email" ).Contains ( "Admin" ) )
			{
				roles.AddUsersToRoles ( new [ ] { "email" } , new [ ] { "Admin" } );
			}
		}
	}
}
