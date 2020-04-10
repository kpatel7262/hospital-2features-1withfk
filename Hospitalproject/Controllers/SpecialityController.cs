using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
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
    public class SpecialityController : Controller
    {   //create db context
        private HospitalContext db = new HospitalContext();
        // GET: Speciality
        public ActionResult List()
        {
            string query = "Select * from specialities";
            List<Speciality> specialities = db.Specialities.SqlQuery(query).ToList();
            return View(specialities);
            /*to do- search functionality*/
        }

        public ActionResult New()
        {
            //This method only needs the add page, Nothing from the db
            return View();
        }
        [HttpPost]
        public ActionResult New(string SpecialityName)
        {
            /*This method takes in a new speciality name and writes it to the DB*/
            string query = "insert into specialities (Name) values(@SpecialityName)";
            var parameter = new SqlParameter("@SpecialityName", SpecialityName);

            db.Database.ExecuteSqlCommand(query, parameter);
            return RedirectToAction("List");
        }
        public ActionResult Update(int id)
        {
            /*this method will show the base info of the selected record*/
            Debug.WriteLine("I am trying to update record with id"+id);
            string query = "select * from specialities where specialityid = @id";
            var parameter = new SqlParameter("@id", id);
            Speciality selectedspeciality = db.Specialities.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedspeciality);
        }
        //now the post method when the user clicks on update
        [HttpPost]
        public ActionResult Update(int id,string SpecialityName)
        {
            Debug.WriteLine("I am trying to update record with id" + id);
            string query = "Update specialities set Name=@SpecialityName where specialityid=@id";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@SpecialityName", SpecialityName);
            parameters[1] = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, parameters);
            return RedirectToAction("List");

        }
        public ActionResult View(int id)
        {
            string query = "Select * from specialities where specialityid=@id";
            var parameter = new SqlParameter("@id", id);
            Speciality selectedspeciality = db.Specialities.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedspeciality);

        }
        
        public ActionResult Delete(int id)
        {
            string query = "Select * from specialities where specialityid=@id";
            var parameter = new SqlParameter("@id", id);
            Speciality selectedspeciality = db.Specialities.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedspeciality);
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            string query = "Delete from specialities where specialityid=@id";
            var parameter = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, parameter);
            return RedirectToAction("List");
        }
    }
}