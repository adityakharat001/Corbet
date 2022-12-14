using System.ComponentModel;

using Microsoft.Build.Framework;

namespace Corbet.Ui.Models
{
    public class GetAllStockTypesModel
    {
        public int StockTypeId { get; set; }
        [DisplayName("Stock Type Name")]
        public string StockTypeName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
