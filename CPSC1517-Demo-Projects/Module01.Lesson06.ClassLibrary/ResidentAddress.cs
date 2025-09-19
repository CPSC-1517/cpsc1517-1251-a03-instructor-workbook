namespace Module01.Lesson06.ClassLibrary
{
    public record ResidentAddress(
        int Number, 
        string Street, 
        string City, 
        string Province, 
        string PostalCode)
    {
        public override string ToString() =>
            $"{Number}, {Street}, {City}, {Province}, {PostalCode}";
    }
}
