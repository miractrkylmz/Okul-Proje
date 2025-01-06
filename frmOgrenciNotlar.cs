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
    public partial class frmOgrenciNotlar : Form
    {
        public frmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-U2CN370;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
        private void frmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("select DersAD,Sınav1,Sınav2,Sınav3,Proje,Ortalama,Durum from tbl_Notlar inner join tbl_Dersler on tbl_Notlar.dersID=tbl_Dersler.DersID where OgrID =@p1", baglanti);
            komut.Parameters.AddWithValue("@p1",numara);
            //this.Text = numara.ToString();
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from tbl_Ogrenciler where ogrID=@p1",baglanti);
            komut2.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[0].ToString();
            }
            baglanti.Close();
        }
    }
}
