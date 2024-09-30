using AssignmentConsole.Model;
using AssignmentWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentWebApplication.Data {
    public class DataContext : DbContext {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration) {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<AssignmentResult> AssignmentsResult { get; set; }
        public virtual DbSet<AssignmentSubmission> AssignmentSubmission { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public virtual DbSet<Testcase<string>> Testcases { get; set; }

    }
}
