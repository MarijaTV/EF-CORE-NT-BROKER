using System.Linq;
using EF_CORE_NT_BROKER.Data;
using EF_CORE_NT_BROKER.Dtos;
using EF_CORE_NT_BROKER.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_NT_BROKER.Controllers
{
    public class CompanyController : Controller
    {
        private readonly DataContext _context;

        public CompanyController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var companies = _context.Companies.ToList();
            return View(companies);
            //var companies = _context.Companies.Include(b => b.Brokers).ToList();
        }

        public IActionResult Add()
        {
            var company = new Company();
            company.Brokers = _context.Brokers.ToList();

            return View(company);
        }
        [HttpPost]
        public IActionResult Add(Company company)
        {
            //var mappedEntity = new ShopItem()
            //{
            //    Name = shopItemCreate.Name,
            //    ShopId = shopItemCreate.ShopId
            //}; //mappinimas iš dtos

            if (company.BrokerIds != null)
            {

                company.Brokers = _context.Brokers.Where(b => company.BrokerIds.Contains(b.Id)).ToList();
            }
            _context.Companies.Add(company);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);
            //if (company.BrokerIds != null)
            //{
            //  var brokersToDelete = _context.Brokers.Where(b => company.BrokerIds.Contains(b.Id)).ToList();
            //    //company.Brokers.RemoveAll();
            //    _context.Brokers.RemoveRange(brokersToDelete);
            //}
            //var tmpAp _context.Apartments.Where(company_id ž company.id).toList();
            // _context.Apartments.RemoveRange(tmpAp);

            _context.Remove(company);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var company = _context.Companies.Include(b => b.Brokers).FirstOrDefault(c => c.Id == id);

            var brokerDto = new CompanyEditDto()
            {
                Company = company,
                AllBrokers = _context.Brokers.ToList(),
                BrokerIds = company.Brokers.Select(b => b.Id).ToList()

            }; //mappinimas iš dtos


            return View(brokerDto);
        }
        [HttpPost]
        public IActionResult Edit(CompanyEditDto brokerDto)
        {

            var mappedEntity = new Company()
            {
                Id = brokerDto.Company.Id,
                CompanyName = brokerDto.Company.CompanyName,
                City = brokerDto.Company.City,
                Street = brokerDto.Company.Street,
                Address = brokerDto.Company.Address,
                BrokerIds = brokerDto.BrokerIds.ToList()

            }; //mappinimas iš dtos
            if (mappedEntity.BrokerIds != null)
            {

                mappedEntity.Brokers = _context.Brokers.Where(b => mappedEntity.BrokerIds.Contains(b.Id)).ToList();
            }

            _context.Companies.Update(mappedEntity);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
