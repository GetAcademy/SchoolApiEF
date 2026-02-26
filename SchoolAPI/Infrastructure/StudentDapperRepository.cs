/*
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using DomainStudent = SchoolAPI.Model.Student;

namespace SchoolAPI.Infrastructure
{
    public class StudentDapperRepository : WithDI.IStudentRepository
    {
        private readonly SqlConnection _connection;

        // IDbConnection kan konfigureres i DI (f.eks. SqlConnection)
        public StudentDapperRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        // Liten hjelpe-metode for å sikre at connection er åpen
        private IDbConnection GetOpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }

        // Liten intern type til mapping
        private record StudentRow(int Id, string Name, int Age);

        public List<DomainStudent> GetAll()
        {
            const string sql = """
                SELECT Id, Name, Age
                FROM Students
                """;

            var conn = GetOpenConnection();

            var rows = conn.Query<StudentRow>(sql);

            return rows
                .Select(s => new DomainStudent(s.Id, s.Name, s.Age))
                .ToList();
        }

        public DomainStudent? GetById(int id)
        {
            const string sql = """
                SELECT Id, Name, Age
                FROM Students
                WHERE Id = @Id
                """;

            var conn = GetOpenConnection();

            var row = conn.QuerySingleOrDefault<StudentRow>(sql, new { Id = id });
            if (row is null) return null;

            return new DomainStudent(row.Id, row.Name, row.Age);
        }

        public DomainStudent Create(string name, int age)
        {
            // Forutsetter SQL Server med identity-kolonne på Id
            const string sql = """
                INSERT INTO Students (Name, Age)
                VALUES (@Name, @Age);
                SELECT CAST(SCOPE_IDENTITY() AS int);
                """;

            var conn = GetOpenConnection();

            var id = conn.ExecuteScalar<int>(sql, new { Name = name, Age = age });

            return new DomainStudent(id, name, age);
        }
    }
}
*/