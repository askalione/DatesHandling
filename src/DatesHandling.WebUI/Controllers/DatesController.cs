using DatesHandling.ApplicationServices.Interfaces;
using DatesHandling.WebUI.Models.Dates;
using Microsoft.AspNetCore.Mvc;

namespace DatesHandling.WebUI.Controllers
{
    public class DatesController : Controller
    {
        private readonly IBarService _barService;
        private readonly IBazService _bazService;
        private readonly IFooService _fooService;

        public DatesController(IBarService barService,
            IBazService bazService,
            IFooService fooService)
        {
            _barService = barService;
            _bazService = bazService;
            _fooService = fooService;
        }

        public IActionResult Index()
        {
            var utcTimestamp = DateTime.UtcNow;
            var bar = _barService.Create(utcTimestamp);

            var barFromDb = _barService.Find(bar.Id);
            if (barFromDb == null)
            {
                return NotFound();
            }

            BarVm barVm = new BarVm
            {
                Id = barFromDb.Id,
                Timestamptz = barFromDb.Timestamptz
            };

            return View(barVm);
        }
    }
}
