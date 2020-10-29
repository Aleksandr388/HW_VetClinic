using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VeterenaryClinic.Domain;
using VeterenaryClinic.Domain.Models;
using VeterenaryClinic.Models.PostModels;
using VeterenaryClinic.Models.ViewModels;

namespace VeterenaryClinic.Controllers
{
    public class PetController
    {
        private readonly VeterenaryClinicService _veterenaryClinicService;
        private readonly IMapper _mapper;
        public PetController()
        {
            _veterenaryClinicService = new VeterenaryClinicService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreatePetPostModel, VeterenaryClinicDto>();
                cfg.CreateMap<VeterenaryClinicDto, VeterenaryClinicVievModel>();
            });

            _mapper = new Mapper(mapperConfig);
        }
        public void CreateVetRequest(CreatePetPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FullNameOwner))
                throw new System.Exception("Vrong full name owner");

            if (model.Phone.Length != 12)
                throw new System.Exception("Vrong phone number");

            if (string.IsNullOrWhiteSpace(model.Breed))
                throw new System.Exception("Vrong breed");

            if (string.IsNullOrWhiteSpace(model.TypeTreatment))
                throw new System.Exception("Vrong type treatment");

            var vetModel = _mapper.Map<CreatePetPostModel, VeterenaryClinicDto>(model);

            _veterenaryClinicService.CreateVetRequest(vetModel);
        }

        public VeterenaryClinicVievModel GetById(int id)
        {
            var model = _veterenaryClinicService.GetById(id);

            return _mapper.Map<VeterenaryClinicDto, VeterenaryClinicVievModel>(model);
        }
    }
}
