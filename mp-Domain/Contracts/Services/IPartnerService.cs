namespace mp_Domain.Contracts.Services
{
    public interface IPartnerService
    {
        object GetAllPartners();
        object GetPartnerById(string id);
        void CreatePartner(object partnerEntity);
        object GetPartnersByCoordinates(double longitude, double latitude);
    }
}