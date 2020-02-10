using mp_Domain.Contracts.Repositories;

namespace mp_RepositoryFactory
{
    public class PartnerRepositoryFactory
    {
        public static IPartnerRepository GetRepositoryInstance<T>() where T : IPartnerRepository, new()
        {
            return new T();
        }
    }
}