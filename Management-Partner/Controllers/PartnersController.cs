using Microsoft.AspNetCore.Mvc;
using mp_DataTransferObject;
using mp_Domain.Contracts.Services;
using mp_Domain.Enums;
using mp_ServiceFactory;
using GeoJSON.Net.Geometry;

namespace Management_Partner.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Produces("application/json")]
    public class PartnersController : ControllerBase
    {
        private IPartnerService service = ServicesFactory.GetServiceInstance(ServicesEnumerator.Partner) as IPartnerService;

        [Route("api/Partners/Get")]
        [HttpGet]
        public PartnerCollectionDto Get()
        {
            return (PartnerCollectionDto)service.GetAllPartners();
        }

        [Route("api/Partners/GetPartnerById")]
        [HttpGet]
        public PartnerDto GetPartnerById(string id)
        {
            return (PartnerDto)service.GetPartnerById(id);
        }

        [Route("api/Partners/GetPartnersByCoordinates")]
        [HttpGet]
        public PartnerCollectionDto GetPartnersByCoordinates(double longitude, double latitude)
        {
            return (PartnerCollectionDto)service.GetPartnersByCoordinates(longitude, latitude);
        }

        [Route("api/Partners/Post")]
        [HttpPost]
        public void Post([FromBody]PartnerDto partner)
        {
            service.CreatePartner(partner);
        }
    }
}