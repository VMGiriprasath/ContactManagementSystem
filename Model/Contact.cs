using System.ComponentModel.DataAnnotations;

public class Contact
{
    public int ID { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [MaxLength(15)]
    public string PhoneNumber { get; set; }

    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; }

    [MaxLength(100)]
    public string Address { get; set; }
}
