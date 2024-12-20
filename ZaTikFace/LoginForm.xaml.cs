using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ZaTikFace
{

    public partial class LoginForm : Window
    {
        public static SqlConnection connection;
        public LoginForm()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }

        private void txtSdt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtSDT.Focus();
        }

        private void txtSDT_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Kiểm tra nếu TextBox có dữ liệu thì ẩn TextBlock
            txbSdt.Visibility = string.IsNullOrEmpty(txtSDT.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void txbPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPass.Focus();
        }

        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txbPass.Visibility = string.IsNullOrEmpty(txtPass.Password) ? Visibility.Visible : Visibility.Hidden;
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            if (txtSDT.Text == "" || txtPass.Password == "")
            {

                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu", "Thông báo", MessageBoxButton.OK);
                return;
            }
            if (MainClass.DangNhap(txtSDT.Text, txtPass.Password.ToString()))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButton.OK);
                TrangChu trangChu = new TrangChu();
                this.Hide();
                trangChu.ShowDialog();

            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButton.OK);
                txtSDT.Focus();
            }
        }
    }
}
