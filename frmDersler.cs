using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje
{
    public partial class frmDersler : Form
    {
        public frmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.tbl_DerslerTableAdapter();
        private void frmDersler_Load(object sender, EventArgs e)
        {
            DataSet1TableAdapters.tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.tbl_DerslerTableAdapter();
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtDersAdı.Text);
            MessageBox.Show("Ders Eklendi");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtDersID.Text));
            MessageBox.Show("Ders Silindi!");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGüncelle(txtDersAdı.Text,byte.Parse(txtDersID.Text));
            MessageBox.Show("Ders Güncellendi!");
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDersID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDersAdı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
