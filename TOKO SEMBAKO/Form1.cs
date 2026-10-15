using System;
using System.Windows.Forms;

namespace TOKO_SEMBAKO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Fungsi ini otomatis jalan saat tombol LOGIN diklik
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nama = textName.Text.Trim();
            string password = textPassword.Text.Trim();

            // Cek Username & Password Admin
            if (nama == "admin" && password == "123")
            {
                MessageBox.Show("Login Berhasil! Selamat Datang Admin.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- KODE UNTUK MEMBUKA FORM 2 ---
                Form2 formProduk = new Form2();
                formProduk.Show(); // Tampilkan Halaman Produk
                this.Hide();       // Sembunyikan Form Login (Form1)
            }
            else
            {
                MessageBox.Show("Nama atau Password salah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPassword.Clear();
                textName.Focus();
            }
        }
    }
}

