using HowToMakeCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace HowToMakeCodeFirst.Controllers
{
    public class MusteriController : Controller
    {

        private readonly DataContext _context;

        public MusteriController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()

        {
            var musteriler=_context.Musteriler.ToList();
            return View(musteriler);
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Musteri yeniMusteri)
        {
            if (ModelState.IsValid)
            {


                yeniMusteri.MusteriKayıtTarihi = DateTime.Now;
                _context.Musteriler.Add(yeniMusteri);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(yeniMusteri);
        }
    }
}
