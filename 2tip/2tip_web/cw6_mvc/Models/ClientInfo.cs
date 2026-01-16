using System;

namespace cw6_mvc.Models;

public class ClientInfo
{
    public string? ClientName { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
}
