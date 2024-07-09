using StudentWebApp.Entity;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace StudentWebApp.Repository
{
    public class StudentRepo: IStudentRepo
    {
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student> ();
            string conString = @"server=localhost; port=3306; user=root; password=root; database=dotnet";

            MySqlConnection con=new MySqlConnection (conString);
            string Query = "SELECT * from students";
            try
            {
                con.Open ();
                MySqlCommand cmd = new MySqlCommand (Query, con);
                MySqlDataReader reader = cmd.ExecuteReader ();
                while (reader.Read())
                {
                    int id=int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    string email = reader["email"].ToString();
                    int mob = int.Parse(reader["mobile"].ToString());
                    string address = reader["address"].ToString();
                    string admission= reader["admission_date"].ToString();
                    double fees = double.Parse(reader["fees"].ToString()); 
                    string status= reader["status"].ToString();


                    Student stud= new Student();
                    stud.Id = id;
                    stud.Name = name;
                    stud.Email = email;
                    stud.Mobile = mob;
                    stud.Address = address;
                    stud.Fees= fees;
                    stud.Status = status;

                    students.Add (stud);


                }
                reader.Close ();

            }
            catch (Exception ex)
            {

            }

            finally
            {
                if(con.State != System.Data.ConnectionState.Closed)
                {
                    con.Close ();
                }
            }


        return students; 

        }
    }
}
