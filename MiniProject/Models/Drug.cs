using System;
using System.ComponentModel.DataAnnotations;
using MiniProject.Repository;

namespace MiniProject
{
    public class Drugs
    {


        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public DateTime ManufacturedDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        //public DrugLocation DrugLocation { get; set; }
    }
    }

