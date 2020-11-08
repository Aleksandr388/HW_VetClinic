using System;
using VeterenaryClinic.Controllers;
using VeterenaryClinic.Models.PostModels;

namespace HW_Veterenary_Clinic
{
    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new VetController();

            var model = new CreatePetPostModel
            {
                Date = DateTime.UtcNow,
                FullNameOwner = "Александр Нещеретный",
                Phone = "390661394163",
                Breed = "Такса",
                TypeTreatment = "Сыпь"
            };

            controller.CreateVetRequest(model);

            var allVetClinics = controller.GetAll();

            var response = controller.GetById(1);
        }
    }
}
