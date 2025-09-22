namespace Module01.HiringHelper
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            int? discount = null;
            //int applied = discount; // unsafe!

            int applied = discount ?? 0;

            //int applied = 0;
            //if (discount.HasValue)
            //{
            //    applied = discount.Value;
            //}

            //int? applied = null;
            //applied ??= discount;

            Console.WriteLine($"Discount = {discount}");
        }

    }
}
