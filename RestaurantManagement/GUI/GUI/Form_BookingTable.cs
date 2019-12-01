using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BLL;
namespace GUI
{
    public partial class Form_BookingTable : Form
    {
        int TabID;
        CustomerBLL customerBLL;
        BookingTableBLL bookingTableBLL;
        TableBLL tableBLL;
        Form_Restaurant mainform;
        public Form_BookingTable(Form_Restaurant form, int TableID)
        {
            mainform = form;
            TabID = TableID;
            tableBLL = new TableBLL();
            bookingTableBLL = new BookingTableBLL();
            customerBLL = new CustomerBLL();
            InitializeComponent();
            lbTableID.Text = Convert.ToString(TabID);
        }

        private void img_Min_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void img_Max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void img_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void chbMember_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked == true)
            {
                // Đã đến trước đó rồi => Đã có trong cơ sở dữ liệu
                lbGender.Enabled = false;
                lbPhone.Enabled = false;
                lbCMND.Enabled = false;
                cbGender.Enabled = false;
                txtPhone.Enabled = false;
                txtCMND.Enabled = false;
                // Search CustomerID bằng CustomerName 
                // Auto-complete, hiện ra các suggestion tên của người dùng
                // Những lúc giá trị tên trùng nhau => Sẽ hiển thị hết các giá trị trùng đó
                
                // Tự động điền các thông tin ở bên dưới bằng thông tin đã có bao gồm Gender,Phone,CMND
                Customer customer = customerBLL.SearchCustomerByName(txtName.Text);
                if (customer != null)
                {
                    if (customer.IsFemale == true)
                        cbGender.SelectedIndex = 0;
                    else
                        cbGender.SelectedIndex = 1;
                    txtPhone.Text = customer.PhoneNumber;
                    txtCMND.Text = customer.CMND;
                }
                else
                    MessageBox.Show("Không tồn tại khách hàng này");
            }
            else
            {
                lbGender.Enabled = true;
                lbPhone.Enabled = true;
                lbCMND.Enabled = true;
                cbGender.Enabled = true;
                txtPhone.Enabled = true;
                txtCMND.Enabled = true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            var source = new AutoCompleteStringCollection();

            List<string> lsCustomer = customerBLL.Name_SearchCustomerByName(txtName.Text);

            if (lsCustomer != null)
            {
                //foreach (var item in lsCustomer)
                //{
                //    lsName_Customer.Add(item.Name);
                //}
                foreach (var item in lsCustomer)
                {
                    source.Add(item);
                }
                txtName.AutoCompleteCustomSource = source;
                txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {

            if (chbMember.Checked == true)
            {
                // Đã đến trước đó rồi => Đã có trong cơ sở dữ liệu
                if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(dtpTime.Text))
                {
                    MessageBox.Show("Please insert fully information");
                }
                else
                {
                    // Add Booking Tables
                    // Sau khi Add xong thì getCustomerID
                    Customer customer = customerBLL.SearchCustomerByName(txtName.Text);
                    int CustomerID = customerBLL.GetCustomerID(customer);
                    // Tính ExpireTime
                    DateTime ExpireTime = dtpTime.Value.AddHours(1);
                    // Tạo BookingTable
                    BookingTable bookingTable = new BookingTable();
                    bookingTable.BookingDate = dtpTime.Value;
                    bookingTable.CustomerID = CustomerID;
                    bookingTable.ExpiredTime = ExpireTime;
                    bookingTable.TableID = TabID;

                    // Add xuống DB
                    if (bookingTableBLL.AddBookingTable(bookingTable) == true)
                    {
                        if (tableBLL.ChangeTableStatus(TabID, false, false, true) == true)
                        {
                            MessageBox.Show("Booking thành công");
                            this.Hide();
                        }
                    }
                    else
                        MessageBox.Show("Không thành công. Vui lòng thử lại");
                }
            }
            else
            {
                // Chưa đến lần nào => Phải tạo Customer mới
                if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtPhone.Text)
                || String.IsNullOrEmpty(dtpTime.Text) || String.IsNullOrEmpty(txtCMND.Text)
                || String.IsNullOrEmpty(cbGender.Text))
                {
                    MessageBox.Show("Please insert fully information");
                }
                else
                {
                    // Add new Customer
                    Customer customer = new Customer();
                    customer.Name = txtName.Text;
                    customer.PhoneNumber = txtPhone.Text;
                    customer.IsFemale = (cbGender.Text == "Female") ? true : false;
                    customer.CMND = txtCMND.Text;

                    // Dùng hàm Add
                    if (customerBLL.AddCustomer(customer) == true)
                    {
                        // Sau khi Add xong thì getCustomerID
                        int CustomerID = customerBLL.GetCustomerID(customer);
                        // Tính ExpireTime
                        DateTime ExpireTime = dtpTime.Value.AddHours(1);
                        // Tạo BookingTable
                        BookingTable bookingTable = new BookingTable();
                        bookingTable.BookingDate = dtpTime.Value;
                        bookingTable.CustomerID = CustomerID;
                        bookingTable.ExpiredTime = ExpireTime;
                        bookingTable.TableID = TabID;

                        // Add xuống DB
                        if (bookingTableBLL.AddBookingTable(bookingTable) == true)
                        {
                            if (tableBLL.ChangeTableStatus(TabID, false, false, true) == true)
                            {
                                MessageBox.Show("Booking thành công");
                                this.Hide();
                            }
                        }
                        else
                            MessageBox.Show("Không thành công. Vui lòng thử lại");

                    }

                }
            }

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel Notification", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
    }
}
