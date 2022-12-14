using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.StockTypes.Commands.DeleteStockType
{
    public class DeleteStockTypeDto
    {
        public int StockTypeId { get; set; }
        public string StockTypeName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
