using Corbet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class CategoryDetailsUpdateModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
       
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
