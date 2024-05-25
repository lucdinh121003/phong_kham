using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhongKhamOnline.Models;
using PhongKhamOnline.Repositories;

namespace PhongKhamOnline.Controllers
{
    public class BacSiController : Controller
    {
        private readonly IBacSiRepository _BacSiRepository;
        private IEnumerable<BacSi> listDoctor = [];

        public BacSiController(IBacSiRepository BacSiRepository)
        {
            _BacSiRepository = BacSiRepository;
        
        }
        public async Task<IActionResult> Index()
        {
            var BacSis = await _BacSiRepository.GetAllAsync();
            listDoctor = BacSis;
            return View(listDoctor);
        }

        public async Task<IActionResult> Display(int id)
        {
            var bacSi = await _BacSiRepository.GetByIdAsync(id);
            if (bacSi == null)
            {
                return NotFound();
            }
            return View(bacSi);
        }


        public async Task<IActionResult> Search(string searchString)
        {
            if ( searchString == "")
            {
                return View("Index", listDoctor); 
            }

           
            var fillterListDoctor = await _BacSiRepository.searchDoctor(searchString);

            return View("Index", fillterListDoctor); 
        }

    }
}
