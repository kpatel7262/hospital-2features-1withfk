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
    public class AreaServedController : Controller
    {
        //db context
        private HospitalContext db = new HospitalContext();

        // GET: AreaServed
        public ActionResult List(string areasearchkey, int pagenum = 0)
        {

            //can we access the search key?
            //Debug.WriteLine("The search key is "+areasearchkey);

            string query = "Select * from AreaServed";

            List<SqlParameter> sqlparams = new List<SqlParameter>();

            if (areasearchkey != "")
            {
                //modify the query to include the search key
                query = query + " where AreaServed_name like @searchkey";
                sqlparams.Add(new SqlParameter("@searchkey", "%" + areasearchkey + "%"));
                //Debug.WriteLine("The query is "+ query);
            }

            List<AreaServed> area = db.AreaServed.SqlQuery(query, sqlparams.ToArray()).ToList();

            //Start of Pagination Algorithm (Raw MSSQL)
            int perpage = 3;
            int areacount = area.Count();
            int maxpage = (int)Math.Ceiling((decimal)areacount / perpage) - 1;
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

                if (areasearchkey != "")
                {
                    newparams.Add(new SqlParameter("@searchkey", "%" + areasearchkey + "%"));
                    ViewData["areasearchkey"] = areasearchkey;
                }
                newparams.Add(new SqlParameter("@start", start));
                newparams.Add(new SqlParameter("@perpage", perpage));
                string pagedquery = query + " order by AreaServed_id offset @start rows fetch first @perpage rows only ";
                Debug.WriteLine(pagedquery);
                Debug.WriteLine("offset " + start);
                Debug.WriteLine("fetch first " + perpage);
                area = db.AreaServed.SqlQuery(pagedquery, newparams.ToArray()).ToList();
            }
            //End of Pagination Algorithm

            return View(area);
        }

        public ActionResult New()
        {
            //add new area
            return View();
        }

        [HttpPost]
        public ActionResult New(string AreaServed_name)
        {

            //add area
            string query = "insert into AreaServed (AreaServed_name) values(@AreaServed_name)";
            SqlParameter[] sqlparams = new SqlParameter[1];
            sqlparams[0] = new SqlParameter("@AreaServed_name", AreaServed_name);
            
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }

        public ActionResult Update(int id)
        {
            //fetch existed details of the areas
            string query = "select * from AreaServed where AreaServed_id = @id";
            var parameter = new SqlParameter("@id", id);
            AreaServed selectedArea = db.AreaServed.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedArea);
        }

        //update existed details
        [HttpPost]
        public ActionResult Update(int id, string AreaServed_name)
        {
            //Debug.WriteLine("selected remedy is" + id);
            string query = "Update AreaServed set AreaServed_name=@AreaServed_name where AreaServed_id=@id";
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0] = new SqlParameter("@AreaServed_name", AreaServed_name);
            sqlparams[1] = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");

        }

        public ActionResult Delete(int id)
        {
            string query = "Select * from AreaServed where AreaServed_id=@id";
            var parameter = new SqlParameter("@id", id);
            AreaServed selectedarea = db.AreaServed.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedarea);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            string query = "Delete from AreaServed where AreaServed_id=@id";
            var parameter = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, parameter);
            return RedirectToAction("List");
        }
    }
}