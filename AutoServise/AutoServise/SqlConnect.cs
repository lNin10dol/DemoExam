using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServise
{

    internal class SqlConnect
    {
        public static SqlConnection myConnection = new SqlConnection(@"Server=DESKTOP-O3DB5NP\SQLEXPRESS;Initial catalog=autoservise;Integrated Security=True");
        public class ListBar
        {
            public static SqlConnect sqlConnect;
            public static List<Id_clietn> id_Clietns = new List<Id_clietn>();
            public static List<Client> clients = new List<Client>();
            public static List<Car> cars = new List<Car>();
        }

        public static void GetDatas()
        {

            ListBar.clients = new List<Client>();
            ListBar.cars = new List<Car>();
            GetClienData();
            GetCarsData();
            GetIdClient();
        }

        public SqlConnect()
        {
            GetDatas();
        }
            

        
            
        public class Client
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Second_name { get; set; }
            public string DateBtd { get; set; }
            public int NumberPassport { get; set; }
        }

        public class Car 
        {
            public string Brend {  get; set; }
            public string Model {  get; set; }
            public string Color {  get; set; }
            public int id_client { get; set; }
        
        }

        public class Id_clietn
        {
            public int idClietn { get; set; }
        }
        public static bool GetClienData()
        {  
            try
            {
                SqlConnect.myConnection.Open();
                string SqlC = "select * from client";   
                SqlCommand sqlCommand = new SqlCommand(SqlC, SqlConnect.myConnection);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    ListBar.clients.Add(new Client()
                    {
                        Surname = Convert.ToString(dr[1]),
                        Name = Convert.ToString(dr[2]),
                        Second_name = Convert.ToString(dr[3]),
                        DateBtd = Convert.ToString(dr[4]),
                        NumberPassport = Convert.ToInt32(dr[5])
                    });
                }
                    myConnection.Close();
                    return true;


            }
            catch (Exception)
            {


            }
            myConnection.Close();
            return false;
        }

        public static bool GetCarsData()
        {
            try
            {
                SqlConnect.myConnection.Open();
                string SqlC = "select * from car";
                SqlCommand sqlCommand = new SqlCommand(SqlC, SqlConnect.myConnection);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    ListBar.cars.Add(new Car()
                    {
                        Brend = Convert.ToString(dr[1]),
                        Model = Convert.ToString(dr[2]),
                        Color = Convert.ToString(dr[3]),
                        id_client = Convert.ToInt32(dr[4])

                    });
                }
                myConnection.Close();
                return true;


            }
            catch (Exception)
            {


            }
            myConnection.Close();
            return false;

        }

        public static bool AddClient(string Surname,string name,string secondName,string dateOfBtd, string numberPassport)
        {
            try
            {


                SqlConnect.myConnection.Open();
                string SqlC = $"insert into client (Surname,[Name],Second_name,date_of_btd,Number_passport) values ('{name}','{Surname}','{secondName}','{Convert.ToDateTime(dateOfBtd)}',{Convert.ToInt32(numberPassport)})";
                SqlCommand sqlCommand = new SqlCommand(SqlC, SqlConnect.myConnection);
                SqlDataReader dr = sqlCommand.ExecuteReader();
             
                myConnection.Close();
                return true;


            }
            catch (Exception)
            {


            }
            myConnection.Close();
            return false;
        }
        
        public static bool GetIdClient()
        {
            try
            {
                SqlConnect.myConnection.Open();
                string SqlC = "select id from client";
                SqlCommand sqlCommand = new SqlCommand(SqlC, SqlConnect.myConnection);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    ListBar.id_Clietns.Add(new Id_clietn()
                    {
                        idClietn = Convert.ToInt32(dr[0]),

                    });
                }
                myConnection.Close();
                return true;


            }
            catch (Exception)
            {


            }
            myConnection.Close();
            return false;
        }
        public static bool AddCar(string brend, string model, string color, string id_clietn)
        {
            try
            {


                SqlConnect.myConnection.Open();
                string SqlC = $"insert into car (brend,model,color,id_client) values ('{brend}','{model}','{color}',{id_clietn})";
                SqlCommand sqlCommand = new SqlCommand(SqlC, SqlConnect.myConnection);
                SqlDataReader dr = sqlCommand.ExecuteReader();

                myConnection.Close();
                return true;


            }
            catch (Exception)
            {


            }
            myConnection.Close();
            return false;
        }

        public static bool ClientDelete(object a)
        {
            ClientData s = a as ClientData;
            return true;
        }
    }

    
}
