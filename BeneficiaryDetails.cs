using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationApplication
{
    public enum Gender{Male,female,others}
    public class BeneficiaryDetails
    {
        private static int _registrationnumber=1000;
       public  string RegistrationNumber{get; set;}
       public string Name{get; set;}
       public int Age{get; set;}
       public Gender Gender{get; set;}
       public long MobileNumber{get; set;}
       public string City{get; set;}

       public BeneficiaryDetails(string name,int age,Gender gender,long mobilenumber,string city)
       {
          Name=name;
          Age=age;
          Gender=gender;
          MobileNumber=mobilenumber;
          City=city;
          RegistrationNumber="BID"+ ++_registrationnumber;
       }
        public BeneficiaryDetails(string val)
       {
        string [] values = val.Split(",");
          Name=values[0];
          Age=int.Parse(values[1]);
          Gender=Enum.Parse<Gender>(values[2]);
          MobileNumber=long.Parse(values[3]);
          City=values[4];
          _registrationnumber=int.Parse(values[5].Remove(0 , 3));
          RegistrationNumber=values[5];
       }
    }
}