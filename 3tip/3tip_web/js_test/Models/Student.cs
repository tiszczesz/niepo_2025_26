using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace js_test.Models;

public class Student
{
    public int Id { get; set; }
    [DisplayName("Imię")]
    [Required(ErrorMessage = "Pole Imię jest wymagane.")]
    [StringLength(50, ErrorMessage = "Imię nie może być dłuższe niż 50 znaków.")]
    public string? FirstName { get; set; }
    [DisplayName("Nazwisko")]
    [Required(ErrorMessage = "Pole Nazwisko jest wymagane.")]
    [StringLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków.")]
    public string? LastName { get; set; }
    
    [DisplayName("Wiek")]
    [Required(ErrorMessage = "Pole Wiek jest wymagane.")]
    [Range(0, 150, ErrorMessage = "Wiek musi być liczbą z zakresu 0-150.")]
    public int Age { get; set; }
}
