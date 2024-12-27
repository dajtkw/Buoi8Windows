using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SVBUS svbus;
        internal  Form1()
        {
            InitializeComponent();
            svbus = new SVBUS();
            LoadClass();
            LoadData();
        }

        private void LoadClass()
        {
            var classList = svbus.GetAllClasses();
            cmbClass.DataSource = classList;
            cmbClass.DisplayMember = "TenLop";
            cmbClass.ValueMember = "MaLop";

        }

        private void LoadData()
        {
            var studentList = svbus.GetALLStudent();
            dgvStudentList.AutoGenerateColumns = false;
            dgvStudentList.Columns.Clear();

            dgvStudentList.Columns.Add("MaSV", "Mã SV");
            dgvStudentList.Columns.Add("HotenSV", "Họ và Tên");
            dgvStudentList.Columns.Add("NgaySinh", "Ngày Sinh");
            dgvStudentList.Columns.Add("TenLop", "Lớp");
            
            dgvStudentList.Columns["MaSV"].DataPropertyName = "MaSV";
            dgvStudentList.Columns["HotenSV"].DataPropertyName = "HotenSV";
            dgvStudentList.Columns["NgaySinh"].DataPropertyName = "NgaySinh";
            dgvStudentList.Columns["TenLop"].DataPropertyName = "TenLop";
 
            dgvStudentList.Columns["HotenSV"].Width = 150;
            dgvStudentList.Columns["TenLop"].Width = 150;
            dgvStudentList.Columns["NgaySinh"].Width = 150;

            dgvStudentList.DataSource = studentList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newStudent = new Sinhvien
                {
                    MaSV = txtStudentID.Text,
                    HotenSV = txtStudentID.Text,
                    NgaySinh = dtpkDateofBirth.Value,
                    MaLop = cmbClass.SelectedValue.ToString(),
                };
                svbus.AddSinhVien(newStudent);
                LoadData();
                MessageBox.Show("Thêm sinh viên thành công");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStudentList.SelectedRows.Count > 0)
                {
                    var selectedStudent = (Sinhvien)dgvStudentList.SelectedRows[0].DataBoundItem;
                    selectedStudent.HotenSV = txtName.Text;
                    selectedStudent.NgaySinh = dtpkDateofBirth.Value;
                    selectedStudent.MaLop = cmbClass.SelectedValue.ToString();

                    svbus.UpdateSinhVien(selectedStudent);
                    LoadData();
                    MessageBox.Show("Cập nhập sinh viên thành công");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStudentList.SelectedRows.Count > 0)
                {
                    var studentDelete = (Sinhvien)dgvStudentList.SelectedRows[0].DataBoundItem;
                    svbus.DeleteSinhVien(studentDelete);
                    LoadData();
                    MessageBox.Show("Xóa sinh viên thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvStudentList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudentList.SelectedRows.Count > 0)
            {
                var selectedStudent = (Sinhvien)dgvStudentList.SelectedRows[0].DataBoundItem;
                txtStudentID.Text = selectedStudent.MaSV;
                txtName.Text = selectedStudent.HotenSV;
                dtpkDateofBirth.Value = selectedStudent.NgaySinh ?? DateTime.Now;
                cmbClass.SelectedValue = selectedStudent.MaLop;
            }
        }

        private void btnFindByName_Click(object sender, EventArgs e)
        {
            string findName = txtFindByName.Text;
            dgvStudentList.DataSource = svbus.FindByName(findName);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
