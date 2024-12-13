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
    public partial class SimpleInsertUpdateDelete : System.Web.UI.Page
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

        //call this method to bind gridview
        private void BindSubjectData()
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
                    gvSubDetails.DataSource = dt;
                    gvSubDetails.DataBind();
                    sqlCon.Close();
                }
            }
        }

        //Insert click event to insert new record to database
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            bool IsAdded = false;
            string SubjectName = txtSubjectName.Text.Trim();
            int Marks = Convert.ToInt32(txtMarks.Text);
            string Grade = txtGrade.Text;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "INSERT INTO SubjectDetails(SubjectName,Marks,Grade)VALUES(@SubjectName,@Marks,@Grade)";
                    cmd.Parameters.AddWithValue("@SubjectName", SubjectName);
                    cmd.Parameters.AddWithValue("@Marks", Marks);
                    cmd.Parameters.AddWithValue("@Grade", Grade);
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsAdded = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsAdded)
            {
                lblMsg.Text = "'" + SubjectName + "' subject details added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;

                BindSubjectData();
            }
            else
            {
                lblMsg.Text = "Error while adding '" + SubjectName + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();//to reset all form controls
        }

        //Update click event to update existing record from the gridview
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubjectId.Text))
            {
                lblMsg.Text = "Please select record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            bool IsUpdated = false;
            int SubjectID = Convert.ToInt32(txtSubjectId.Text);
            string SubjectName = txtSubjectName.Text.Trim();
            int Marks = Convert.ToInt32(txtMarks.Text);
            string Grade = txtGrade.Text;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE SubjectDetails SET SubjectName=@SubjectName,Marks=@Marks,Grade=@Grade WHERE SubjectID=@SubjectId";
                    cmd.Parameters.AddWithValue("@SubjectId", SubjectID);
                    cmd.Parameters.AddWithValue("@SubjectName", SubjectName);
                    cmd.Parameters.AddWithValue("@Marks", Marks);
                    cmd.Parameters.AddWithValue("@Grade", Grade);
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsUpdated = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsUpdated)
            {
                lblMsg.Text = "'" + SubjectName + "' subject details updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMsg.Text = "Error while updating '" + SubjectName + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            gvSubDetails.EditIndex = -1;
            BindSubjectData();
            ResetAll();//to reset all form controls
        }

        //Delete click event to delete selected record from the database
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubjectId.Text))
            {
                lblMsg.Text = "Please select record to delete";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            bool IsDeleted = false;
            int SubjectID = Convert.ToInt32(txtSubjectId.Text);
            string SubjectName = txtSubjectName.Text.Trim();
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
                lblMsg.Text = "'" + SubjectName + "' subject details deleted successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                BindSubjectData();
            }
            else
            {
                lblMsg.Text = "Error while deleting '" + SubjectName + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll();//to reset all form controls
        }

        //Cancel click event to clear and reset all the textboxes
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAll();//to reset all form controls
        }

        protected void gvSubDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSubjectId.Text =
            gvSubDetails.DataKeys[gvSubDetails.SelectedRow.RowIndex].Value.ToString();
            txtSubjectName.Text = (gvSubDetails.SelectedRow.FindControl("lblSubjectName")
            as Label).Text;
            txtMarks.Text = (gvSubDetails.SelectedRow.FindControl("lblMarks") as Label).Text;
            txtGrade.Text = (gvSubDetails.SelectedRow.FindControl("lblGrade") as Label).Text;
            //make invisible Insert button during update/delete
            btnInsert.Visible = false;
        }

        //call to reset all form controls
        private void ResetAll()
        {
            btnInsert.Visible = true;
            txtSubjectId.Text = "";
            txtSubjectName.Text = "";
            txtMarks.Text = "";
            txtGrade.Text = "";
        }
    }
}