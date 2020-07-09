using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class TodoViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Label")]
        public string Name { get; set; }
        [Display(Name = "I have done it.")]
        public bool IsComplete { get; set; }
    }
}