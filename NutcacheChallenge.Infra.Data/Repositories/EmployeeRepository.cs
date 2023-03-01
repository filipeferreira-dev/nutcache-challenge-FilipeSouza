using Microsoft.EntityFrameworkCore;
using NutcacheChallenge.Domain.Models;
using NutcacheChallenge.Domain.Repositories;
using NutcacheChallenge.Infra.Data.Context;

namespace NutcacheChallenge.Infra.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        NutcacheContext Context { get; }

        DbSet<Employee> Table { get; }

        public EmployeeRepository(NutcacheContext context)
        {
            Context = context;
            Table = Context.Set<Employee>();
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            var entry = await Context.AddAsync(employee);
            await Context.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            Table.Remove(employee);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(long id)
        {
            return await Table.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            Context.Update(employee);
            await Context.SaveChangesAsync();
            return employee;
        }
    }
}
