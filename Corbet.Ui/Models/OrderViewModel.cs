using Corbet.Domain.Entities;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corbet.Ui.Models
{
    public class OrderViewModel
    {

      //  public int OrderId { get; set; }
        public int? UserId { get; set; }
        [DisplayName("Supplier")]
        [Required(ErrorMessage = "Supplier is required")]
        //[MinLength(3, ErrorMessage = "First Name must at least 3 characters")]
       // [MaxLength(20, ErrorMessage = "First Name must less than 20 characters")]
       // [RegularExpression(@"^([a-zA-Z])*$", ErrorMessage = " First Name must contain only alphabet")]
        public int SupplierId { get; set; }

        
        public string? OrderCode { get; set; }
        public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = "State is required")]
        [DisplayName("State")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "City is required")]
         [RegularExpression(@"^([a-zA-Z])*$", ErrorMessage = "City is Invalid")]
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("ZipCode")]
       // [RegularExpression(@"^([0-9]{6,})*$", ErrorMessage = " Invalid ZipCode")]

        public int ZipCode { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [MaxLength(100)]
  

       

        public string? ProductName { get; set; }

        public double? Price { get; set; }
        public int? Quantity { get; set; }
      public  List<GetAllCart>? GetAllCart { get; set; }

    }
}
