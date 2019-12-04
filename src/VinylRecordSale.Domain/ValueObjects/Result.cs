namespace VinylRecordSale.Domain.ValueObjects
{
    public class Result
    {
        public Result(object ret, bool isValid = true)
        {
            Return = ret;
            IsValid = isValid;
        }

        public bool IsValid { get; private set; }
        public object Return { get; private set; }
    }
}