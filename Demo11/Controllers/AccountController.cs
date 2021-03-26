using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Demo11.Models;

namespace Demo11.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {

            return View();

        }
        void connectionString()
        {
            con.ConnectionString = @"Data Source=DESKTOP-EDKIR8O;Initial Catalog=DEMO;Integrated Security=True";
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = " select * from Table_1 where userName= '"+ acc.Name+"' and Password= '"+acc.Password+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Create");
            }    
            else
            {
                con.Close();
                return View("Error");
            }                

            
            
        }
    }
}