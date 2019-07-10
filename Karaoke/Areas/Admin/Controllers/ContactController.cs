using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B3.Models;
using jQueryDatatableServerSideNetCore22.Extensions;
using Karaoke.Models.Datatable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Karaoke.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly DatabaseContext _context;

        public ContactController(DatabaseContext context )
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoadTable(DTParameters dtParameters)
        {
           
            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;
            if (dtParameters.Order != null)
            {
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "asc";
            }
            else
            {
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }
            var result = await _context.Contact.ToListAsync();

            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();
            var filteredResultsCount = result.Count();
            var totalResultsCount = await _context.Contact.CountAsync();

            return Json(new
            {
                draw = dtParameters.Draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
                   .Skip(dtParameters.Start)
                   .Take(dtParameters.Length)
                   .ToList()
            });
        }
        [HttpGet]
        public IActionResult GetDataID(int id)
        {
            var contact = _context.Contact.Find(id);
            return Json(new
            {
                data = contact,
                status = true
            }
            );
        }
        [HttpPost]
        public IActionResult SavaData(ContactModel contact)
        {
            contact.Status = 2;
            bool status = false;
            string message = string.Empty;

            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = false,
                    message = ModelState
                });
            }
            if (contact.Id == 0)
            {
                _context.Add(contact);
                try
                {
                    _context.SaveChanges();
                    status = true;
                }
                catch (Exception e)
                {
                    status = false;
                    message = e.Message;
                }
            }
            else
            {
                var data = _context.Contact.Find(contact.Id);
                data.Name = contact.Name;
                data.Phone = contact.Phone;
                data.Description = contact.Description;
                data.UpdatedTime = DateTime.Now;
                data.Status = contact.Status;

                try
                {
                    _context.SaveChanges();
                    status = true;
                }
                catch (Exception e)
                {
                    status = false;
                    message = e.Message;
                }
            }

            return Json(new
            {
                status = status,
                message = message
            });
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var contact = _context.Contact.Find(id);
            _context.Contact.Remove(contact);
            try
            {
                _context.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }
    }
}