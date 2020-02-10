using mp_Domain.Entities;
using System.Collections.Generic;

namespace mp_Domain.Contracts.Repositories
{
    public interface IPartnerRepository : IRepository<Partner>
    {
        List<Partner> GetByCoordinates(double longitude, double latitude);
    }
}