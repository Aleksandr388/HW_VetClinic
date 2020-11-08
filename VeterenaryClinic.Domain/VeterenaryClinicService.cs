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
        private readonly IMapper _mapper;
        private readonly IVeterenaryClinicReposytory _veterenaryClinicDapperRepository;
       
        public VeterenaryClinicService()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VeterenaryClinicModel, VetClinics>();
                cfg.CreateMap<VetClinics, VeterenaryClinicModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
            _veterenaryClinicDapperRepository = new VeterenaryClinicDapperRepository();
        }

        public void CreateVetRequest(VeterenaryClinicModel model)
        {
            var vetModel = _mapper.Map<VeterenaryClinicModel, VetClinics>(model);

            _veterenaryClinicDapperRepository.Create(vetModel);
        }

        public IEnumerable<VeterenaryClinicModel> GetAll()
        {
            IEnumerable<VetClinics> models = _veterenaryClinicDapperRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<VeterenaryClinicModel>>(models);

            return mappedModels;
        }

        public VeterenaryClinicModel GetById(int id)
        {
            VetClinics models = _veterenaryClinicDapperRepository.GetById(id);

            var mappedModels = _mapper.Map<VeterenaryClinicModel>(models);

            return mappedModels;
        }

    }
}
