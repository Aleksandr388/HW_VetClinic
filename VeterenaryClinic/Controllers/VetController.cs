﻿using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using VeterenaryClinic.Domain;
using VeterenaryClinic.Domain.Models;
using VeterenaryClinic.Models.PostModels;
using VeterenaryClinic.Models.ViewModels;

namespace VeterenaryClinic.Controllers
{
    public class VetController
    {
        private readonly VeterenaryClinicService _veterenaryClinicService;
        private readonly IMapper _mapper;
        public VetController()
        {
            _veterenaryClinicService = new VeterenaryClinicService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreatePetPostModel, VeterenaryClinicModel>();
                cfg.CreateMap<VeterenaryClinicModel, VeterenaryClinicVievModel>();
                cfg.CreateMap<PetViewModel, PetModel>().ReverseMap();
                cfg.CreateMap<PetPostModel, PetModel>().ReverseMap();
                cfg.CreateMap<CommunicationViewModel, CommunicationModel>().ReverseMap();
                cfg.CreateMap<CommunicationPostModel, CommunicationModel>().ReverseMap();
                cfg.CreateMap<PriceViewModel, PriceModel>().ReverseMap();
                cfg.CreateMap<PricePostModel, PriceModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }
        public void CreateVetRequest(CreatePetPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FullNameOwner))
                throw new System.Exception("wrong full name owner");

            if (string.IsNullOrWhiteSpace(model.TypeTreatment))
                throw new System.Exception("wrong type treatment");

            if (string.IsNullOrWhiteSpace(model.Communication.Email))
                throw new System.Exception("wrong email");

            var vetModel = _mapper.Map<CreatePetPostModel, VeterenaryClinicModel>(model);

            _veterenaryClinicService.CreateVetRequest(vetModel);
        }

        public IEnumerable<VeterenaryClinicVievModel> GetAll()
        {
            IEnumerable<VeterenaryClinicModel> models = _veterenaryClinicService.GetAll();

            return _mapper.Map<IEnumerable<VeterenaryClinicVievModel>>(models);
        }

        public VeterenaryClinicVievModel GetById(int id)
        {
            VeterenaryClinicModel models = _veterenaryClinicService.GetById(id);

            var mapperIdModels = _mapper.Map<VeterenaryClinicVievModel>(models);

            return mapperIdModels;
        }
    }
}
