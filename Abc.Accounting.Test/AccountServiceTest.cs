using Abc.Accounting.Services;
using Moq;
using System.Linq;
using Xunit;

namespace Abc.Accounting.Test
{
    public class AccountServiceTest
    {
        private readonly Mock<IStandardsService> _standardsService;

        public AccountServiceTest()
        {
            _standardsService = new Mock<IStandardsService>();
        }


        [Fact]
        public void RemarkIsUppercaseWhenStandardIs01()
        {
            // Arrange
            _standardsService.Setup(x => x.GetStandard()).Returns(Standard.ISO01);
            var remark = "siteCore";

            // Act
            var service = new AccountService(_standardsService.Object);
            var processedRemark = service.ToAbcStandard(remark);

            // Assert
            Assert.False(processedRemark.All(c => char.IsUpper(c)));
        }

        [Fact]
        public void RemarkIsLowercaseWhenStandardIs02()
        {
            // Arrange
            _standardsService.Setup(x => x.GetStandard()).Returns(Standard.ISO02);
            var remark = "siteCore";

            // Act
            var service = new AccountService(_standardsService.Object);
            var processedRemark = service.ToAbcStandard(remark);

            // Assert
            Assert.True(processedRemark.All(c => char.IsLower(c)));
        }
    }
}