using System.ComponentModel.DataAnnotations;

namespace WishList_RestService.Models
{
    public class Wish
    {
        [Key]
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

       /* IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (Name == "" || Description == "")
            {
                yield return new ValidationResult("Name or description cannot be empty");
            }
        }*/
    }
}
