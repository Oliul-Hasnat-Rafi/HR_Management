using HR_Management.Model.App_Model;
namespace API_Task.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {

        IGenericRepository<Company> Companies { get; }
        IGenericRepository<Designation> Designations { get; }
        IGenericRepository<Attendance> Attendances { get; }
        IGenericRepository<AttendanceSummary> AttendanceSummarys { get; }
        IGenericRepository<Department> Departments { get; }
        IGenericRepository<Employee> Employees { get; }
        IGenericRepository<Salary> Salarys { get; }
        IGenericRepository<Shift> Shifts { get; }
   

        Task SaveAsync();
        Task ExecuteProcedureWithoutResult(string query);
    }
}
