using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AcmeWidget.Models
{
	[Table("ActivitySignUp")]
	public class ActivitySignUpModel
	{
		[Required]
		[Key]
		[Display ( Name = "Id" )]
		public int Id { get; set; }

		[Required]
		[MinLength ( 1 )]
		[MaxLength ( 256 )]
		[Display ( Name = "First Name" )]
		public string FirstName { get; set; }

		[Required]
		[MinLength ( 1 )]
		[MaxLength ( 256 )]
		[Display ( Name = "Last Name" )]
		public string LastName { get; set; }

		[Required]
		[Display ( Name = "Email Address" )]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[Display ( Name = "ActivityId" )]
		[ForeignKey( "" )]
		public int ActivityId { get; set; }

		[Display ( Name = "Comments" ) ]
		public string Comments { get; set; }
	}
}