namespace Abc.Accounting.Services
{
    public class StandardsService : IStandardsService
    {
        public Standard GetStandard()
        {
            var logic = new Random();
            if (logic.Next(10) % 2 == 0)
            {
                return Standard.ISO01;
            }
            return Standard.ISO02;
        }
    }
}
