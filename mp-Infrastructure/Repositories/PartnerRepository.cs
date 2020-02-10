using mp_Domain.Contracts.Repositories;
using mp_Domain.Entities;
using System;
using System.Collections.Generic;

namespace mp_Infrastructure.Repositories
{
    public class PartnerRepository : Repository<Partner>, IPartnerRepository
    {
        public List<Partner> GetByCoordinates(double longitude, double latitude)
        {
            var partners = GetAll();
            List<Partner> lstPartners = new List<Partner>();

            if (partners == null || partners.Count == 0)
                return lstPartners;

            foreach(var item in partners)
            {
                List<List<List<double>>> listA = new List<List<List<double>>>();
                item.CoverageArea.Coordinates.ForEach(a => listA.AddRange(a));

                foreach (var itemA in listA)
                {
                    List<double> listB = new List<double>();
                    itemA.ForEach(b => listB.AddRange(b));

                    double distance = CalculateDistance(latitude, longitude, listB[0], listB[1]);
                    if (distance <= 5)
                    {
                        lstPartners.Add(item);
                        break;
                    }
                }
            }

            return lstPartners;
        }

        private double CalculateDistance(double originLat, double originLng, double destinyLat, double destinyLng)
        {
            double arcAb = 90 - (destinyLng);
            double arcAc = 90 - (originLng);
            double arcAbc = destinyLat - originLat;
            double cosAbc = Math.Cos(arcAc) * Math.Cos(arcAb) + Math.Sin(arcAb) * Math.Sin(arcAc) * Math.Cos(arcAbc);
            double arcCos = Math.Acos(cosAbc);
            double distance = (40030 * arcCos) / 360;

            return distance;
        }
    }
}