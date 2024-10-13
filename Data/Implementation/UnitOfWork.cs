using API_Task.Data.Interface;
using HR_Management.Model.App_Model;
using Microsoft.EntityFrameworkCore;

namespace API_Task.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _context;
        private GenericRepository<Attendance> _Attendances;
        private GenericRepository<Company> _Companies;
        private GenericRepository<Designation> _Designations;
        private GenericRepository<Department> _Departments;
        private GenericRepository<Shift> _Shifts;
        private GenericRepository<Employee> _Employees;
        private GenericRepository<AttendanceSummary> _AttendanceSummaries;
        private GenericRepository<Salary> _Salaries;




        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

       
        public IGenericRepository<Company> Companies => _Companies ??= new GenericRepository<Company>(_context);
        public IGenericRepository<Designation> Designations => _Designations ??= new GenericRepository<Designation>(_context);
        public IGenericRepository<Department> Departments => _Departments ??= new GenericRepository<Department>(_context);
        public IGenericRepository<Employee> Employees => _Employees ??= new GenericRepository<Employee>(_context);
        public IGenericRepository<AttendanceSummary> AttendanceSummarys => _AttendanceSummaries ??= new GenericRepository<AttendanceSummary>(_context);
        public IGenericRepository<Salary> Salarys => _Salaries ??= new GenericRepository<Salary>(_context);
        public IGenericRepository<Shift> Shifts => _Shifts ??= new GenericRepository<Shift>(_context);
     public IGenericRepository<Attendance> Attendances => _Attendances ??= new GenericRepository<Attendance>(_context);
    

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _context.Dispose();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task ExecuteProcedureWithoutResult(string query)
        {
            await _context.Database.ExecuteSqlRawAsync(query);
        }

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
