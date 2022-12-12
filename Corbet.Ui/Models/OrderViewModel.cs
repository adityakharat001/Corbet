using Corbet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corbet.Ui.Models
{
    public class OrderViewModel
    {

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int SupplierId { get; set; }
        public string OrderCode { get; set; }
        public DateTime DeliveryDate { get; set; }

        public string Address { get; set; }



    }
}
