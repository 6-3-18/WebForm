using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class EMP : System.Web.UI.Page
{
    private const string V = "員工代號 或 姓名 不能空白!!";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindGrid();
        }
    }


    /// <summary>
    /// 刷新畫面
    /// 2024/05/24
    /// </summary>
    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["TESTDBConnectionString"].ConnectionString;
        string query = "SELECT * FROM EMP";
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }
    /// <summary>
    /// 新增記錄
    /// 2024/05/24
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Insert(object sender, EventArgs e)
    {
      // string emp_id = txtEmp_ID.Text;
        string emp_name = txtEmp_Name.Text;
        string age = txtAge.Text;
        string birthday = txtBirthday.Text;

      //  txtEmp_ID.Text = "";
        txtEmp_Name.Text = "";
        txtAge.Text = "";
        txtBirthday.Text = "";
        lbl_msg.Text = "";

        //if (!string.IsNullOrEmpty(emp_id) && !string.IsNullOrEmpty(emp_name))
        if (!string.IsNullOrEmpty(emp_name))
        {
            string query = "INSERT INTO emp VALUES(@EMP_NAME,@Age,@Birthday)";
            string constr = ConfigurationManager.ConnectionStrings["TESTDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                  //  cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
                    cmd.Parameters.AddWithValue("@EMP_NAME", emp_name);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Birthday", birthday);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();

        }
        else
        {
            lbl_msg.Text = V;

        }
    }

    /// <summary>
    /// 修改記錄
    /// 2024/05/24
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }

    /// <summary>
    /// 更新記錄
    /// 2024/05/24
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string emp_id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string emp_ame = (row.FindControl("txtEmp_Name") as TextBox).Text;
        int age =Convert.ToInt32( (row.FindControl("txtAge") as TextBox).Text);
        string birthday = (row.FindControl("txtBirthday") as TextBox).Text;

        string query = "UPDATE emp SET EMP_NAME=@EMP_NAME, Age=@Age  , Birthday=@Birthday WHERE EMP_ID=@EMP_ID";
        string constr = ConfigurationManager.ConnectionStrings["TESTDBConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
                cmd.Parameters.AddWithValue("@EMP_NAME", emp_ame);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Birthday", birthday);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        GridView1.EditIndex = -1;
        this.BindGrid();
    }

    /// <summary>
    /// 取消修改
    /// 2024/05/24
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGrid();
    }


    /// <summary>
    /// 刪除記錄
    /// 2024/05/24
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string emp_id =GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string query = "DELETE FROM emp WHERE EMP_ID=@EMP_ID";
        string constr = ConfigurationManager.ConnectionStrings["TESTDBConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        this.BindGrid();
    }
    /// <summary>
    /// 刪除記錄確認
    /// 2024/05/24
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
        {
            (e.Row.Cells[4].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('確定刪除這筆記錄嗎?');";
        }
    }


    /// <summary>
    /// 換頁更新
    /// 2024/05/24
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}