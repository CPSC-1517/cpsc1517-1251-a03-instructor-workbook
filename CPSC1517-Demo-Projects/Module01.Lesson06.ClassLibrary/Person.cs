using System;
namespace Module01.Lesson06.ClassLibrary
{
    public class Person 
    {
        public string FullName => $"{LastName}, {FirstName}";

        //public string FirstName { get; set; }
        private string _firstName;
        public string FirstName
        {
            get => _firstName; 
            set
            {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentNullException(nameof(FirstName), "FirstName cannot be blank.");
                }
                _firstName = value.Trim();
            }
        }

        public string LastName { get; set; }
        public ResidentAddress? Address { get; set; }
        public List<Employment> EmploymentPositions { get; private set; }

        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            EmploymentPositions = new List<Employment>();
        }

        public Person(string firstname, string lastname,
              ResidentAddress? address,
              List<Employment>? employmentpositions)
        {
            FirstName = firstname.Trim();
            LastName = lastname.Trim();
            Address = address;
            EmploymentPositions = employmentpositions ?? new List<Employment>();
        }
    }
}
