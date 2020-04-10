using System;
using System.Collections.Generic;
using System.Data;
//sql Parameteres
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospitalproject.Data;
using Hospitalproject.Models;
using System.Diagnostics;

namespace Hospitalproject.Controllers
{
    public class SocialServiceClubsController : Controller
    {
        //db context
        private HospitalContext db = new HospitalContext();

        // GET: SocialServiceClubs
        public ActionResult List()
        {
            string query = "Select * from SocialServiceClubs";
            List<SocialServiceClubs> SocialServiceClubs = db.SocialServiceClubs.SqlQuery(query).ToList();
            return View(SocialServiceClubs);
        }

        public ActionResult New()
        {
            //add new remedy
            return View();
        }

        [HttpPost]
        public ActionResult New(string SocialServiceClubs_title, string SocialServiceClubs_details, string SocialServiceClubs_address)
        {
            //add social service clubs
            string query = "insert into SocialServiceClubs (SocialServiceClubs_title, SocialServiceClubs_details, SocialServiceClubs_address) values(@SocialServiceClubs_title,@SocialServiceClubs_details,@SocialServiceClubs_address)";
            SqlParameter[] sqlparams = new SqlParameter[3];
            sqlparams[0] = new SqlParameter("@SocialServiceClubs_title", SocialServiceClubs_title);
            sqlparams[1] = new SqlParameter("@SocialServiceClubs_details", SocialServiceClubs_details);
            sqlparams[2] = new SqlParameter("@SocialServiceClubs_address", SocialServiceClubs_address);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }

        public ActionResult Update(int id)
        {
            //fetch existed details of the remedy
            string query = "select * from SocialServiceClubs where SocialServiceClubs_id = @id";
            var parameter = new SqlParameter("@id", id);
            SocialServiceClubs selectedSocialServiceClub = db.SocialServiceClubs.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedSocialServiceClub);
        }

        //update existed details
        [HttpPost]
        public ActionResult Update(int id, string SocialServiceClubs_title, string SocialServiceClubs_details, string SocialServiceClubs_address)
        {
            //Debug.WriteLine("selected club is" + id);
            string query = "Update SocialServiceClubs set SocialServiceClubs_title=@SocialServiceClubs_title, SocialServiceClubs_details=@SocialServiceClubs_details, SocialServiceClubs_address=@SocialServiceClubs_address where SocialServiceClubs_id=@id";
            SqlParameter[] sqlparams = new SqlParameter[4];
            sqlparams[0] = new SqlParameter("@SocialServiceClubs_title", SocialServiceClubs_title);
            sqlparams[1] = new SqlParameter("@SocialServiceClubs_details", SocialServiceClubs_details);
            sqlparams[2] = new SqlParameter("@SocialServiceClubs_address", SocialServiceClubs_address);
            sqlparams[3] = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");

        }
        public ActionResult View(int id)
        {
            string query = "Select * from SocialServiceClubs where SocialServiceClubs_id=@id";
            var parameter = new SqlParameter("@id", id);
            SocialServiceClubs selectedSocialServiceClub = db.SocialServiceClubs.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedSocialServiceClub);

        }

        public ActionResult Delete(int id)
        {
            string query = "Select * from SocialServiceClubs where SocialServiceClubs_id=@id";
            var parameter = new SqlParameter("@id", id);
            SocialServiceClubs selectedSocialServiceClub = db.SocialServiceClubs.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedSocialServiceClub);
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            string query = "Delete from SocialServiceClubs where SocialServiceClubs_id=@id";
            var parameter = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, parameter);
            return RedirectToAction("List");
        }
    }
}