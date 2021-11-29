using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beneficiary;
using Vaccination;
namespace VaccinationDrive
{
    class VaccinationProgram
    {
      
        static void Main(string[] args)
        {
           List<BeneficiaryDetails> User = new List<BeneficiaryDetails>();

            int homePageVariable = 0;
            Console.WriteLine("Welcome for Vaccination Registraion and Vaccination Drive\n");
            do
            {
                Console.Write("Enter Corresponding Number to Select the Option:" +
                    "\n1.Registration" +
                    "\n2.Vaccination" +
                    "\n3.Exit\n" +
                    "\n Enter Your Choice:");
                homePageVariable = int.Parse(Console.ReadLine());
                switch (homePageVariable)
                {
                    case 1:
                        GetBeneficiaryDetails();
                        homePageVariable = 0; break;

                    case 2:
                        VaccinationProcess();
                        homePageVariable = 0; break;

                    case 3:
                        Console.WriteLine("\n Thank You !!!...\n Exiting the Application");
                        homePageVariable = 1; break;

                    default:
                        Console.WriteLine("Invalid Input Try Again");
                        homePageVariable = 0; break;

                }

            } while (homePageVariable == 0);


            void GetBeneficiaryDetails()
            {

                Console.WriteLine("Enter your name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter your your Age:");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Choose your Gender:\n1.Male\n2.Female\n3.Transgender");
                int gender = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your Phone number:");
                long mobile = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter your Address:");
                string address = Console.ReadLine();
                BeneficiaryDetails TemporaryUser = new BeneficiaryDetails(name, mobile, address, age, gender);
                Console.WriteLine($"Hi {TemporaryUser.Name} your Registration ID is {TemporaryUser.RegistrationID}");
                User.Add(TemporaryUser);

            }

            

            void VaccinationProcess()
            {
                Console.WriteLine("Enter your registration ID:");
                int registrationId = int.Parse(Console.ReadLine());
                BeneficiaryDetails currentUser = null;
                foreach (BeneficiaryDetails temporaryUser in User)
                {
                    if (registrationId == temporaryUser.RegistrationID)
                    {
                        currentUser = temporaryUser;
                    }
                }

                if (currentUser != null)
                {
                    int vaccinationVariable = 0;
                    do
                    {


                        Console.Write("Enter Corresponding Number to Select the Option:" +
                             "\n1.Vaccination" +
                             "\n2.Vaccination Details" +
                             "\n3.Vaccination Due Date\n" +
                             "\n4.Exit" +
                             "\n Enter Your Choice:");
                        vaccinationVariable = int.Parse(Console.ReadLine());
                        switch (vaccinationVariable)
                        {
                            case 1:

                                do
                                {

                                    Console.WriteLine("Enter corresponding number choose your Vaccine:\n1.Covaxin\n2.Covishield\n3.Sputnik");
                                    int vaccineType = int.Parse(Console.ReadLine());
                                    if (currentUser.VaccinatedDetails.Count == 0)
                                    {
                                        Console.WriteLine("Enter Date in dd/mm/yyyy");
                                        string enteredDate = Console.ReadLine();
                                        string[] splitDate = enteredDate.Split('/');
                                        DateTime date = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));
                                        Console.WriteLine($"You are Vaccinated {currentUser.Vaccinate(vaccineType, date)}");
                                        break;
                                    }
                                    else if (currentUser.VaccinatedDetails.Count == 1)
                                    {
                                        if ((VaccineType)vaccineType == currentUser.VaccinatedDetails[0].Vaccine)
                                        {
                                            Console.WriteLine("Enter Date in dd/mm/yyyy");
                                            string enteredDate = Console.ReadLine();
                                            string[] splitDate = enteredDate.Split('/');
                                            DateTime date = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));
                                            Console.WriteLine(currentUser.Vaccinate(vaccineType, date));
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"You have selected different vaccine. Your First vaccine is {currentUser.VaccinatedDetails[0].Vaccine}");
                                        }
                                    }

                                } while (true);
                                vaccinationVariable = 0; break;

                            case 2:
                                foreach (VaccineDetails detail in currentUser.VaccinatedDetails)
                                {
                                    Console.WriteLine($"Vaccine: {detail.Vaccine} | Dosage:{detail.Dosage} dose | Date:{detail.VaccinatedDate.ToString("dd/MM/yyyy")}");
                                }
                                vaccinationVariable = 0; break;
                            case 3:
                                Console.WriteLine(currentUser.DueDate());
                                vaccinationVariable = 0; break;

                            case 4:
                                Console.WriteLine("\nExiting the Vaccination Process \n");
                                vaccinationVariable = 1; break;

                            default:
                                Console.WriteLine("Invalid Input Try Again");
                                vaccinationVariable = 0; break;

                        }

                    } while (vaccinationVariable == 0);
                }

                
                Console.ReadKey();

            }

        

        

         

        }

       
    }
}

        

