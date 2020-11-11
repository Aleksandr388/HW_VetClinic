using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using VeterenaryClinic.Data.Models;
using VeterenaryClinic.Data.Repositories;
using VeterenaryClinic.Domain.Models;
using VeterenaryClinic.Data.Interfaces;
using System;
using System.Security.Cryptography.X509Certificates;

namespace VeterenaryClinic.Domain
{
    public class VeterenaryClinicService
    {
        private readonly IMapper _mapper;
        private readonly IVeterenaryClinicReposytory _veterenaryClinicEFRepository;
       
        public VeterenaryClinicService()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VeterenaryClinicModel, VetClinic>();
                cfg.CreateMap<VetClinic, VeterenaryClinicModel>().ReverseMap();
                cfg.CreateMap<PetModel, Pet>().ReverseMap();
                cfg.CreateMap<CommunicationModel, Communication>().ReverseMap();
                cfg.CreateMap<PriceModel, Price>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
            _veterenaryClinicEFRepository = new VeterenaryClinicEFRepository();
        }

        public void CreateVetRequest(VeterenaryClinicModel model)
        {
            if (_veterenaryClinicEFRepository.GetByName(model.FullNameOwner) != null)
            {
               model.Prices.PriceValue = model.Prices.PriceValue * 0.8;

               var vetModel = _mapper.Map<VeterenaryClinicModel, VetClinic>(model);

               _veterenaryClinicEFRepository.Create(vetModel);
            }
            else
            {
                var vetModel = _mapper.Map<VeterenaryClinicModel, VetClinic>(model);

                _veterenaryClinicEFRepository.Create(vetModel);
            }
        }

        public IEnumerable<VeterenaryClinicModel> GetAll()
        {
            IEnumerable<VetClinic> models = _veterenaryClinicEFRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<VeterenaryClinicModel>>(models);

            return mappedModels;
        }

        public VeterenaryClinicModel GetById(int id)
        {
            VetClinic models = _veterenaryClinicEFRepository.GetById(id);

            var mappedModels = _mapper.Map<VeterenaryClinicModel>(models);

            return mappedModels;
        }

    }
}
