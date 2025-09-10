namespace OOPsReview
{
    public static class Utilities
    {
        public static bool IsZeroOrPositive(double value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
        public static bool IsZeroOrPositive(int value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
        public static bool IsZeroOrPositive(decimal value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
    }
}
