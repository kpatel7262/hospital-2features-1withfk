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
using Hospitalproject.Models.ViewModels;
using System.Diagnostics;


namespace Hospitalproject.Controllers
{
    public class HomeRemediesController : Controller
    {
        //db context
        private HospitalContext db = new HospitalContext();

        //Get remedies list for user to see
        public ActionResult User_list(string remedysearchkey, int pagenum = 0)
        {
            //can we access the search key?
            //Debug.WriteLine("The search key is "+remedysearchkey);



            string query = "Select * from HomeRemedies"; //order by is needed for offset
            //easier in a list.. we don't know how many more we'll add yet
            List<SqlParameter> sqlparams = new List<SqlParameter>();

            if (remedysearchkey != "")
            {
                //modify the query to include the search key
                query = query + " where HomeRemedies_title like @searchkey";
                sqlparams.Add(new SqlParameter("@searchkey", "%" + remedysearchkey + "%"));
                //Debug.WriteLine("The query is "+ query);
            }

            List<HomeRemedies> remedy = db.HomeRemedies.SqlQuery(query, sqlparams.ToArray()).ToList();

            //Start of Pagination Algorithm (Raw MSSQL)
            int perpage = 3;
            int remcount = remedy.Count();
            int maxpage = (int)Math.Ceiling((decimal)remcount / perpage) - 1;
            if (maxpage < 0) maxpage = 0;
            if (pagenum < 0) pagenum = 0;
            if (pagenum > maxpage) pagenum = maxpage;
            int start = (int)(perpage * pagenum);
            ViewData["pagenum"] = pagenum;
            ViewData["pagesummary"] = "";
            if (maxpage > 0)
            {
                ViewData["pagesummary"] = (pagenum + 1) + " of " + (maxpage + 1);
                List<SqlParameter> newparams = new List<SqlParameter>();

                if (remedysearchkey != "")
                {
                    newparams.Add(new SqlParameter("@searchkey", "%" + remedysearchkey + "%"));
                    ViewData["remedysearchkey"] = remedysearchkey;
                }
                newparams.Add(new SqlParameter("@start", start));
                newparams.Add(new SqlParameter("@perpage", perpage));
                string pagedquery = query + " order by HomeRemedies_id offset @start rows fetch first @perpage rows only ";
                Debug.WriteLine(pagedquery);
                Debug.WriteLine("offset " + start);
                Debug.WriteLine("fetch first " + perpage);
                remedy = db.HomeRemedies.SqlQuery(pagedquery, newparams.ToArray()).ToList();
            }
            //End of Pagination Algorithm

            return View(remedy);
        }


        // GET: HomeRemedies
        public ActionResult List(string remedysearchkey, int pagenum = 0)
        {
            //can we access the search key?
            //Debug.WriteLine("The search key is "+remedysearchkey);
            
            string query = "Select * from HomeRemedies"; //order by is needed for offset
            //easier in a list.. we don't know how many more we'll add yet
            List<SqlParameter> sqlparams = new List<SqlParameter>();

            if (remedysearchkey != "")
            {
                //modify the query to include the search key
                query = query + " where HomeRemedies_title like @searchkey";
                sqlparams.Add(new SqlParameter("@searchkey", "%" + remedysearchkey + "%"));
                //Debug.WriteLine("The query is "+ query);
            }

            List<HomeRemedies> remedy = db.HomeRemedies.SqlQuery(query, sqlparams.ToArray()).ToList();

            //Start of Pagination Algorithm (Raw MSSQL)
            int perpage = 3;
            int remcount = remedy.Count();
            int maxpage = (int)Math.Ceiling((decimal)remcount / perpage) - 1;
            if (maxpage < 0) maxpage = 0;
            if (pagenum < 0) pagenum = 0;
            if (pagenum > maxpage) pagenum = maxpage;
            int start = (int)(perpage * pagenum);
            ViewData["pagenum"] = pagenum;
            ViewData["pagesummary"] = "";
            if (maxpage > 0)
            {
                ViewData["pagesummary"] = (pagenum + 1) + " of " + (maxpage + 1);
                List<SqlParameter> newparams = new List<SqlParameter>();

                if (remedysearchkey != "")
                {
                    newparams.Add(new SqlParameter("@searchkey", "%" + remedysearchkey + "%"));
                    ViewData["remedysearchkey"] = remedysearchkey;
                }
                newparams.Add(new SqlParameter("@start", start));
                newparams.Add(new SqlParameter("@perpage", perpage));
                string pagedquery = query + " order by HomeRemedies_id offset @start rows fetch first @perpage rows only ";
                Debug.WriteLine(pagedquery);
                Debug.WriteLine("offset " + start);
                Debug.WriteLine("fetch first " + perpage);
                remedy = db.HomeRemedies.SqlQuery(pagedquery, newparams.ToArray()).ToList();
            }
            //End of Pagination Algorithm

            return View(remedy);
        }

        public ActionResult New()
        {
            //add new remedy
            string query = "Select * from RemedySources";
            List<RemedySource> remedySources = db.RemedySource.SqlQuery(query).ToList();
            return View(remedySources);

        }

        [HttpPost]
        public ActionResult New(string HomeRemedies_title, string HomeRemedies_desc, string remedySource)
        {

            //add remedy
            string query = "insert into HomeRemedies (HomeRemedies_title, HomeRemedies_desc, RemedySource_id) values(@HomeRemedies_title,@HomeRemedies_desc, @remedySource)";
            SqlParameter[] sqlparams = new SqlParameter[3];
            sqlparams[0] = new SqlParameter("@HomeRemedies_title", HomeRemedies_title);
            sqlparams[1] = new SqlParameter("@HomeRemedies_desc", HomeRemedies_desc);
            sqlparams[2] = new SqlParameter("@remedySource", remedySource);

            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }


        public ActionResult Update(int id)
        {
            //fetch existed details of the remedy
            string query = "select * from HomeRemedies where HomeRemedies_id = @id";
            SqlParameter parameter = new SqlParameter("@id", id);
            HomeRemedies selectedHomeRemedies = db.HomeRemedies.SqlQuery(query, parameter).FirstOrDefault();

            string urlQuery = "Select * from RemedySources";
            List<RemedySource> selectedsrc = db.RemedySource.SqlQuery(urlQuery).ToList();
            
            var UpdateHomeRemedy = new UpdateHomeRemedy();
            UpdateHomeRemedy.HomeRemedies = selectedHomeRemedies;
            UpdateHomeRemedy.RemedySources = selectedsrc;

            return View(UpdateHomeRemedy);
        }

        //update existed details
        [HttpPost]
        public ActionResult Update(int id, string HomeRemedies_title, string HomeRemedies_desc, string RemedySource_id)
        {
            //Debug.WriteLine("selected remedy is" + id);
            string query = "Update HomeRemedies set HomeRemedies_title=@HomeRemedies_title, HomeRemedies_desc=@HomeRemedies_desc, RemedySource_id=@RemedySource_id  where HomeRemedies_id=@id";
            SqlParameter[] sqlparams = new SqlParameter[4];
            sqlparams[0] = new SqlParameter("@HomeRemedies_title", HomeRemedies_title);
            sqlparams[1] = new SqlParameter("@HomeRemedies_desc", HomeRemedies_desc);
            sqlparams[2] = new SqlParameter("@RemedySource_id", RemedySource_id);
            sqlparams[3] = new SqlParameter("@id",id);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");

        }
        public ActionResult View(int id)
        {
            string query = "Select * from HomeRemedies where HomeRemedies_id=@id";
            var parameter = new SqlParameter("@id", id);
            HomeRemedies selectedHomeRemedies = db.HomeRemedies.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedHomeRemedies);

        }

        public ActionResult User_view(int id)
        {
            string query = "Select * from HomeRemedies where HomeRemedies_id=@id";
            var parameter = new SqlParameter("@id", id);
            HomeRemedies selectedHomeRemedies = db.HomeRemedies.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedHomeRemedies);

        }

        public ActionResult Delete(int id)
        {
            string query = "Select * from HomeRemedies where HomeRemedies_id=@id";
            var parameter = new SqlParameter("@id", id);
            HomeRemedies selectedHomeRemedies = db.HomeRemedies.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedHomeRemedies);
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            string query = "Delete from HomeRemedies where HomeRemedies_id=@id";
            var parameter = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, parameter);
            return RedirectToAction("List");
        }

    }
}