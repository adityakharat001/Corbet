using Corbet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDiscription { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
