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
                cfg.CreateMap<VeterenaryClinicDto, VeterenaryClin>();
                cfg.CreateMap<VeterenaryClin, VeterenaryClinicDto>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);

        }
        public void CreateVetRequest(VeterenaryClinicDto model)
        {
            var vetModel = _mapper.Map<VeterenaryClinicDto, VeterenaryClin>(model);

            _veterenaryClinicRepository.Create(vetModel);
        }

        public VeterenaryClinicDto GetById(int id)
        {
            var model = _veterenaryClinicRepository.GetById(id);

            return _mapper.Map<VeterenaryClin, VeterenaryClinicDto>(model);
        }

    }
}
