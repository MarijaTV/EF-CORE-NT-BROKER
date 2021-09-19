using System.Linq;
using EF_CORE_NT_BROKER.Data;
using EF_CORE_NT_BROKER.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_CORE_NT_BROKER.Controllers
{
    public class BrokerController : Controller
    {
        private readonly DataContext _context;

        public BrokerController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var brokers = _context.Brokers.ToList();
            return View(brokers);
        }
        public IActionResult Add()
        {
            var broker = new Broker();
            return View(broker);
        }
        [HttpPost]
        public IActionResult Add(Broker broker)
        {
            _context.Brokers.Add(broker);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var broker = _context.Brokers.FirstOrDefault(s => s.Id == id);
            _context.Remove(broker);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var broker = _context.Brokers.FirstOrDefault(s => s.Id == id);
            return View(broker);
        }
        [HttpPost]
        public IActionResult Edit(Broker broker)
        {
            _context.Brokers.Update(broker);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
