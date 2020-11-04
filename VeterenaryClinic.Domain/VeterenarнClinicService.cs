using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using VeterenaryClinic.Data.Models;
using VeterenaryClinic.Data.Repositories;
using VeterenaryClinic.Domain.Models;
using VeterenaryClinic.Data.Interfaces;


namespace VeterenaryClinic.Domain
{
    public class VeterenaryClinicService
    {
        private readonly IVeterenaryClinicReposytory _veterenaryClinicRepository;
        private readonly IMapper _mapper;
        private readonly IVeterenaryClinicReposytory _veterenaryClinicDapperRepository;
        public VeterenaryClinicService()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VeterenaryClinicModel, VeterenaryClinics>();
                cfg.CreateMap<VeterenaryClinics, VeterenaryClinicModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
            _veterenaryClinicRepository = new VeterenaryClinicRepository();
            _veterenaryClinicDapperRepository = new VeterenaryClinicDapperRepository();

        }

        public void CreateVetRequest(VeterenaryClinicModel model)
        {
            var vetModel = _mapper.Map<VeterenaryClinicModel, VeterenaryClinics>(model);

            _veterenaryClinicRepository.Create(vetModel);
        }

        public IEnumerable<VeterenaryClinicModel> GetAll()
        {
            IEnumerable<VeterenaryClinics> models = _veterenaryClinicDapperRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<VeterenaryClinicModel>>(models);

            return mappedModels;
        }

        public IEnumerable<VeterenaryClinicModel> GetById()
        {
            IEnumerable<VeterenaryClinics> models = _veterenaryClinicDapperRepository.GetById();

            var mappedModels = _mapper.Map<IEnumerable<VeterenaryClinicModel>>(models);

            return mappedModels;
        }

    }
}
