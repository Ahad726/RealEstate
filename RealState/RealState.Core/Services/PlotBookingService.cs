﻿using RealState.Core.Context;
using RealState.Core.Entity;
using RealState.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Services
{
    public class PlotBookingService : IPlotBookingService
    {
        private IRealStateUnitOfWork _realStateUnitOfWork;

        public PlotBookingService(IRealStateUnitOfWork realStateUnitOfWork)
        {
            _realStateUnitOfWork = realStateUnitOfWork;
        }

        public void BookNewPlot(PlotBooking plotBook)
        {
            _realStateUnitOfWork.PlotBookingRepository.Add(plotBook);
            _realStateUnitOfWork.Save();
        }

        public IEnumerable<PlotBooking> GetBookedPlot(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _realStateUnitOfWork.PlotBookingRepository.Get(

                out total,
                out totalFiltered,
                 x => x.PlotId.ToString().Contains(searchText) || x.CustomerId.ToString().Contains(searchText)
                 || x.BookedOn.ToString().Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
    }
}
