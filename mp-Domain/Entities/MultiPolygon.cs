using System.Collections.Generic;

namespace mp_Domain.Entities
{
    public class MultiPolygon
    {
        public string type { get; set; }
        public List<List<List<List<double>>>> Coordinates { get; set; }
    }
}