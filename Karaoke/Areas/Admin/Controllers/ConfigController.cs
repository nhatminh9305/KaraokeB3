using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B3.Models;
using jQueryDatatableServerSideNetCore22.Extensions;
using Karaoke.Models.Datatable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Datatable.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ConfigController : Controller
    {
        private readonly DatabaseContext _context;

        public ConfigController(DatabaseContext context)
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
            var result = await _context.Configs.ToListAsync();

            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();
            var filteredResultsCount = result.Count();
            var totalResultsCount = await _context.Configs.CountAsync();

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
            var config = _context.Configs.Find(id);
            return Json(new
            {
                data = config,
                status = true
            }
            );
        }

        [HttpPost]
        public IActionResult SavaData(ConfigModel config)
        {
            config.Status = 2;
            bool status = false;
            string message = string.Empty;

            if (!ModelState.IsValid)
            {
                return Json(new {
                    status = false,
                    message = ModelState
                });
            }
            if(config.Id == 0)
            {
                _context.Add(config);
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
                var data = _context.Configs.Find(config.Id);
                data.Title = config.Title;
                data.OpenTime = config.OpenTime;
                data.HotLine = config.HotLine;
                data.UpdatedTime = DateTime.Now;
                data.Address = config.Address;

                try
                {
                    _context.SaveChanges();
                    status = true;
                }
                catch(Exception e)
                {
                    status = false;
                    message = e.Message;
                }
            }

            return Json(new
            {
                status = status,
                message =message
            });
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var config = _context.Configs.Find(id);
            _context.Configs.Remove(config);
            try
            {
                _context.SaveChanges();
                return Json( new
                    {
                    status = true
                });
            }
            catch(Exception ex)
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