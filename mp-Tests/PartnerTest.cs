using mp_DataTransferObject;
using mp_Domain.Contracts.Services;
using mp_Domain.Enums;
using mp_ServiceFactory;
using NUnit.Framework;

namespace mp_Tests
{
    public class PartnerTest
    {
        private IPartnerService service = ServicesFactory.GetServiceInstance(ServicesEnumerator.Partner) as IPartnerService;

        [Test]
        public void TestGetAllPartnersIsNotNull()
        {
            var partners = (PartnerCollectionDto)service.GetAllPartners();
            Assert.IsNotNull(partners);
        }

        [Test]
        public void TestGetAllPartnersCountNotZero()
        {
            var partners = (PartnerCollectionDto)service.GetAllPartners();
            Assert.NotZero(partners.Partners.Count);
        }

        [Test]
        public void TestGetPartnerByIdIsNull()
        {
            var partners = (PartnerDto)service.GetPartnerById("5e3e13735c572b0784602f91");
            Assert.IsNull(partners);
        }

        [Test]
        public void TestGetPartnerByIdIsNotNull()
        {
            var partners = (PartnerDto)service.GetPartnerById("5e3e13735c572b0784602f93");
            Assert.IsNull(partners);
        }
    }
}