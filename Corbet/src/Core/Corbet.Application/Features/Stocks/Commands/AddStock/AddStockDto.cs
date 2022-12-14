using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Stocks.Commands.AddStock
{
    public class AddStockDto
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int StockTypeId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool IsDeleted{get; set; }
    }
}
