using System.Collections.Generic;

namespace mp_DataTransferObject
{
    public class PartnerCollectionDto
    {
        public List<PartnerDto> Partners { get; set; } = new List<PartnerDto>();
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}