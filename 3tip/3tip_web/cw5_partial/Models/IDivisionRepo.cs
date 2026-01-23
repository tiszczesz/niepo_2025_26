using System;

namespace cw5_partial.Models;

public interface IDivisionRepo
{
    public IEnumerable<Division> GetDivisions();
    public Division? GetDivision(int id);
    public void AddDivision(Division division);
    public void UpdateDivision(Division division);
    public void DeleteDivision(int id);
}
