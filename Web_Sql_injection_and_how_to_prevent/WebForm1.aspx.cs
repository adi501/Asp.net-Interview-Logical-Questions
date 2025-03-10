﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Sql_injection_and_how_to_prevent
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string con = @"Data Source=yourdatasource;Integrated Security=true;Initial Catalog=yourDB";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnWithSqlInjection_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM UserDetails WHERE UserName='" + txtUserName.Text + "'";
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCon.Close();
                    if (dt.Rows.Count > 0)
                    {
                        lblMsg.Text = "Login Successful.";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMsg.Text = "Login Failed.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void btnWithProtection_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM UserDetails WHERE UserName=@UserName";
                    cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCon.Close();
                    if (dt.Rows.Count > 0)
                    {
                        lblMsg.Text = "Login Successful.";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMsg.Text = "Login Failed.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}