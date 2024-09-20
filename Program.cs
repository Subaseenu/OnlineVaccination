using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace VaccinationApplication
{
    class Program
    {
        public static List<BeneficiaryDetails> benificiarydetailList = new List<BeneficiaryDetails>();
        public static List<VaccinationDetails> vaccinationdetailsList = new List<VaccinationDetails>();
        public static List<VaccineDetails> vaccinedetailsList = new List<VaccineDetails>();
        public static BeneficiaryDetails currentbenificiarydetails;

        public static void Main()
        {
            FileHandling.Create();
            FileHandling.ReadCSV();
            //AddDefaultData();
            Console.WriteLine("WELCOME TO VACCINATION DRIVE !");
            string option = "yes";
            do
            {
                Console.WriteLine("Choose This Option");
                Console.WriteLine("1 . Benificiary Registration");
                Console.WriteLine("2 . Login");
                Console.WriteLine("3 . GetVaccineInformation");
                Console.WriteLine("4 . Exit");
                string option1 = Console.ReadLine();



                switch (option1)
                {
                    case "1":
                        {
                            BeneficiaryRegistrationLogin();
                            break;
                        }
                    case "2":
                        {
                            Login();
                            break;
                        }
                    case "3":
                        {
                            GetVaccineInformation();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("THANK YOU!");
                            option = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("INVALID OPTION PLEASE TRY AGAIND..");
                            break;
                        }
                }



            } while (option == "yes");
            FileHandling.WriteCSV();
        }
        public static void AddDefaultData()
        {
            benificiarydetailList.Add(new BeneficiaryDetails("Ravichandran", 21, Gender.Male, 2345678999, "Chennai"));
            benificiarydetailList.Add(new BeneficiaryDetails("Baskaran", 22, Gender.Male, 23456789, "Chennai"));


            vaccinedetailsList.Add(new VaccineDetails(VacineName.Covishield, 50));
            vaccinedetailsList.Add(new VaccineDetails(VacineName.Covaccine, 50));



            DateTime date1 = new DateTime(2024, 03, 31);
            DateTime date2 = new DateTime(2024, 04, 30);
            DateTime date3 = new DateTime(2024, 05, 04);
            DateTime date4 = new DateTime(2024, 04, 05);
            vaccinationdetailsList.Add(new VaccinationDetails("BID1001", "CID2001", DoseNumber.Dose1, date1));
            vaccinationdetailsList.Add(new VaccinationDetails("BID1001", "CID2001", DoseNumber.Dose2, date2));
            // vaccinationdetailsList.Add(new VaccinationDetails("BID1001", "CID2001", DoseNumber.Dose3, date4));
            vaccinationdetailsList.Add(new VaccinationDetails("BID1002", "CID2002", DoseNumber.Dose1, date3));
        }
        public static void BeneficiaryRegistrationLogin()
        {

            //get the user information

            string name = "";
            bool check = false;
            do
            {
                Console.WriteLine("Enter Your Name");
                name = Console.ReadLine();
                if (name.Contains("  ") || string.IsNullOrEmpty(name) || SpecialCase(name))
                {
                    check = false;
                    Console.WriteLine("Please Enter Valid Name");
                }
                else
                {
                    check = true;
                    break;
                }
            } while (!check);





            int Age;
            do
            {
                Console.WriteLine("Enter Your Age");
                string age = Console.ReadLine().Trim();
                if (int.TryParse(age, out Age) && age.Length == 2)
                {
                    if (Age > 0 && Age <= 80)
                    {

                        break;
                    }
                    else if (Age > 80)
                    {
                        Console.WriteLine("Your Not Eligible because Your Age Is Above 80");

                    }
                }
                else
                {
                    Console.WriteLine("Invalid Age Please Try Again");

                }

            } while (true);

            Gender gender1;
            do
            {
                //gender name
                Console.WriteLine("Enter Your Gender");
                string gender = Console.ReadLine().Trim();
                if (Enum.TryParse(gender, true, out gender1))
                {
                    if (int.TryParse(gender, out _))
                    {
                        Console.WriteLine("Gender Is Not a Integer Type Please Try Again");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input Please Try Again");
                }
            } while (true);

            int phonenumber;
            do
            {
                //mobile number
                Console.WriteLine("Enter Your Mobile Number (Must Be 10 Digits)");
                string mobilenumber = Console.ReadLine().Trim();
                if (int.TryParse(mobilenumber, out phonenumber) && mobilenumber.Length == 10)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Your Mobile Number");
                }


            } while (true);

            string city;
            do
            {
                // city
                Console.WriteLine("Enter Your City");
                city = Console.ReadLine();
                if (city.Contains("  ") || SpecialCase(city) || string.IsNullOrEmpty(city))
                {
                    Console.WriteLine("Please Enter Valid City Name");
                }
                else
                {
                    break;
                }
            } while (true);
            // create object benificiarydetails
            BeneficiaryDetails beneficiary = new BeneficiaryDetails(name, Age, gender1, phonenumber, city);
            // add it to the benificiary list
            benificiarydetailList.Add(beneficiary);
            // show registration succesful and display  Registration is succesfull!
            Console.WriteLine("YOUR REGISTRATION SUCCESSFULL!!");
            //display Registration number
            Console.WriteLine("Your Registration Number Is : " + beneficiary.RegistrationNumber);




        }
        //special case suppose the name was special character or  white space  so created the specialcase method
        public static bool SpecialCase(string name)
        {
            foreach (char name1 in name)
            {
                if (!char.IsLetter(name1) && !char.IsWhiteSpace(name1))
                {
                    return true;
                }
            }
            return false;
        }

        public static void Login()
        {

            //buy the registration number


            Console.WriteLine("Enter Your RegistrationNumber");
            string registrationnumber = Console.ReadLine().ToUpper();

            //check the benificiary register number in the benificiary detail list
            //if it is not found valid show invalid register number
            bool check = false;
            foreach (BeneficiaryDetails beneficiarydetails in benificiarydetailList)
            {
                if (beneficiarydetails.RegistrationNumber == registrationnumber)
                {
                    currentbenificiarydetails = beneficiarydetails;
                    check = true;
                    //submenu method called

                    Console.WriteLine("LOGIN SUCCESSFUL ..");
                    Submenu();
                    break;
                }

            }
            if (check == false)
            {
                Console.WriteLine("INVALID REGISTRATION NUMBER PLEASE TRAY AGAIN..");
            }





        }
        public static void Submenu()
        {
            //submenu called
            //show the submenu
            Console.WriteLine("SUBMENU");

            string check = "yes";
            do
            {
                Console.WriteLine("Choose This Choice");
                Console.WriteLine("1 . ShowMy Details");
                Console.WriteLine("2 . TakeVaccination");
                Console.WriteLine("3 . MyVaccination");
                Console.WriteLine("4 . NextDueDate");
                Console.WriteLine("5 . Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            // my details method called
                            ShowMyDetails();
                            break;
                        }
                    case "2":
                        {
                            //Take vaccination method called
                            TakeVaccination();
                            break;
                        }
                    case "3":
                        {

                            // my vaccination history method called
                            MyVaccinationHistory();
                            break;
                        }
                    case "4":
                        {
                            //Next Due Date method called
                            NextDueDate();
                            break;
                        }
                    case "5":
                        {
                            //Exit
                            Console.WriteLine("You Have Selected Exit");
                            check = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice");
                            break;
                        }
                }
            } while (check == "yes");

        }
        public static void ShowMyDetails()
        {
            Console.WriteLine("YOUR DETAILS");

            Console.WriteLine("Name         : " + currentbenificiarydetails.Name);
            Console.WriteLine("Age          : " + currentbenificiarydetails.Age);
            Console.WriteLine("Gender       : " + currentbenificiarydetails.Gender);
            Console.WriteLine("MobileNumber : " + currentbenificiarydetails.MobileNumber);
            Console.WriteLine("City         : " + currentbenificiarydetails.City);

        }
        public static void GetVaccineInformation()
        {
            Console.WriteLine("VACINE DETAILS");
            //show vaccineinformation
            foreach (VaccineDetails vaccineavailabledetails in vaccinedetailsList)
            {
                Console.WriteLine("Vaccine Available    : " + vaccineavailabledetails.VacineName);
                Console.WriteLine("NoOfDoseAvailable    : " + vaccineavailabledetails.NumberOfDoseAvailable);
                Console.WriteLine("VaccineID            : " + vaccineavailabledetails.VaccineID);

            }
        }

        public static void TakeVaccination()
        {
            //show vaccination avalable list so called getvaccineinformation
            GetVaccineInformation();
            // get one departmentid from user 
            Console.WriteLine("Pick One VaccineID");
            string vaccineid = Console.ReadLine().ToUpper();
            //check vaccine ID is valid
            // check user taken last vacinne
            // check number of doseavailable or not available
            bool vaccineId = false;
            bool register = false;

            foreach (VaccineDetails validvaccineID in vaccinedetailsList)
            {
                if (validvaccineID.VaccineID == vaccineid)
                {
                    vaccineId = true;
                    for (int i = vaccinationdetailsList.Count - 1; i >= 0; i--)
                    {
                        if (validvaccineID.NumberOfDoseAvailable > 0)
                        {

                            if (vaccinationdetailsList[i].RegistrationNumber == currentbenificiarydetails.RegistrationNumber)
                            {
                                register = true;

                                DoseNumber Dosenumber = vaccinationdetailsList[i].DoseNumber;
                                string VaccineID = vaccinationdetailsList[i].VacineId;
                                if (VaccineID == vaccineid)
                                {
                                    Console.WriteLine("Your Are Choose Correct VccineID ");

                                    if (DateTime.Now > vaccinationdetailsList[i].VaccinatedDate.AddDays(30))
                                    {

                                        if (Dosenumber == DoseNumber.Dose1)
                                        {
                                            validvaccineID.NumberOfDoseAvailable--;
                                            Console.WriteLine("VACCINATION DOSE 2 SUCCESSFUL!!.");
                                            VaccinationDetails vaccinateddetail = new VaccinationDetails(currentbenificiarydetails.RegistrationNumber, vaccineid, DoseNumber.Dose2, DateTime.Now);
                                            vaccinationdetailsList.Add(vaccinateddetail);
                                            break;
                                        }
                                        else if (Dosenumber == DoseNumber.Dose2)
                                        {
                                            validvaccineID.NumberOfDoseAvailable--;
                                            Console.WriteLine("VACCINATION DOSE 3 SUCCESSFUL!!.");
                                            VaccinationDetails vaccinateddetail = new VaccinationDetails(currentbenificiarydetails.RegistrationNumber, vaccineid, DoseNumber.Dose3, DateTime.Now);
                                            vaccinationdetailsList.Add(vaccinateddetail);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("All The three vaccination are completed ; You cannot be vaccinated now.");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You have did not completed 30 days taken vaccination");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Your Vaccination Id Is Wrong please choose Already taken VacccinationID");
                                    break;
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Sorry For The InConvinient DoseAvailability");
                            break;
                        }
                    }

                    if (register == false)
                    {
                        if (currentbenificiarydetails.Age > 14 && currentbenificiarydetails.Age < 80 && validvaccineID.NumberOfDoseAvailable > 0)
                        {
                            validvaccineID.NumberOfDoseAvailable--;
                            VaccinationDetails vaccinateddetail = new VaccinationDetails(currentbenificiarydetails.RegistrationNumber, vaccineid, DoseNumber.Dose1, DateTime.Now);
                            vaccinationdetailsList.Add(vaccinateddetail);
                            Console.WriteLine("Vaccination Dose1 successful!.");
                            break;
                        }
                        else if (currentbenificiarydetails.Age > 80)
                        {
                            Console.WriteLine("Your Not Eligible Take Vaccine Your Over To 80 ");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Your Not Eligible For Taken Vaccination");
                            break;
                        }
                    }
                }

            }
            if (vaccineId == false)
            {
                Console.WriteLine("Your VaccineID Is Wrong");
            }

        }
        public static void MyVaccinationHistory()
        {
            Console.WriteLine("YOUR VACCINATION HISTORY");
            bool flag = false;
            //show  current user vaccination history from vaccinatondetailList
            foreach (VaccinationDetails vaccinationhistory in vaccinationdetailsList)
            {
                if (currentbenificiarydetails.RegistrationNumber == vaccinationhistory.RegistrationNumber)
                {
                    flag = true;
                    Console.WriteLine("Vaccination Number  : " + vaccinationhistory.RegistrationNumber);
                    Console.WriteLine("VaccinationID       : " + vaccinationhistory.VaccinationID);
                    Console.WriteLine("Vacine ID           : " + vaccinationhistory.VacineId);
                    Console.WriteLine("Vacinate Date       : " + vaccinationhistory.VaccinatedDate.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Dose Number         : " + vaccinationhistory.DoseNumber);
                }
            }
            if (!flag)
            {
                Console.WriteLine("You havn't take any vaccine You have take vaccine Now");
            }
        }
        public static void NextDueDate()
        {
            bool check = false;
            for (int i = vaccinationdetailsList.Count - 1; i > 0; i--)
            {

                if (vaccinationdetailsList[i].RegistrationNumber == currentbenificiarydetails.RegistrationNumber)
                {
                    check = true;
                    DoseNumber Dosenumber = vaccinationdetailsList[i].DoseNumber;
                    if (Dosenumber == DoseNumber.Dose1 || Dosenumber == DoseNumber.Dose2)
                    {

                        Console.WriteLine(" Next Due Date To Next Dose : " + vaccinationdetailsList[i].VaccinatedDate.AddDays(30).ToString("dd/MM/yyyy"));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You Have completed all doses");
                        break;
                    }
                }

            }
            if (check == false)
            {
                Console.WriteLine(" You Can Take The Vaccine Now");

            }




        }


    }

}





