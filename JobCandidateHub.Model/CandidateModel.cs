using System.ComponentModel.DataAnnotations;

namespace JobCandidateHub.Model
{
    public class CandidateModel
    {
        [Required(ErrorMessage = "First Name is Required Field.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required Field.")]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Adress is Required Field.")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Adresses.")]
        public string Email { get; set; }

        public DateTime? TimeIntervalStart { get; set; }

        public DateTime? TimeIntervalEnd { get; set; }

        [Url]
        public string LinkedIn { get; set; }

        [Url]
        public string GitHub { get; set; }

        [MaxLength(10000)]
        [Required(ErrorMessage = "Comment can't be empty.")]
        public string Comment { get; set; }
    }
}
