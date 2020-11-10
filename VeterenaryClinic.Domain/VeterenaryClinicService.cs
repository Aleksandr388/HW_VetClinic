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
                cfg.CreateMap<VeterenaryClinicModel, VetClinic>();
                cfg.CreateMap<VetClinic, VeterenaryClinicModel>().ReverseMap();
                cfg.CreateMap<PetModel, Pet>().ReverseMap();
                cfg.CreateMap<CommunicationModel, Communication>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
            _veterenaryClinicDapperRepository = new VeterenaryClinicDapperRepository();
        }

        public void CreateVetRequest(VeterenaryClinicModel model)
        {
            if (_veterenaryClinicDapperRepository.GetByDateTime(model.Date) != null)
            {
                throw new System.Exception("Choose another date and time");
            }
            

            var vetModel = _mapper.Map<VeterenaryClinicModel, VetClinic>(model);

            _veterenaryClinicDapperRepository.Create(vetModel);
        }

        public IEnumerable<VeterenaryClinicModel> GetAll()
        {
            IEnumerable<VetClinic> models = _veterenaryClinicDapperRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<VeterenaryClinicModel>>(models);

            return mappedModels;
        }

        public VeterenaryClinicModel GetById(int id)
        {
            VetClinic models = _veterenaryClinicDapperRepository.GetById(id);

            var mappedModels = _mapper.Map<VeterenaryClinicModel>(models);

            return mappedModels;
        }

    }
}
