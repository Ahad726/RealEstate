using Autofac;
using RealState.Core.Services;
using System.Linq;

namespace RealState.Models.PlotBooking
{
    public class PlotBookingVM
    {
        private IPlotBookingService _bookingService;

        public PlotBookingVM()
        {
            _bookingService = Startup.AutofacContainer.Resolve<IPlotBookingService>();
        }


        public object GetBookedPlots(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _bookingService.GetBookedPlot(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.CustomerId.ToString(),
                                record.PlotId.ToString(),
                                record.Customer?.Name

                        }
                    ).ToArray()

            };
        }
    }
}
