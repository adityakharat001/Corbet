using Corbet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corbet.Ui.Models
{
    public class OrderViewModel
    {
     //   public int OrderId { get; set; }
     //   public string OrderCode { get; set; }
        public int SupplierId { get; set; }
        public  int OrderProductId { get; set; }
        public int Quantity { get; set; }
        public string MailThumb { get; set; }
        public string POThumb { get; set; }


        public string Description { get; set; }


    }
}
