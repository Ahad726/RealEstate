﻿using Microsoft.AspNetCore.Mvc;
using RealState.Models.BlockModels;
using RealState.Models;
using RealState.Models.PlotBooking;
using Microsoft.AspNetCore.Authorization;

namespace RealState.Controllers
{
    [Authorize]
    public class PlotBooking : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PlotBookingModel plotBookingModel)
        {
            var bookingUM = new PlotBookingUM();
            bookingUM.BookNewPlot(plotBookingModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetBookedPlot()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new PlotBookingVM();
            var plots = model.GetBookedPlots(tableModel);
            return Json(plots);
        }

        [HttpGet]
        public IActionResult Vacate(int id)
        {
            var bookingUM = new PlotBookingUM();
            bookingUM.VacateBookedPlot(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
