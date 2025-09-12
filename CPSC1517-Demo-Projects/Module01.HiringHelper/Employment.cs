using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module01.HiringHelper
{
    public class Employment
    {
        // Define backing fields for properties
        private string _employeeId;
        private string _fullName;
        private decimal _hourlyRate;
        private double _hoursPerWeek;

        // Define fully implemented properties with backing fields
        public string EmployeeId
        {
            get => _employeeId;
            set
            {
                // validate value

                _employeeId = value.Trim();
            }
        }

        // Define auto-implemented properties without backing field
        public SupervisoryLevel Level { get; set; }
    }
}
