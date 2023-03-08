namespace Abc.Accounting.Services
{
    public class AccountService : IAccountService
    {
        private readonly IStandardsService _standardsService;

        public AccountService(IStandardsService standardsService)
        {
            _standardsService = standardsService;
        }

        public string ToAbcStandard(string remark)
        {
            var standardToUse = _standardsService.GetStandard();
            if (standardToUse == Standard.ISO01)
            {
                return remark.ToUpper();
            }
            return remark.ToLower();
        }
    }
}
