using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gizatullina_BPI_24_01_L1part1
{
    class worker
    {
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public int YearOfEmployment { get; set; }

        public worker(string surname, decimal salary, int yearOfEmployment)
        {
            Surname = surname;
            Salary = salary;
            YearOfEmployment = yearOfEmployment;
        }


        public int CalculateExperience()
        {
            return DateTime.Now.Year - YearOfEmployment;
        }


        public int CalculateDays()
        {
            DateTime startDate = new DateTime(YearOfEmployment, 1, 1);
            return (DateTime.Now - startDate).Days;
        }
    }
}
