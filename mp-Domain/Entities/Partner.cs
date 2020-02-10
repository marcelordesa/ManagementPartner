using MongoDB.Bson;
using mp_Domain.Contracts.Repositories;
using mp_Domain.Entities.Base;
using System.Collections.Generic;

namespace mp_Domain.Entities
{
    public class Partner : BaseEntity
    {
        public string TradingName { get; private set; }
        public string OwnerName { get; private set; }
        public string Document { get; private set; }
        public MultiPolygon CoverageArea { get; private set; }
        public Point Address { get; private set; }

        public IPartnerRepository PartnerRepository;

        public Partner(string tradingName, string ownerName, string document, MultiPolygon coverageArea, Point address)
        {
            this.TradingName = tradingName;
            this.OwnerName = ownerName;
            this.Document = document;
            this.CoverageArea = coverageArea;
            this.Address = address;
        }

        public Partner(){}

        public IList<Partner> GetAllPartners()
        {
            return PartnerRepository.GetAll();
        }

        public Partner GetPartnerById(string id)
        {
            return PartnerRepository.GetById(ObjectId.Parse(id));
        }

        public void CreatePartner()
        {
            PartnerRepository.Create(this);
        }

        public List<Partner> GetPartnersByCoordinates(double longitude, double latitude)
        {
            return PartnerRepository.GetByCoordinates(longitude, latitude);
        }
    }
}