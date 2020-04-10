using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospitalproject.Models
{
    public class Volunteer
    {
        /*This class defines a doctor.
          Let's see what defines a doctor in general or what is the idea of a doctor
          ID
          Title
          First Name
          Last Name
          It also needs to reference the speciality
       */
        [Key]
        public int VolunteerID { get; set; }
        public string VolunteerFname { get; set; }
        public string VolunteerLname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Skills { get; set; }
        //Day is Monday, Tuesday , Wednesday and so on.
        public string Day { get; set; }
        //Time is specific time of the day, Morning, Afternoon, Evening
        //This values are Morning 8:00am- 12:00am, Afternoon 1pm-5pm, Evening 6pm-10pm
        public string Time { get; set; }
        //List of Department Child Care, Emergency, 
        public string Department { get; set; }
        public string Notes { get; set; }

       


    }
}