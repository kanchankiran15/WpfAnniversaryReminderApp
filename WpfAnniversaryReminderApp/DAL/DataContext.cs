using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Text;
using WpfAnniversaryReminderApp.Model;

namespace WpfAnniversaryReminderApp.DAL
{
    public class DataContext
    {
        //get employeeBy details by Id from database
        //
        Employee _emp;// = new Employee();

        public DataContext(Employee employee)
        {
            _emp = employee;
        }
        private string connString = ConfigurationManager.ConnectionStrings["empDatabase"].ConnectionString;
        private SqlConnection connection;

        public bool Login()
        {

            try
            {
                // = new SqlConnection(connString);
                using (connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Employee where Email='" + _emp.Email + "'  and password='" + _emp.Password + "'", connection);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        _emp.IsValid = true;
                        //_emp.Name = dataSet.Tables[0].Rows[0]["Name"].ToString();
                        //_emp.Email = dataSet.Tables[0].Rows[0]["Email"].ToString();
                        //_emp.Phone = dataSet.Tables[0].Rows[0]["Phone"].ToString();
                        //_emp.PhotoPath = dataSet.Tables[0].Rows[0]["Photo"].ToString();
                        //_emp.DOJ = dataSet.Tables[0].Rows[0]["DOJ"].ToString();
                        //_emp.DOB = dataSet.Tables[0].Rows[0]["DOB"].ToString();
                    }
                    else
                    {
                        _emp.IsValid = false;
                    }
                }

            }
            catch (Exception ex)
            {
                _emp.IsValid = false;
                throw;
            }
            finally
            {
                connection.Close();
            }
            //connect to db
            return _emp.IsValid;
        }

        public Employee getEmployeeById()
        {

            try
            {
                // = new SqlConnection(connString);
                using (connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Employee where Email='" + _emp.Email + "'", connection);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        _emp.IsValid = true;
                        _emp.Name = dataSet.Tables[0].Rows[0]["Name"].ToString();
                        _emp.Email = dataSet.Tables[0].Rows[0]["Email"].ToString();
                        _emp.Phone = dataSet.Tables[0].Rows[0]["Phone"].ToString();
                        _emp.PhotoPath = dataSet.Tables[0].Rows[0]["Photo"].ToString();
                        _emp.DOJ = dataSet.Tables[0].Rows[0]["DOJ"].ToString();
                        _emp.DOB = dataSet.Tables[0].Rows[0]["DOB"].ToString();
                    }
                    else
                    {
                        _emp.IsValid = false;
                    }
                }

            }
            catch (Exception ex)
            {
                _emp.IsValid = false;
                throw;
            }
            finally
            {
                connection.Close();
            }
            //connect to db
            return _emp;
        }

        public List<Employee> GetAnniversaries()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (connection = new SqlConnection(connString))
                {
                  
                    connection.Open();
                    SqlCommand cmd = new SqlCommand($"Select * from Employee WHERE DATEADD( Year, DATEPART( Year, GETDATE()) - DATEPART( Year, DOB), DOB)" +
                        $" BETWEEN CONVERT(DATE, GETDATE()) AND CONVERT(DATE, GETDATE() + 7)", connection);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        employees.Add(new Employee
                        {
                            DOB = row["DOB"].ToString(),
                            Email = row["Email"].ToString(),
                            Name = row["Name"].ToString(),
                            Phone = row["Phone"].ToString(),
                            PhotoPath = row["Photo"].ToString()
                        });
                    }

                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return employees;
        }

        public bool SaveEmployee()
        {
           
            try
            {
                using (connection = new SqlConnection(connString))
                {//CAST('2011-05-25' AS DATETIME)
                    string strDob = Convert.ToDateTime(_emp.DOB).ToString("yyyy-MM-dd h:mm tt").ToString();
                    string strDoj = Convert.ToDateTime(_emp.DOJ).ToString("yyyy-MM-dd h:mm tt").ToString();
                    SqlCommand cmd = new SqlCommand($"Update Employee Set Name = '{_emp.Name}', DOB=CAST('{strDob}' AS DATETIME),DOJ=CAST('{strDoj}' AS DATETIME),Phone='{_emp.Phone}' where Email='{_emp.Email}'", connection);
                    cmd.CommandType = CommandType.Text;
                    
                    connection.Open();                    
                    cmd.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
          
        }
    }
}
