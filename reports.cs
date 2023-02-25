using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Management_System
{
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();
            Display();
        }

        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\UniversityDataBase.mdf;Integrated Security=True");
        int Key = 0;
        private void Display()
        {
            
        }
        private void Reset()
        {
           
        }
       

        private void Course_Lbl_Click(object sender, EventArgs e)
        {
            Courses Course = new Courses();
            this.Hide();
            Course.Show();
        }

        private void Fac_Lbl_Click(object sender, EventArgs e)
        {
            Faculty Fac = new Faculty();
            this.Hide();
            Fac.Show();
        }

        private void Dept_Lbl_Click(object sender, EventArgs e)
        {
            Department Dept = new Department();
            this.Hide();
            Dept.Show();
        }

        private void Student_Lbl_Click(object sender, EventArgs e)
        {
            Student Std = new Student();
            this.Hide();
            Std.Show();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LogOut_Lbl_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.Show();
        }

        private void Sal_Lbl_Click(object sender, EventArgs e)
        {
            Salaries Sal = new Salaries();
            this.Hide();
            Sal.Show();
        }

        private void FeeLbl_Click(object sender, EventArgs e)
        {
            Fees Fee = new Fees();
            this.Hide();
            Fee.Show();
        }

        private void Home_Lbl_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void StudentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable data = new DataTable();
                Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT dbo.StudentTbl.*, dbo.FeesTbl.Amount, dbo.FeesTbl.PayDate, dbo.CourseTbl.Course_Name FROM dbo.StudentTbl INNER JOIN dbo.FeesTbl ON dbo.StudentTbl.StId = dbo.FeesTbl.StId INNER JOIN dbo.DepartmentTbl ON dbo.StudentTbl.DeptId = dbo.DepartmentTbl.DeptId INNER JOIN dbo.CourseTbl ON dbo.DepartmentTbl.DeptId = dbo.CourseTbl.DeptId", Connection);
                adapter.Fill(data);
                rep_DGV.DataSource = data;
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void StaffBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable data = new DataTable();
                Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT dbo.FacultyTbl.*, dbo.SalaryTbl.Salary AS Expr1, dbo.SalaryTbl.PayDate FROM dbo.FacultyTbl INNER JOIN dbo.SalaryTbl ON dbo.FacultyTbl.F_Id = dbo.SalaryTbl.F_Id", Connection);
                adapter.Fill(data);
                rep_DGV.DataSource = data;
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
