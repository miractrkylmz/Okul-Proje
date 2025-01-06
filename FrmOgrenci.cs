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

namespace BonusProje
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-U2CN370;Initial Catalog=BonusOkul;Integrated Security=True");

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListe();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_kulupler",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbKulup.DisplayMember = "KulupAD";
            cmbKulup.ValueMember = "KulupID";
            cmbKulup.DataSource = dt;
            baglanti.Close();

        }
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked==true)
            {
                c = "Kız";
            }
            if(radioButton2.Checked==true)
            {
                c = "Erkek";
            }
            ds.OgrenciEkle(txtAD.Text,txtSoyad.Text,byte.Parse(cmbKulup.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci Ekleme Yapıldı!");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListe();
        }

        private void cmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = cmbKulup.SelectedValue.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtID.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAD.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Kız")
            {
                radioButton1.Checked = true;
                c = "Kız";
            }else { radioButton2.Checked = true; c = "Erkek"; }
            cmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGüncelle(txtAD.Text,txtSoyad.Text,byte.Parse(cmbKulup.SelectedValue.ToString()),c,int.Parse(txtID.Text));
            MessageBox.Show("Öğrenci Güncellendi!");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                c = "Kız";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                c = "Erkek";
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(txtAra.Text);
        }
    }
}
