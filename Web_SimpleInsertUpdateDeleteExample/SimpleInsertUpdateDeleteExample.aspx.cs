using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_SimpleInsertUpdateDeleteExample
{
    public partial class SimpleInsertUpdateDeleteExample : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (!IsPostBack)
            {
                BindSubjectData();
            }
        }

        //call to bind gridview
        protected void BindSubjectData()
        {
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM SubjectDetails";
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvSubDetails.DataSource = dt;
                        gvSubDetails.DataBind();
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                        gvSubDetails.DataSource = dt;
                        gvSubDetails.DataBind();
                        gvSubDetails.Rows[0].Visible = false;
                    }
                    sqlCon.Close();
                }
            }
        }

        //called on row edit command
        protected void gvSubDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSubDetails.EditIndex = e.NewEditIndex;
            BindSubjectData();
        }

        //called when cancel edit mode
        protected void gvSubDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSubDetails.EditIndex = -1;
            BindSubjectData();
        }

        //called on row add new command
        protected void gvSubDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                bool IsAdded = false;
                TextBox SubjectName = (TextBox)gvSubDetails.FooterRow.FindControl("newSubjectName");
                TextBox Marks = (TextBox)gvSubDetails.FooterRow.FindControl("newMarks");
                TextBox Grade = (TextBox)gvSubDetails.FooterRow.FindControl("newGrade");
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "INSERT INTO SubjectDetails(SubjectName,Marks,Grade)VALUES(@SubjectName,@Marks,@Grade)";
                        cmd.Parameters.AddWithValue("@SubjectName", SubjectName.Text);
                        cmd.Parameters.AddWithValue("@Marks", Marks.Text);
                        cmd.Parameters.AddWithValue("@Grade", Grade.Text);
                        cmd.Connection = sqlCon;
                        sqlCon.Open();
                        IsAdded = cmd.ExecuteNonQuery() > 0;
                        sqlCon.Close();
                    }
                }
                if (IsAdded)
                {
                    lblMsg.Text = "'" + SubjectName.Text + "' subject details has been added successfully!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;

                    BindSubjectData();
                }
                else
                {
                    lblMsg.Text = "Error while adding '" + SubjectName.Text + "' subject details";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        //called on row update command
        protected void gvSubDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool IsUpdated = false;
            //getting key value, row id
            int SubjectID = Convert.ToInt32(gvSubDetails.DataKeys[e.RowIndex].Value.ToString());
            //getting row field details
            TextBox SubjectName = (TextBox)gvSubDetails.Rows[e.RowIndex].FindControl("txtSubjectName");
            TextBox Marks = (TextBox)gvSubDetails.Rows[e.RowIndex].FindControl("txtMarks");
            TextBox Grade = (TextBox)gvSubDetails.Rows[e.RowIndex].FindControl("txtGrade");
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE SubjectDetails SET SubjectName=@SubjectName,Marks=@Marks,Grade=@Grade WHERE SubjectID=@SubjectId";
                    cmd.Parameters.AddWithValue("@SubjectId", SubjectID);
                    cmd.Parameters.AddWithValue("@SubjectName", SubjectName.Text);
                    cmd.Parameters.AddWithValue("@Marks", Marks.Text);
                    cmd.Parameters.AddWithValue("@Grade", Grade.Text);
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsUpdated = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsUpdated)
            {
                lblMsg.Text = "'" + SubjectName.Text + "' subject details has been updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMsg.Text = "Error while updating '" + SubjectName.Text + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            gvSubDetails.EditIndex = -1;
            BindSubjectData();
        }

        //called on row delete command
        protected void gvSubDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bool IsDeleted = false;
            //getting key value, row id
            int SubjectID = Convert.ToInt32(gvSubDetails.DataKeys[e.RowIndex].Value.ToString());
            //getting row field subjectname
            Label SubjectName = (Label)gvSubDetails.Rows[e.RowIndex].FindControl("lblSubjectName");
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE FROM SubjectDetails WHERE SubjectId=@SubjectID";
                    cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsDeleted = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsDeleted)
            {
                lblMsg.Text = "'" + SubjectName.Text + "' subject details has been deleted successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                BindSubjectData();
            }
            else
            {
                lblMsg.Text = "Error while deleting '" + SubjectName.Text + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}