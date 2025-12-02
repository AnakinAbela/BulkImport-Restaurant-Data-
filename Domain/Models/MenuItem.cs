using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class MenuItem : IItemValidating
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        [ForeignKey("RestaurantFK")]
        public virtual Restaurant Restaurant { get; set; }
        public int RestaurantFK { get; set; }

        public bool Status { get; set; }

        public List<string> GetValidators()
        {
            return new List<string>() { Restaurant?.OwnerEmailAddress };
        }

        public string GetCardPartial()
        {
            return "_MenuItemCard";
        }
    }
}