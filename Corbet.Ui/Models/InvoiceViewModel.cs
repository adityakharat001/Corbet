using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public Guid InvoiceNumber { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string DelivaryAddress { get; set; }
        public DateTime ReceivedDate { get; set; }= DateTime.Now;
        public DateTime ExpectedDate { get; set; }
        public float TotalPrice { get; set; }
        public bool Status { get; set; }
    }
}
