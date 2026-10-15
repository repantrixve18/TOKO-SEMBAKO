using System;
using System.Data;
using System.Windows.Forms;

namespace TOKO_SEMBAKO
{
    public partial class Form2 : Form
    {
        DataTable tabelProduk = new DataTable();

        public Form2()
        {
            InitializeComponent();

            
            btnTambah.Click -= btnTambah_Click;
            btnTambah.Click += btnTambah_Click;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SetupTabel();
        }

        private void SetupTabel()
        {
            
            if (tabelProduk.Columns.Count < 4)
            {
                tabelProduk.Columns.Clear();
                tabelProduk.Columns.Add("ID Produk");
                tabelProduk.Columns.Add("Nama Produk");
                tabelProduk.Columns.Add("Harga (Rp)");
                tabelProduk.Columns.Add("Stok");

               
                if (tabelProduk.Rows.Count == 0)
                {
                    tabelProduk.Rows.Add("P001", "Beras Premium 5kg", "65000", "20");
                    tabelProduk.Rows.Add("P002", "Minyak Goreng 2L", "35000", "15");
                }
            }

           
            dgvProduk.DataSource = tabelProduk;
        }

    
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtNamaProduk.Text) ||
                string.IsNullOrWhiteSpace(txtHarga.Text) ||
                string.IsNullOrWhiteSpace(txtStok.Text))
            {
                MessageBox.Show("Isi semua data terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            SetupTabel();

            
            tabelProduk.Rows.Add(txtID.Text.Trim(), txtNamaProduk.Text.Trim(), txtHarga.Text.Trim(), txtStok.Text.Trim());

            MessageBox.Show("Produk Berhasil Ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInput();
        }

        
        private void dgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < tabelProduk.Rows.Count)
            {
                DataGridViewRow row = dgvProduk.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtNamaProduk.Text = row.Cells[1].Value.ToString();
                txtHarga.Text = row.Cells[2].Value.ToString();
                txtStok.Text = row.Cells[3].Value.ToString();
            }
        }

        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProduk.CurrentRow != null && dgvProduk.CurrentRow.Index >= 0)
            {
                int index = dgvProduk.CurrentRow.Index;
                if (index < tabelProduk.Rows.Count)
                {
                    tabelProduk.Rows[index]["ID Produk"] = txtID.Text.Trim();
                    tabelProduk.Rows[index]["Nama Produk"] = txtNamaProduk.Text.Trim();
                    tabelProduk.Rows[index]["Harga (Rp)"] = txtHarga.Text.Trim();
                    tabelProduk.Rows[index]["Stok"] = txtStok.Text.Trim();

                    MessageBox.Show("Data Produk Berhasil Diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                }
            }
        }

        // --- TOMBOL HAPUS ---
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvProduk.CurrentRow != null && dgvProduk.CurrentRow.Index >= 0)
            {
                int index = dgvProduk.CurrentRow.Index;
                if (index < tabelProduk.Rows.Count)
                {
                    tabelProduk.Rows[index].Delete();
                    MessageBox.Show("Produk Berhasil Dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                }
            }
        }

        // --- TOMBOL CLEAR ---
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void ClearInput()
        {
            txtID.Clear();
            txtNamaProduk.Clear();
            txtHarga.Clear();
            txtStok.Clear();
            txtID.Focus();
        }

        
        private void dgvProduk_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void Form2_Load_2(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { btnTambah_Click(sender, e); }
        private void button2_Click(object sender, EventArgs e) { btnUpdate_Click(sender, e); }
        private void button3_Click(object sender, EventArgs e) { btnHapus_Click(sender, e); }
        private void button4_Click(object sender, EventArgs e) { btnClear_Click(sender, e); }
    }
}