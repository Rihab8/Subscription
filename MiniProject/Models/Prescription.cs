using System;
using System.ComponentModel.DataAnnotations;

namespace MiniProject
{
    public class Prescription
    {
        [Key]
        public int Prep_id { get; set; }
        public int MemberID { get; set; }
        //public int Insurance_Policy_Number { get; set; }
        //public string InsuranceProvider { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public int drugID { get; set; }
        //public string dosage { get; set; }
       // public string PrescriptionCourse { get; set; }
        //public string Doctordetails { get; set; }
    }
}
