using HA.WebAPI.ConfigurationOptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void TestSetAndGetName()
        {
            _applicationDetail.ContactWebsite = ContactWebsite;
            Assert.That(_applicationDetail.ContactWebsite, Is.EqualTo(ContactWebsite));
        }

        [Test]
        public void TestSetAndGetDescription()
        {
            _applicationDetail.LicenseDetail = LicenseDetail;
            Assert.That(_applicationDetail.LicenseDetail, Is.EqualTo(LicenseDetail));
        }
    }
}
