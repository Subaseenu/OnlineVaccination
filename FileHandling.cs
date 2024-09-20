using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationApplication
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("VaccinationDetails"))
            {
                Console.WriteLine("Creating folder...");
                Directory.CreateDirectory("VaccinationDetails");
            }
            else
            {
                Console.WriteLine("Already exist");
            }
            if(!File.Exists("VaccinationDetails/BeneficiaryDetail.csv"))
            {
                Console.WriteLine("Creating files...");
                File.Create("VaccinationDetails/BeneficiaryDetail.csv");
            }
            else
            {
                Console.WriteLine("Already Exist");
            }
            if(!File.Exists("VaccinationDetails/VaccinationDetails.csv"))
            {
                Console.WriteLine("Creating files..");
                File.Create("VaccinationDetails/VaccinationDetails.csv");
            }
            else
            {
                Console.WriteLine("Already exist");
            }
            if(!File.Exists("VaccinationDetails/VaccineDetails.csv"))
            {
                Console.WriteLine("Creating file..");
                File.Create("VaccinationDetails/VaccineDetails.csv");
            }
            else
            {
                Console.WriteLine("Already  exist...");
            }
        }
        public static void WriteCSV()
        {
            string[] newdata1 = new string[Program.benificiarydetailList.Count];
            for(int i=0;i<Program.benificiarydetailList.Count;i++)
            {
                newdata1[i]= Program.benificiarydetailList[i].Name+","+Program.benificiarydetailList[i].Age+","+Program.benificiarydetailList[i].Gender+","+Program.benificiarydetailList[i].MobileNumber+","+Program.benificiarydetailList[i].City+","+Program.benificiarydetailList[i].RegistrationNumber;
            }
            File.WriteAllLines("VaccinationDetails/BeneficiaryDetail.csv" , newdata1);

            
            string[] newdata2 = new string[Program.vaccinedetailsList.Count];
            for(int i=0;i<Program.vaccinedetailsList.Count;i++)
            {
                newdata2[i] = Program.vaccinedetailsList[i].VaccineID+","+Program.vaccinedetailsList[i].VacineName+","+Program.vaccinedetailsList[i].NumberOfDoseAvailable;
            }
            File.WriteAllLines("VaccinationDetails/VaccineDetails.csv",newdata2);
 
           string[] newdata3 = new string[Program.vaccinationdetailsList.Count];
           for(int i=0;i<Program.vaccinationdetailsList.Count;i++)
           {
            newdata3[i] = Program.vaccinationdetailsList[i].RegistrationNumber+","+Program.vaccinationdetailsList[i].VacineId+","+Program.vaccinationdetailsList[i].DoseNumber+","+Program.vaccinationdetailsList[i].VaccinatedDate.ToString("dd/MM/yyyy")+","+Program.vaccinationdetailsList[i].VaccinationID;
           }
           File.WriteAllLines("VaccinationDetails/VaccinationDetails.csv" , newdata3);
        }
        public static void ReadCSV()
        {
            string[] olddata1 = File.ReadAllLines("VaccinationDetails/BeneficiaryDetail.csv");
            foreach(string val in olddata1)
            {
                BeneficiaryDetails beneficiaryDetails = new BeneficiaryDetails(val);
                Program.benificiarydetailList.Add(beneficiaryDetails);
            }

            string[] olddata2 = File.ReadAllLines("VaccinationDetails/VaccinationDetails.csv");
            foreach(string n in olddata2)
            {
                VaccinationDetails vaccination = new VaccinationDetails(n);
                Program.vaccinationdetailsList.Add(vaccination);
            }

            string[] olddata3 = File.ReadAllLines("VaccinationDetails/VaccineDetails.csv");
            foreach(string m in olddata3)
            {
                VaccineDetails vaccine = new VaccineDetails(m);
                Program.vaccinedetailsList.Add(vaccine);
            }
        }
    }
}