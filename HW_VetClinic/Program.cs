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
                TypeTreatment = "Сыпь",
                Pets = new PetPostModel
                {
                    PetName = "Жучка",
                    PetBreed = "Долматинец"
                },
                Communication = new CommunicationPostModel
                {
                    Phone = "380661394163",
                    Email = "Alex@gmail.com"
                }
            };

            controller.CreateVetRequest(model);

            var allVetClinics = controller.GetAll();

            var response = controller.GetById(1);
        }
    }
}
