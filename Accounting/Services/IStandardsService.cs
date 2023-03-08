namespace Abc.Accounting.Services
{
    public interface IStandardsService
    {
        Standard GetStandard();
    }

    public enum Standard
    {
        ISO01 = 1,
        ISO02 = 2
    }
}
