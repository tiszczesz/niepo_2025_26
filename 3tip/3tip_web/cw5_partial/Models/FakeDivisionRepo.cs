using System;

namespace cw5_partial.Models;

public class FakeDivisionRepo : IDivisionRepo
{
    private static List<Division> _divisions = new List<Division>
    {
        new Division { Id = 1, Name = "Division A", Description = "Description for Division A" },
        new Division { Id = 2, Name = "Division B", Description = "Description for Division B" },
        new Division { Id = 3, Name = "Division C", Description = "Description for Division C" },
        new Division { Id = 4, Name = "Division D", Description = "Description for Division D" },
        new Division { Id = 5, Name = "Division E", Description = "Description for Division E" },
        new Division { Id = 6, Name = "Division F", Description = "Description for Division F" },
    };
    public void AddDivision(Division division)
    {
        throw new NotImplementedException();
    }

    public void DeleteDivision(int id)
    {
        throw new NotImplementedException();
    }

    public Division? GetDivision(int id)
    {
        return _divisions.FirstOrDefault(d => d.Id == id);
    }

    public IEnumerable<Division> GetDivisions()
    {
        return _divisions;
    }

    public void UpdateDivision(Division division)
    {
        throw new NotImplementedException();
    }
}
