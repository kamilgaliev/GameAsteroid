using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAPIService
{
    public class DB
    {
        SqlConnection connection;
        public SqlDataAdapter adapter;
        SqlParameter param;

        public DB()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter();
        }

        public DataTable EmplList()
        {
            var command = new SqlCommand("SELECT E.ID AS ID ,E.NAME AS NAME,AGE, D.ID AS IDDEP,D.NAME AS DEP FROM EMPLOYEE E JOIN EMPL_DEP ED ON E.ID=ED.IDEMPL JOIN DEPARTMENT D ON D.ID=ED.IDDEP", connection);

            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public DataTable AllEmpl()
        {
            var command = new SqlCommand("SELECT ID ,NAME,AGE FROM EMPLOYEE", connection);

            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        internal void AddDep(string name)
        {
            connection.Open();
            var command = new SqlCommand(@"INSERT INTO DEPARTMENT (NAME) VALUES (@NAME); SET @ID = @@IDENTITY;", connection);
            command.Parameters.AddWithValue("@NAME", name);

            param = command.Parameters.AddWithValue("@ID", "ID");
            param.Direction = ParameterDirection.Output;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddEmpl(string name, int age, int IdDep)
        {
            connection.Open();
            var command = new SqlCommand(@"INSERT INTO EMPLOYEE (NAME,AGE) VALUES (@NAME,@AGE ) SET @ID = @@IDENTITY;", connection);

            command.Parameters.AddWithValue("@NAME", name);
            command.Parameters.AddWithValue("@AGE", age);
            param = command.Parameters.AddWithValue("@ID", "ID");
            param.Direction = ParameterDirection.Output;

            command.ExecuteNonQuery();
            command = new SqlCommand(@"select @@IDENTITY from EMPLOYEE;", connection);
            int idEmpl = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();
            AddEmplDep(idEmpl, IdDep);
        }
        public void UpdateEmpl(int id, string name, int age, int IdDep)
        {
            connection.Open();
            var command = new SqlCommand(@"UPDATE EMPLOYEE SET NAME = @NAME, AGE = @AGE WHERE ID = @ID", connection);
            command.Parameters.AddWithValue("@NAME", name);
            command.Parameters.AddWithValue("@AGE", age);
            param = command.Parameters.AddWithValue("@ID", id);
            param.SourceVersion = DataRowVersion.Original;
            command.ExecuteNonQuery();

            connection.Close();
            UpdateEmplDep(id, IdDep);
        }

        private void AddEmplDep(int idEmpl, int idDep)
        {
            //int idDep = DepOne(nameDep);
            connection.Open();
            var command = new SqlCommand(@"INSERT INTO EMPL_DEP (IDEMPL,IDDEP) VALUES (@IDEMPL,@IDDEP); SET @ID = @@IDENTITY;", connection);
            command.Parameters.AddWithValue("@IDDEP", idDep);
            command.Parameters.AddWithValue("@IDEMPL", idEmpl);
            param = command.Parameters.AddWithValue("@ID", "ID");
            param.Direction = ParameterDirection.Output;

            command.ExecuteNonQuery();
            connection.Close();
        }
        private void UpdateEmplDep(int idEmpl, int idDep)
        {
            //int idDep = DepOne(nameDep);
            connection.Open();
            var command = new SqlCommand(@"UPDATE EMPL_DEP SET IDDEP = @IDDEP WHERE IDEMPL = @IDEMPL", connection);
            command.Parameters.AddWithValue("@IDDEP", idDep);
            command.Parameters.AddWithValue("@IDEMPL", idEmpl);
            param.SourceVersion = DataRowVersion.Original;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable DepList()
        {
            var command = new SqlCommand("SELECT ID, NAME FROM DEPARTMENT ", connection);
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public void UpdateDep(int id, string name)
        {
            connection.Open();
            var command = new SqlCommand(@"UPDATE DEPARTMENT SET NAME = @NAME WHERE ID = @ID", connection);
            command.Parameters.AddWithValue("@NAME", name);

            param = command.Parameters.AddWithValue("@ID", id);
            param.SourceVersion = DataRowVersion.Original;
            command.ExecuteNonQuery();
            connection.Close();

        }
        public string DepOne(int n)
        {
            connection.Open();
            var command = new SqlCommand("SELECT NAME FROM DEPARTMENT WHERE ID=@ID", connection);
            //string str = "SELECT ID FROM DEPARTMENT WHERE ID='" + n + "'";
            param = command.Parameters.AddWithValue("@ID", n);
            string vName = command.ExecuteScalar().ToString();
            connection.Close();
            return vName;
        }
    }
}