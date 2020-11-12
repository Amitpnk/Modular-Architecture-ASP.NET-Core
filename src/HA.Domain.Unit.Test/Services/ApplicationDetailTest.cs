using HA.WebAPI.ConfigurationOptions;
using NUnit.Framework;

namespace HA.Domain.Unit.Test.Services
{
    public class ApplicationDetailTest
    {
        private readonly ApplicationDetail _applicationDetail;
        private const string ContactWebsite = "https://amitpnk.github.io/";
        private const string LicenseDetail = "https://opensource.org/licenses/MIT";

        public ApplicationDetailTest()
        {
            _applicationDetail = new ApplicationDetail();
        }

        [Test]
        public void TestSetAndGetContactWebsite()
        {
            _applicationDetail.ContactWebsite = ContactWebsite;
            Assert.That(_applicationDetail.ContactWebsite, Is.EqualTo(ContactWebsite));
        }

        [Test]
        public void TestSetAndGetLicenseDetail()
        {
            _applicationDetail.LicenseDetail = LicenseDetail;
            Assert.That(_applicationDetail.LicenseDetail, Is.EqualTo(LicenseDetail));
        }
    }
}
