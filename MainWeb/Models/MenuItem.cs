using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price Should be greater than 1 SP")]
        public double Price { get; set; }
        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [Display(Name = "Food Type")]
        public int FoodTypeId { get; set; }
        [ForeignKey("FoodTypeId")]
        public virtual FoodType FoodType { get; set; }
    }
}
