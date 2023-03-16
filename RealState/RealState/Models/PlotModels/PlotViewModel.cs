using Autofac;
using RealState.Core.Services;
using RealState.Models.PlotModels;
using System.Linq;

namespace RealState.Models.PlotModels
{
    public class PlotViewModel
    {

        private IPlotService _plotService;

        public PlotViewModel()
        {
            _plotService = Startup.AutofacContainer.Resolve<IPlotService>();
        }


        public object GetPlots(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _plotService.GetPlots(tableModel.PageIndex, tableModel.PageSize,tableModel.SearchText,out total, out totalFiltered);

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.PlotNumber,
                                record.Price.ToString(),
                                record.Status.ToString()
                        }
                    ).ToArray()

            };
        }

        public PlotModel Load(int id)
        {
            var block = _plotService.GetPlotById(id);

            return new PlotModel
            {
            };
        }

    }
}
