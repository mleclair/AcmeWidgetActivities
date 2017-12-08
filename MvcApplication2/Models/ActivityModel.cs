using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Device.Location;

namespace AcmeWidget.Models
{
	[Table("Activity")]
	public class ActivityModel
	{
		#region Private Members

		private int id;
		private string activityType;
		private string description;

		#endregion Private Members


		#region Public Properties

		[Required]
		[Key]
		[Display ( Name = "Activity ID" )]
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		[Required]
		[MinLength ( 1 )]
		[MaxLength ( 256 )]
		[Display ( Name = "Activity" )]
		public string ActivityType
		{
			get { return activityType; }
			set { activityType = value; }
		}

		[Display ( Name = "Description" )]
		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		#endregion Public Properties


		#region Constructors

		public ActivityModel ( ) { }

		#endregion Constructors
	}
}