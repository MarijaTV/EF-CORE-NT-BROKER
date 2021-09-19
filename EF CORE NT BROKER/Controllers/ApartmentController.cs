using System.Linq;
using EF_CORE_NT_BROKER.Data;
using EF_CORE_NT_BROKER.Dtos;
using EF_CORE_NT_BROKER.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_NT_BROKER.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly DataContext _context;

        public ApartmentController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var ai = new ApartmentIndex()
            {
                AllApartments = _context.Apartments.Include(a => a.Company).ToList()
            };
            return View(ai);
        }

        public IActionResult Add()
        {
            var apartment = new ApartmentCreate();
            apartment.Apartment = new Apartment();// tuscias apartment, companies
            apartment.AllCompanies = _context.Companies.ToList();// kompaniju sarasas dropdownui
            return View(apartment);
        }
        [HttpPost]
        public IActionResult Add(ApartmentCreate apartmentCreate)
        {
            var apartment = apartmentCreate.Apartment;

            _context.Apartments.Add(apartmentCreate.Apartment);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var apartment = _context.Apartments.FirstOrDefault(c => c.Id == id);

            _context.Remove(apartment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var apartment = _context.Apartments.Include(c => c.Company).FirstOrDefault(a => a.Id == id);

            var apartmetEditDto = new ApartmentCreate()
            {
                Apartment = apartment,
                AllCompanies = _context.Companies.ToList(),
                AllBrokers = _context.Brokers.ToList()

            }; //mappinimas iš dtos


            return View(apartmetEditDto);
        }
        [HttpPost]
        public IActionResult Edit(ApartmentCreate apartmetEditDto)
        {


            //var mappedEntity = new Apartment()
            //{
            //    Apartment = apartmetEditDto.Apartment,
            //    AllCompanies = apartmetEditDto.AllCompanies,
            //    AllBrokers = apartmetEditDto.AllBrokers
            //}; //mappinimas iš dtos

            _context.Apartments.Update(apartmetEditDto.Apartment);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
