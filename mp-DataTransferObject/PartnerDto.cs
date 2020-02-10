using mp_Domain.Entities;

namespace mp_DataTransferObject
{
    public class PartnerDto
    {
        public string Id { get; set; }
        public string TradingName { get; set; }
        public string OwnerName { get; set; }
        public string Document { get; set; }
        public MultiPolygon CoverageArea { get; set; }
        public Point Address { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}