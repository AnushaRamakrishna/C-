using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
   
    
    public enum Gender
    {
        male = 1, female, transgender
    }
    class BenificiaryDetails
    {
        public static int InitialregistrationNumber = 310001;


        public string beneficiaryName { get; set; }
        public double phoneNumber { get; set; }
        public string city { get; set; }
        public int age { get; set; }

        public Gender gender { get; set; }
        public object VaccineDetails { get; internal set; }
        public object VaccinationDetails { get; internal set; }

        public int RegistrationNumber;

        public List<VaccinationDetails> VaccinationData { get; set; }
        public BenificiaryDetails(string beneficiaryName, double phoneNumber, string city, int age, Gender gender)
        {

            
            this.beneficiaryName = beneficiaryName;
            this.phoneNumber = phoneNumber;
            this.city = city;
            this.age = age;
            this.gender = gender;
            this.RegistrationNumber = InitialregistrationNumber++;


        }
    }
}

