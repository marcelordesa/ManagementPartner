using mp_Domain.Contracts.Repositories;
using mp_Domain.Contracts.Services;
using mp_Domain.Enums;
using mp_Infrastructure.Repositories;
using mp_RepositoryFactory;
using mp_Service;

namespace mp_ServiceFactory
{
    public class ServicesFactory
    {
        public ServicesFactory() { }

        public static object GetServiceInstance(ServicesEnumerator option)
        {
            switch (option)
            {
                case ServicesEnumerator.Partner:
                    return InstancePartnerService();
            }

            return null;
        }

        private static object InstancePartnerService()
        {
            IPartnerRepository repository = PartnerRepositoryFactory.GetRepositoryInstance<PartnerRepository>();
            IPartnerService service = new PartnerService(repository);

            return service;
        }
    }
}