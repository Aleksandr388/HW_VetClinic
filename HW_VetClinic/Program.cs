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
                FullNameOwner = "Alex Нещеретный",
                TypeTreatment = "Сыпь",
                Pets = new PetPostModel
                {
                    PetName = "Мурка",
                    PetBreed = "Долматинец",
                    Age = 10
                },
                Communication = new CommunicationPostModel
                {
                    Phone = "380661394163",
                    Email = "Alexandr@gmail.com",
                    AdditionalPhone = "380661354256"
                },
                Prices = new PricePostModel
                {
                    PriceValue = 300
                }
            };

            controller.CreateVetRequest(model);

            var allVetClinics = controller.GetAll();

            //var response = controller.GetById(3);
        }
    }
}
