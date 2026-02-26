/*
 using Data;
using Microsoft.EntityFrameworkCore;

namespace SchoolAPI
{
    public class LinqQuerySyntaxDemo
    {
        public static void Run()
        {
            // SQL
            // SELECT Id, Name, Age
            // FROM Students
            // WHERE Age >= 18
            // ORDER BY Name;
            var context = new ApiContext(null);

            var query =
                from s in context.Students
                where s.Age >= 18
                orderby s.Name
                select new
                {
                    s.Id,
                    s.Name,
                    s.Age
                };

            var result = query.ToList();
        }
    }
}

*/