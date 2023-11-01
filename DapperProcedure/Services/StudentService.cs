using Dapper;
using DapperProcedure.Models;
using System.Data;
using System.Data.SqlClient;

namespace DapperProcedure.Services
{
    public class StudentService
    {
        private readonly string ConnectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("ConnectionString");

        public Student GetStudentById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("id", id);

                Student student = connection.QueryFirst<Student>("GetById", parameters, commandType: CommandType.StoredProcedure);

                return student;
            }
        }
        public async Task<IQueryable<Student>> GetStudentByYear(string beginYear, string endYear)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("BeginYear", beginYear);
                parameters.Add("EndYear", endYear);

                var student = (await connection.QueryAsync<Student>("GetByYear", param: parameters,
                    commandType: CommandType.StoredProcedure)).AsQueryable();

                return student;
            }
        }
    }
}
