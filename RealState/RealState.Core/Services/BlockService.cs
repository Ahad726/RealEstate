using RealState.Core.Entity;
using RealState.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Services
{
    public class BlockService : IBlockService
    {
        private IRealStateUnitOfWork _realStateUnitOfWork;

        public BlockService(IRealStateUnitOfWork realStateUnitOfWork)
        {
            _realStateUnitOfWork = realStateUnitOfWork;
        }

        public void AddNewBlock(Block block)
        {
            if (block == null) throw new InvalidOperationException("Block Cannot ber null");
            _realStateUnitOfWork.BlockRepository.Add(block);
            _realStateUnitOfWork.Save();
            int blockId = block.Id;
            if (blockId > 0)
            {
                for (int i = 0; i <= block.NumPlots; i++)
                {
                    var plotEntry = new Plot()
                    {
                        BlockId = blockId,
                        PlotNumber = block.Name + (i+1).ToString("00000"),
                        Status = 1,
                        Price = 155000
                    };
                    _realStateUnitOfWork.PlotRepository.Add(plotEntry);
                    _realStateUnitOfWork.Save();
                }
            }

        }

        public void EditBlock(Block block)
        {
            var previousBlock = _realStateUnitOfWork.BlockRepository.GetById(block.Id);

            if (previousBlock != null)
            {
                previousBlock.Name = block.Name;
                previousBlock.City = block.City;
                previousBlock.Description = block.Description;
                previousBlock.Thana = block.Thana;
                previousBlock.NumPlots = block.NumPlots;
                previousBlock.NumAvailablePlots = block.NumAvailablePlots;
                previousBlock.NumSoldPlots = block.NumSoldPlots;


                _realStateUnitOfWork.Save();
            }

        }

        public IEnumerable<Block> GetAllBlock()
        {
            return _realStateUnitOfWork.BlockRepository.GetAll();
        }

        public Block GetBlockById(int id)
        {
            return _realStateUnitOfWork.BlockRepository.GetById(id);
        }

        public IEnumerable<Block> GetBlocks(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _realStateUnitOfWork.BlockRepository.Get(

                out total,
                out totalFiltered,
                 x => x.Name.Contains(searchText) || x.City.Contains(searchText)
                 || x.Thana.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }

        public void Remove(int id)
        {
            _realStateUnitOfWork.BlockRepository.Remove(id);
            _realStateUnitOfWork.Save();
        }
    }
}
