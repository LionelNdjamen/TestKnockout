using Getting_Start.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Getting_Start.Helpers
{
    public class ServiceCustomer
    {
        private static string[] GetTableSexe()
        {
            string[] TableSexe = { "Erreur", "Masculin", "Feminin" }; 
            return TableSexe; 
        }
        public static List<Customer> GetCustomer()
        {
            List<Customer> ListCustomer = new List<Customer>();
            var TableSexe = ServiceCustomer.GetTableSexe(); 

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[1].ToString();
            try
            {
                connection.Open();
                SqlCommand Cmd = new SqlCommand("[GET_ALL_CUSTOMER]", connection);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader MyReader = Cmd.ExecuteReader();
                while (MyReader.Read())
                {
                    Customer MyCustomer = new Customer();
                    MyCustomer.Id = Convert.ToInt32(MyReader["CustomerID"]);
                    MyCustomer.LastName = MyReader["LastName"].ToString();
                    MyCustomer.FirstName = MyReader["FirstName"].ToString();
                    MyCustomer.Age = Convert.ToInt32(MyReader["Age"]);
                    MyCustomer.Suppression = Convert.ToBoolean(MyReader["IsDeleted"]);
                    MyCustomer.Sexe = TableSexe[Convert.ToInt32(MyReader["SexeID"])]; 

                    ListCustomer.Add(MyCustomer);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return ListCustomer; 
        }

        //Retourne un customer a partir de son id
        public static Customer GetCustomerByid(int id)
        {
            Customer MyCustomer = new Customer();
            var TableSexe = ServiceCustomer.GetTableSexe();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[1].ToString();
            try
            {
                connection.Open();
                SqlCommand Cmd = new SqlCommand("[GET_CUSTOMER_ById]", connection);
                SqlParameter MyParam = new SqlParameter("@id", id);
                Cmd.Parameters.Add(MyParam);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader MyReader = Cmd.ExecuteReader();
                while (MyReader.Read())
                {
                    MyCustomer.Id = Convert.ToInt32(MyReader["CustomerID"]);
                    MyCustomer.LastName = MyReader["LastName"].ToString();
                    MyCustomer.FirstName = MyReader["FirstName"].ToString();
                    MyCustomer.Age = Convert.ToInt32(MyReader["Age"]);
                    MyCustomer.Suppression = Convert.ToBoolean(MyReader["IsDeleted"]);
                    MyCustomer.Sexe = TableSexe[Convert.ToInt32(MyReader["SexeID"])]; 
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return MyCustomer;
        }

        //creation d'un nouveau customer
        public static void CreateCustomer(Customer myCustomer)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[1].ToString();
            try
            {
                connection.Open();
                SqlCommand Cmd = new SqlCommand("[CREATECUSTOMER]", connection);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter MyParam = new SqlParameter("@LastName", myCustomer.LastName);
                Cmd.Parameters.Add(MyParam);
                MyParam = new SqlParameter("@FirtName", myCustomer.FirstName);
                Cmd.Parameters.Add(MyParam);
                MyParam = new SqlParameter("@Age", myCustomer.Age);
                Cmd.Parameters.Add(MyParam);
                MyParam = new SqlParameter("@Sexe", myCustomer.Sexe);
                Cmd.Parameters.Add(MyParam);
                SqlDataReader MyReader = Cmd.ExecuteReader(); 
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //Modifie un customer
        public static void EditCustomer(Customer myCustomer)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[1].ToString();
            try
            {
                connection.Open();
                SqlCommand Cmd = new SqlCommand("[EDITCUSTOMER]", connection);
                SqlParameter MyParam = new SqlParameter("@LastName", myCustomer.LastName); 
                Cmd.Parameters.Add(MyParam); 
                MyParam = new SqlParameter("@FirtName", myCustomer.FirstName);
                Cmd.Parameters.Add(MyParam);
                MyParam = new SqlParameter("@Age", myCustomer.Age);
                Cmd.Parameters.Add(MyParam);
                MyParam = new SqlParameter("@Sexe", myCustomer.Sexe); 
                Cmd.Parameters.Add(MyParam); 
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader MyReader = Cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //supprime un customer
        public static void DeleteCustomer(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[1].ToString();
            try
            {
                connection.Open();
                SqlCommand Cmd = new SqlCommand("[DELETECUSTOMERById]", connection);
                SqlParameter MyParam = new SqlParameter("@id", id);
                Cmd.Parameters.Add(MyParam); 
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader MyReader = Cmd.ExecuteReader(); 
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}