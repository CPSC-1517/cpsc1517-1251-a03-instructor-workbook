namespace OOPsReview
{
    public class Employment
    {
        // Backing fields (store data, validation is done in properties)
        private string _title = "";
        private double _years;
        
        public string Title
        {
            //get { return _title; } 
            get => _title;

            set 
            {
                // Job title must be non-emtpy
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be empty", nameof(Title));
                }
                _title = value.Trim(); 
            } 
        }

        public double Years
        {
            get => _years;

            set
            {
                // Year must be >= 0
                //if (value < 0)
                //if (Utilities.IsZeroOrPositive(value) == false)
                if (!Utilities.IsZeroOrPositive(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Years), "Years must be >= 0.");
                }
                _years = value;
            }
        }

        public SupervisoryLevel Level { get; set; } = SupervisoryLevel.Entry;

        // Private set to protect invariants; change via methods if needed.
        public DateTime StartDate { get; private set; } = DateTime.Now;

        // Define a default (no-argument) constructor
        public Employment()
        {
            // Initialize all properties to initial values
            Title = "unkonwn";
            Years = 0.0;
            StartDate = DateTime.Today;
            Level = SupervisoryLevel.TeamMember;
        }
        // Define a "greedy" constructor
        public Employment(string title, double years, 
            DateTime startDate, SupervisoryLevel level)
        {
            Title = title;  // validate & trim
            Years = years;  // validate
            StartDate = startDate;  // private set, but assignable here
            Level = level;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Years: {Years}, StartDate: {StartDate.ToString("yyyy-MM-dd")}, Level: {Level}";
        }
    }
}
