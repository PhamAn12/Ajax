using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AJAX_CRUD.Models
{
    public class StudentDB
    {
        const string SqlConnectionString = "Server=(local);Database=StudentAjax;Integrated Security=SSPI";
        // Code table Students
        string db = @"CREATE TABLE [dbo].[StudentsTable](
	                [StudentId] [int] IDENTITY(1,1) NOT NULL,
	                [Name] [nvarchar](max) NULL,
	                [Status] [nvarchar](max) NULL)";
        public StudentDB()
        {

        }

        public List<Student> All()
        {
            var ListStudent = new List<Student> ();
            string sql = "Select * from StudentsTable";
            SqlConnection con = new SqlConnection(SqlConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                ListStudent.Add(new Student
                {
                    StudentId = int.Parse(reader["StudentId"].ToString()),
                    Name = reader["Name"].ToString(),
                    Status = reader["Status"].ToString()

                });
            }
            return ListStudent;
        }

        public int Add (Student entity)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            string sql = "insert into StudentsTable(Name,Status) Values (N'" +entity.Name+ "','"+entity.Status+"') ";
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();

            int rs = cmd.ExecuteNonQuery();
            return rs;
        }

        public int Update (Student entity)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            string sql = "UPDATE StudentsTable SET Name = N'" + entity.Name + "', Status = '" + entity.Status + "' WHERE StudentId=" + entity.StudentId + " ;";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            int rs = cmd.ExecuteNonQuery();
            return rs;
        }

        public int Delete (int id)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            string sql = "Delete from StudentsTable Where StudentId = " + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            int rs = cmd.ExecuteNonQuery();
            return rs;
        }

    }

    
}