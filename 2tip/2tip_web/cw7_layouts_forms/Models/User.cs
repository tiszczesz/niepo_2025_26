using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace cw7_layouts_forms.Models;

public class User
{
    public int Id { get; set; }
    
    [DisplayName("Nazwa użytkownika")]
    [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
    [MinLength(3, ErrorMessage = "Nazwa użytkownika musi mieć co najmniej 3 znaki")]
    public string? Username { get; set; }
    
    [DisplayName("Email")]
    [Required(ErrorMessage = "Email jest wymagany")]
    [EmailAddress(ErrorMessage = "Niepoprawny format emaila")]
    public string? Email { get; set; }
    
    [DisplayName("Data rejestracji")]
    [Required(ErrorMessage = "Data rejestracji jest wymagana")]
    [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
    public DateTime? Date { get; set; }
}
