using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationApplication
{
    public enum VacineName { Covishield, Covaccine }
    public class VaccineDetails
    {
        private static int _vacineid = 2000;
        public string VaccineID { get; }
        public VacineName VacineName { get; set; }
        public int NumberOfDoseAvailable { get; set; }

        public VaccineDetails(VacineName vacineName, int numberOfDoseAvailable)
        {
            VaccineID = "CID" + ++_vacineid;
            VacineName = vacineName;
            NumberOfDoseAvailable = numberOfDoseAvailable;

        }
        public VaccineDetails(string value)
        {
            string[] values = value.Split(",");
            _vacineid=int.Parse(values[0].Remove(0,3));
            VaccineID = values[0];
            VacineName =Enum.Parse<VacineName>(values[1]);
            NumberOfDoseAvailable = int .Parse(values[2]);

        }

    }
}