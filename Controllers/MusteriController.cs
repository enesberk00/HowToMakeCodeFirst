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

        public IActionResult Edit(int id)
        {
            var musteri = _context.Musteriler.Where(x=>x.MusteriId == id).FirstOrDefault();
            return View(musteri);


        }
        [HttpPost]
        public IActionResult Edit(Musteri EditedMusteri, Musteri gizli=null)
        {
            if (ModelState.IsValid)
            { 
                if(gizli==null)
                {
                    gizli=_context.Musteriler.Where(p=>p.MusteriId==EditedMusteri.MusteriId).FirstOrDefault();
                }
                else
                {
                    _context.Musteriler.Attach(gizli);
                }
                if(gizli!=null)
                {
                    gizli.MusteriAd =EditedMusteri.MusteriAd;
                    gizli.MusteriSoyad =EditedMusteri.MusteriSoyad;
                    gizli.MusteriTcNo =EditedMusteri.MusteriTcNo;
                    gizli.MusteriTelNo = EditedMusteri.MusteriTelNo;

                    _context.SaveChanges();
                    return RedirectToAction("Index");

                }

            }
                return View(EditedMusteri);

        }
    }
}
