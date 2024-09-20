using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationApplication
{
    public enum DoseNumber{Dose1=1,Dose2=2,Dose3=3 }
    public class VaccinationDetails
    {
        private int _vaccinationid=3000;
        public string VaccinationID{get; set;}
        public string RegistrationNumber{get; set;}
        public string VacineId{get; set;}
        public DoseNumber DoseNumber{get; set;}
        public DateTime VaccinatedDate{get; set;}

        public VaccinationDetails(string registrationnumber,string Vacineid,DoseNumber doseNumber,DateTime vaccinatedate)
        {
            RegistrationNumber=registrationnumber;
            VacineId=Vacineid;
            DoseNumber=doseNumber;
            VaccinatedDate=vaccinatedate;
            VaccinationID="VID"+ ++_vaccinationid;
        }
        public VaccinationDetails(string registration)
        {
            string[] vaccination = registration.Split(",");
            RegistrationNumber=vaccination[0];
            VacineId=vaccination[1];
            DoseNumber=Enum.Parse<DoseNumber>(vaccination[2]);
            VaccinatedDate=DateTime.ParseExact(vaccination[3] , "dd/MM/yyyy" , null);
            _vaccinationid=int.Parse(vaccination[4].Remove(0,3));
            VaccinationID=vaccination[4];
        }


    }
}