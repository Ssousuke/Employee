using Employee.Entities.Enums;

namespace Employee.Entities;

class Worker
{
    public string Name { get; set; }
    public WorkerLevel Level { get; set; }
    public Double BaseSalary { get; set; }

    public void AddContract(HourContract contract)
    {
        // Implementar
    }

    public void RemoveContract(HourContract contract)
    {
        // Implementar
    }

    public double Income(int year, int month)
    {
        // Implementar
        return 0.0;
    }
}