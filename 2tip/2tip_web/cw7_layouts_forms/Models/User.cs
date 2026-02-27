using System;

namespace cw7_layouts_forms.Models;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public DateTime? Date { get; set; }
}
