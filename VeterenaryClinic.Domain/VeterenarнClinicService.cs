using AutoMapper;
using VeterenaryClinic.Data.Models;
using VeterenaryClinic.Data.Repositories;
using VeterenaryClinic.Domain.Models;

namespace VeterenaryClinic.Domain
{
    public class VeterenaryClinicService
    {
        private readonly VeterenaryClinicRepository _veterenaryClinicRepository;
        private readonly IMapper _mapper;
        public VeterenaryClinicService()
        {
            _veterenaryClinicRepository = new VeterenaryClinicRepository();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VeterenaryClinicModel, VeterenaryClinics>();
                cfg.CreateMap<VeterenaryClinics, VeterenaryClinicModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);

        }
        
        
        public void CreateVetRequest(VeterenaryClinicModel model)
        {
            if (_veterenaryClinicRepository.GetByDateTime(model.Date) != null)
            {
                throw new System.Exception("Wrong date or time");
            }

            var vetModel = _mapper.Map<VeterenaryClinicModel, VeterenaryClinics>(model);

            _veterenaryClinicRepository.Create(vetModel);
        }

        public VeterenaryClinicModel GetById(int id)
        {
            var model = _veterenaryClinicRepository.GetById(id);

            return _mapper.Map<VeterenaryClinics, VeterenaryClinicModel>(model);
        }

    }
}
