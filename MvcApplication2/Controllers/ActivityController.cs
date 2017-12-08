using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcmeWidget.Models;
using AcmeWidget.DAL;
using System.IO;

namespace AcmeWidget.Controllers
{
	//[Authorize]
	public class ActivityController : Controller
	{
		//private ActivationContext db = new ActivationContext ( );

		//
		// GET: /Activity/

		public ActionResult Index ( )
		{
			return View ( );
		}

		//
		// GET: /Activity/Details/5

		public ActionResult Details ( int id )
		{
			return View ( );
		}

		//
		// GET: /Activity/Create

		public ActionResult Create ( )
		{
			return View ( );
		}

		//
		// POST: /Activity/Create

		[HttpPost]
		public ActionResult Create ( FormCollection collection )
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction ( "Index" );
			}
			catch
			{
				return View ( );
			}
		}

		//
		// GET: /Activity/Edit/5

		public ActionResult Edit ( int id )
		{
			return View ( );
		}

		//
		// POST: /Activity/Edit/5

		[HttpPost]
		public ActionResult Edit ( int id , FormCollection collection )
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction ( "Index" );
			}
			catch
			{
				return View ( );
			}
		}

		//
		// GET: /Activity/Delete/5

		public ActionResult Delete ( int id )
		{
			return View ( );
		}

		//
		// POST: /Activity/Delete/5

		[HttpPost]
		public ActionResult Delete ( int id , FormCollection collection )
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction ( "Index" );
			}
			catch
			{
				return View ( );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose ( bool disposing )
		{
			//db.Dispose ( );
			base.Dispose ( disposing );
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ActionResult Activities( )
		{
			ActivityContext db = new ActivityContext ();

			return View( db.Activities.ToList ( ) );
		}

		///// <summary>
		///// 
		///// </summary>
		///// <returns></returns>
		//public IEnumerable<ActivityModel> ActivitiesList ( )
		//{
		//	ActivityContext db = new ActivityContext ( );

		//	//return Json ( new { result = db.Activities.ToList ( ) } , JsonRequestBehavior.AllowGet );

		//	return db.Activities.ToList ( );
		//}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult ActivitySignUp ( ActivityModel activity )
		{
			return PartialView ( "ActivitySignUp" ,
						new Tuple<AcmeWidget.Models.ActivityModel, AcmeWidget.Models.ActivitySignUpModel> ( 
							activity , new ActivitySignUpModel { ActivityId = activity.Id } ) );
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="signUp"></param>
		/// <returns></returns>
		public bool SignUp ( ActivitySignUpModel signUp )
		{
			try
			{
				ActivitySignUpContext db = new ActivitySignUpContext ( );

				db.ActivitySignUps.Add ( signUp );

				db.SaveChanges ( );

				return true;
			}
			catch ( System.Exception ex)
			{
				throw ex;
			}
		}


		public ActionResult SignedUp ( string personEmail )
		{
			ScheduledActivityModel scheduledActivities = new ScheduledActivityModel ( );

			// get all activities and attendees that the person is signed up for

			return PartialView ( "SignedUp" , scheduledActivities );
		}
	}
}
