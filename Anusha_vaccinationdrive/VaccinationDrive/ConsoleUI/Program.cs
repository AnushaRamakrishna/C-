using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleUI
{

    class Program
    {
        public static List<BenificiaryDetails> beneficiaryList = new List<BenificiaryDetails>();

        static void Main(string[] args)
        {
            //creating object

            Program User = new Program();

            User.DefaultDetails();
            string Option = string.Empty;
            do
            {
                int Choice = 0;
                do
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine("-------------------------------Vaccination Management System-----------------------------------------");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine("select the option which you want to choose \n 1.Beneficiary Registration \n 2.vaccination \n 3.exit");
                    Choice = int.Parse(Console.ReadLine());
                    switch (Choice)
                    {
                        case 1:
                            //creating method and adding it into user object

                            User.Beneficiary();
                            break;

                        case 2:
                            User.Vaccination();
                            break;
                        case 3:
                            Environment.Exit(-1);
                            break;
                        default:
                            Console.WriteLine("------------------invalid option-------------------");
                            break;

                    }
                } while (Option != "yes" && Option != "no");

            } while (Option == "yes");
            Console.ReadKey();
        }

        public void Beneficiary()
        {
            string Option = "";
            do
            {
                Console.WriteLine("enter your name : ");
                string name = Console.ReadLine();
                Console.WriteLine("enter your phonenumber : ");
                double number = double.Parse(Console.ReadLine());
                Console.WriteLine("enter your city : ");
                string city = Console.ReadLine();
                Console.WriteLine("enter your age : ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("enter your gender choose from \n 1. male \n 2. female \n 3. transgender");
                Gender gender = (Gender)int.Parse(Console.ReadLine());
                var Details = new BenificiaryDetails(name, number, city, age, gender);
                beneficiaryList.Add(Details);
                Console.WriteLine($"-----------your details added successfully------------\n your Register number is {Details.RegistrationNumber}");

                Console.WriteLine("do you want to continue??? yes or no");
                Option = Console.ReadLine().ToLower();

            } while (Option == "yes");
            Console.ReadKey();
        }
        public void DefaultDetails()
        {
            var user1 = new BenificiaryDetails("anu", 1234567890, "thiruvallur", 21, (Gender)1);
            var user2 = new BenificiaryDetails("priya", 1232345890, "chennai", 22, (Gender)1);
            var user3 = new BenificiaryDetails("sivapriya", 12345690, "anna nagar", 21, (Gender)1);

            //adding values into list

            beneficiaryList.Add(user1);
            beneficiaryList.Add(user2);
            beneficiaryList.Add(user3);


        }
        public void Vaccination()
        {
            int Choice = 0;
            string Option = "";
            Console.WriteLine("---------------Vaccination details--------------");
            Console.WriteLine("enter your registration number : ");
            int num = int.Parse(Console.ReadLine());
            foreach (BenificiaryDetails details1 in beneficiaryList)
            {
                if (details1.RegistrationNumber == num)
                {
                    do
                    {
                        Console.WriteLine("choose any of the option \n1.Take vaccination \n2.Vaccination History \n3.Next due date \n4.Exit");
                        Choice = int.Parse(Console.ReadLine());
                        switch (Choice)
                        {
                            case 1:
                                Console.WriteLine("-------------------Take vaccine----------------------");
                                Console.WriteLine("what type of vaccine do you prefer?? \n1.covidvaccine \n2.covidshield \n3.sputnik");
 
                               
                                if (details1.RegistrationNumber == num)
                                {
                                       
                                    List<VaccinationDetails> details = new List<VaccinationDetails>();
                                    VaccineType vaccineType = (VaccineType)int.Parse(Console.ReadLine());
                                    VaccinationDetails user = new VaccinationDetails(vaccineType, DateTime.Now);
                                    if (details1.VaccinationData == null)
                                    {
                                        details1.VaccinationData = new List<VaccinationDetails>();

                                    }
                                    details1.VaccinationData.Add(user);

                                }
                                                          
                                Console.WriteLine("Vaccinated successfully!!!!");
                                break;
                            case 2:
                                Console.WriteLine("--------------------------vaccination history---------------------");
                                VaccineWithBeneficiaryDetails(num);
                                break;
                            case 3:
                                Console.WriteLine("-------------------next due date---------------------------");
                                NextDueDate(num);
                                break;
                            case 4:
                                break;
                            default:
                                Console.WriteLine("invalid option");
                                break;
                        }
                        Console.WriteLine("do you want to continue yes or no");
                        Option = Console.ReadLine().ToLower();

                    } while (Option == "yes");
                }

            }
        }
        public static void VaccineWithBeneficiaryDetails(int registernumber)
        {
            foreach (BenificiaryDetails i in beneficiaryList)
            {
                if(i.RegistrationNumber == registernumber)
                {
                    if(i.VaccinationData != null)
                    {
                        Console.WriteLine($"Name : {i.beneficiaryName} \n Age : {i.age} \n Gender : {i.gender} \n Phonenumber : {i.phoneNumber} \n City : {i.city} \n vaccination : {i.VaccinationData[0].vaccineType}");
                    }
                }
            }
        }
        public static void NextDueDate(int registerId)
        {
            foreach (BenificiaryDetails j in beneficiaryList)
            {
                if(j.RegistrationNumber == registerId)
                {
                    if(j.VaccinationDetails != null)
                    {
                        if(j.VaccinationData.Count== 1)
                        {
                            Console.WriteLine($"next due date for registration number {j.RegistrationNumber} is {j.VaccinationData[0].dateOfDose.AddDays(15)}");
                        }
                        else if(j.VaccinationData.Count ==2)
                        {
                            Console.WriteLine("---------------------------you have successfully completed the course!!------------------------------------");
                            Console.WriteLine("---------------------------Thankyou for your participation-----------------------------------------------");
                        }
                    }
                }
            }
        }
    }
    
}
