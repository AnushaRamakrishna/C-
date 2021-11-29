using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    
        public  enum VaccineType
        {
            covidVaccine = 1,
            covidShield,
            sputnik

        }
        public class VaccinationDetails
        {
            public VaccineType vaccineType { get; set; }
            public DateTime dateOfDose { get; set; }
            public string VaccinationDetail { set; get; }
            
        
            public VaccinationDetails(VaccineType vaccineType, DateTime dateOfDose)
            {
                this.dateOfDose = dateOfDose;
                this.vaccineType = vaccineType;
            }
        }

}
