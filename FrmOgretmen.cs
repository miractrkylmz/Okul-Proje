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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup frmKulup = new FrmKulup();
            frmKulup.Show();
        }

        private void btnDers_Click(object sender, EventArgs e)
        {
            frmDersler frm = new frmDersler();
            frm.Show();
        }

        private void btnOgrenciIslem_Click(object sender, EventArgs e)
        {
            FrmOgrenci fr = new FrmOgrenci();
            fr.Show();
        }

        private void FrmOgretmen_Load(object sender, EventArgs e)
        {

        }

        private void SinavNotlar_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar frm = new FrmSınavNotlar();
            frm.Show();
        }
    }
}
