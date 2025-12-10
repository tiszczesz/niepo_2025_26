using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace egzamin1.Models;

public class User
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Podaj nazwę użytkownika")]
    [DisplayName("Nazwa użytkownika")]
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
}
