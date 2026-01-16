using System;
using System.ComponentModel.DataAnnotations;

namespace cw6_mvc.Models;

public class Person
{
   // public int Id { get; set; }
    
    [Required(ErrorMessage = "Podaj imię")]
    public string? Firstname { get; set; }
    
    [Required(ErrorMessage = "Podaj nazwisko")]
    public string? Lastname { get; set; }

   [Required(ErrorMessage = "Podaj wiek")]
   [Range(1, 130, ErrorMessage = "Wiek musi być z zakresu od 1 do 130")]
    public int? Age { get; set; }
}
