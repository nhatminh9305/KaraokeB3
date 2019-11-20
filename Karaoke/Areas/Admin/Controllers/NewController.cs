using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using B3.Models;
using jQueryDatatableServerSideNetCore22.Extensions;
using Karaoke.Models.Datatable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Karaoke.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewController : Controller
    {
        private readonly DatabaseContext _context;

        public NewController(DatabaseContext context)
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
            var result = await _context.News.ToListAsync();

            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();
            var filteredResultsCount = result.Count();
            var totalResultsCount = await _context.News.CountAsync();

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

        [HttpPost]
        public IActionResult SavaData(NewModel News)
        {
            bool status = false;
            string message = string.Empty;
            if (!ModelState.IsValid)
            {
                //return Json(new
                //{
                //    status = false,
                //    message = ModelState
                //});
                return PartialView("_AddUpdateModal", News);
            }
            try
            {
                if (News.ImageUpload != null)
                {
                    string extension = Path.GetExtension(News.ImageUpload.FileName);
                    string fileName = DateTime.Now.ToString("yymmssfff") + extension;
                    string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\news", fileName);
                    News.Image = "uploads\\news\\" + fileName;
                    News.ImageUpload.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (News.Id == 0)
                {
                    News.CreatedTime = DateTime.Now;
                    News.UpdatedTime = DateTime.Now;
                    _context.Add(News);
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

            }
            catch (Exception e)
            {
                status = false;
                message = e.Message;
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
            var contact = _context.News.Find(id);
            _context.News.Remove(contact);
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