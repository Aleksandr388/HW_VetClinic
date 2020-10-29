using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                cfg.CreateMap<VeterenaryClin, VeterenaryClinicDto>();
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
