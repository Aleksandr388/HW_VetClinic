using System;
using VeterenaryClinic.Controllers;
using VeterenaryClinic.Models.PostModels;

namespace HW_Veterenary_Clinic
{
    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new PetController();

            var model = new CreatePetPostModel
            {
                Date = DateTime.UtcNow,
                FullNameOwner = "Александр Нещеретный",
                Phone = "390661394163",
                Breed = "Такса",
                TypeTreatment = "Сыпь"
            };

            controller.CreateVetRequest(model);

            var response = controller.GetById(0);

            Console.WriteLine($"{response.FullNameOwner}, {response.Id}");

            Console.ReadLine();
        }
    }
}
