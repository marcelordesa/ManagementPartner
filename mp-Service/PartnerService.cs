using mp_DataTransferObject;
using mp_Domain.Contracts.Repositories;
using mp_Domain.Contracts.Services;
using mp_Domain.Entities;
using System;
using System.Linq;

namespace mp_Service
{
    public class PartnerService : IPartnerService
    {
        private IPartnerRepository repository;

        public PartnerService(IPartnerRepository _repository)
        {
            repository = _repository;
        }

        public object GetAllPartners()
        {
            PartnerCollectionDto partners = new PartnerCollectionDto();
            try
            {
                Partner partner = new Partner();
                partner.PartnerRepository = repository;
                var lstPartner = partner.GetAllPartners();

                if (lstPartner == null || lstPartner.Count == 0)
                {
                    partners.IsError = true;
                    partners.Message = "Não existem dados para a consulta!";
                    return partners;
                }

                partners.Partners = lstPartner.Select(p => new PartnerDto
                {
                    Id = p.Id.ToString(),
                    Address = p.Address,
                    CoverageArea = p.CoverageArea,
                    Document = p.Document,
                    OwnerName = p.OwnerName,
                    TradingName = p.TradingName
                }).ToList();
            }
            catch(Exception ex)
            {
                partners.IsError = true;
                partners.Message = $"Erro ao consultar todos os parceiros: {ex.Message}!";
            }

            return partners;
        }

        public object GetPartnerById(string id)
        {
            PartnerDto partnerDto = new PartnerDto();
            try
            {
                Partner partner = new Partner();
                partner.PartnerRepository = repository;
                var item = partner.GetPartnerById(id);

                if (item == null)
                {
                    partnerDto.IsError = true;
                    partnerDto.Message = "Não retornou resultados na consultar parceiro por id!";
                    return partnerDto;
                }

                partnerDto.Id = item.Id.ToString();
                partnerDto.Address = item.Address;
                partnerDto.CoverageArea = item.CoverageArea;
                partnerDto.Document = item.Document;
                partnerDto.OwnerName = item.OwnerName;
                partnerDto.TradingName = item.TradingName;
            }
            catch (Exception ex)
            {
                partnerDto.IsError = true;
                partnerDto.Message = $"Erro ao consultar parceiro por id: {ex.Message}!";
            }

            return partnerDto;
        }

        public void CreatePartner(object partnerEntity)
        {
            var _partnerEntity = (PartnerDto)partnerEntity;
            try
            {
                Partner partner = new Partner(_partnerEntity.TradingName, _partnerEntity.OwnerName, _partnerEntity.Document, _partnerEntity.CoverageArea, _partnerEntity.Address);
                partner.PartnerRepository = repository;
                partner.CreatePartner();
            }
            catch(Exception ex)
            {
                _partnerEntity.IsError = true;
                _partnerEntity.Message = $"Erro ao criar um parceiro: {ex.Message}!";
            }
        }

        public object GetPartnersByCoordinates(double longitude, double latitude)
        {
            PartnerCollectionDto partners = new PartnerCollectionDto();
            try
            {
                Partner partner = new Partner();
                partner.PartnerRepository = repository;
                var lstPartner = partner.GetPartnersByCoordinates(longitude, latitude);

                if (lstPartner == null || lstPartner.Count == 0)
                {
                    partners.IsError = true;
                    partners.Message = "Não existem dados para a consulta de parceiros próximos!";
                    return partners;
                }

                partners.Partners = lstPartner.Select(p => new PartnerDto
                {
                    Id = p.Id.ToString(),
                    Address = p.Address,
                    CoverageArea = p.CoverageArea,
                    Document = p.Document,
                    OwnerName = p.OwnerName,
                    TradingName = p.TradingName
                }).ToList();
            }
            catch (Exception ex)
            {
                partners.IsError = true;
                partners.Message = $"Erro ao consultar todos os parceiros próximos: {ex.Message}!";
            }

            return partners;
        }
    }
}