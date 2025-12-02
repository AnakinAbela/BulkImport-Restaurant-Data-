using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Restaurant : IItemValidating
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerEmailAddress { get; set; }
        public bool Status { get; set; }

        public List<string> GetValidators()
        {
            return new List<string>() { "siteadmin@example.com" };
        }

        public string GetCardPartial()
        {
            return "_RestaurantCard";
        }
    }
}