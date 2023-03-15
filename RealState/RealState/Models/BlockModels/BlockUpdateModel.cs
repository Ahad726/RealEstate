using Autofac;
using RealState.Core.Entity;
using RealState.Core.Services;
using RealState.Models.CustomerModels;
using System;

namespace RealState.Models.BlockModels
{
    public class BlockUpdateModel
    {
        private IBlockService _blockService;

        public BlockUpdateModel()
        {
            _blockService = Startup.AutofacContainer.Resolve<IBlockService>();
        }

        public void AddNewBlock(BlockModel blockModel)
        {
            _blockService.AddNewBlock(new Block
            { 
                Name = blockModel.Name,
                Description = blockModel.Description,
                City = blockModel.City,
                NumPlots = blockModel.NumPlots
            });
        }

    }
}
