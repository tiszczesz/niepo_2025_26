using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cw4_school2025.Models;

public class Student
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Podaj imię studenta")]
    [DisplayName("Imię")]
    [MaxLength(20, ErrorMessage = "Imię nie może być dłuższe niż 20 znaków")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Podaj nazwisko studenta")]
    [DisplayName("Nazwisko")]
    [MaxLength(20, ErrorMessage = "Nazwisko nie może być dłuższe niż 20 znaków")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Podaj datę urodzenia studenta")]
    [DisplayName("Data urodzenia")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Podaj liczbę punktów ECTS studenta")]
    [DisplayName("Punkty ECTS")]
    public int? EctsPoints { get; set; }
}
