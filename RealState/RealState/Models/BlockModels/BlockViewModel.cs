using Autofac;
using RealState.Core.Services;
using RealState.Models.CustomerModels;
using System.Linq;

namespace RealState.Models.BlockModels
{
    public class BlockViewModel
    {
        private IBlockService _blockService;

        public BlockViewModel()
        {
            _blockService = Startup.AutofacContainer.Resolve<IBlockService>();
        }


        public object GetBlocks(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _blockService.GetBlocks(
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
                                record.Name,
                                record.City,
                                record.NumPlots.ToString(),
                                record.NumAvailablePlots.ToString(),
                                record.NumSoldPlots.ToString(),
                                record.Description

                        }
                    ).ToArray()

            };
        }

        public BlockModel Load(int id)
        {
            var block = _blockService.GetBlockById(id);

            return new BlockModel
            {
                Id = block.Id,
                Name = block.Name,
                City = block.City,
                NumPlots = block.NumPlots,
                NumAvailablePlots = block.NumAvailablePlots,
                NumSoldPlots = block.NumSoldPlots
            };
        }
    }
}
