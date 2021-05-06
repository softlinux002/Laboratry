using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;

namespace PunjabLab
{
    public partial class Form1 : Form
    {
        //SqlCeConnection con = new SqlCeConnection("Data Source=F:\\PunjabLab\\PunjabLab\\bin\\Debug\\punjablab.sdf;Persist Security Info=False");

        public static string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string datalogicFilePath = Path.Combine(StartupPath, "punjablab.sdf");
        public static string connectionString = string.Format("DataSource={0}", datalogicFilePath);
        SqlCeConnection con = new SqlCeConnection(connectionString);

        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(vScrollBar1);
        }

        public static string invoiceno;
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                 string ato120 = to120.Checked == true ? "T" : "F";
                 string ato140 = to140.Checked == true ? "T" : "F";
                 string ato180 = to180.Checked == true ? "T" : "F";
                 string ato1160 = to1180.Checked == true ? "T" : "F";
                 string ato1320 = to1320.Checked == true ? "T" : "F";
                 string ato1640 = to1640.Checked == true ? "T" : "F";
                 string ath120 = th120.Checked == true ? "T" : "F";
                 string ath140 = th140.Checked == true ? "T" : "F";
                 string ath180 = th180.Checked == true ? "T" : "F";
                 string ath1160 = th1180.Checked == true ? "T" : "F";
                 string ath1320 = th1320.Checked == true ? "T" : "F";
                 string ath1640 = th1640.Checked == true ? "T" : "F";
                 string aah120 = ah120.Checked == true ? "T" : "F";
                 string aah140 = ah140.Checked == true ? "T" : "F";
                 string aah180 = ah180.Checked == true ? "T" : "F";
                 string aah1160 = ah1180.Checked == true ? "T" : "F";
                 string aah1320 = ah1320.Checked == true ? "T" : "F";
                 string aah1640 = ah1640.Checked == true ? "T" : "F";
                 string abh120 = bh120.Checked == true ? "T" : "F";
                 string abh140 = bh140.Checked == true ? "T" : "F";
                 string abh180 = bh180.Checked == true ? "T" : "F";
                 string abh1160 = bh1180.Checked == true ? "T" : "F";
                 string abh1320 = bh1320.Checked == true ? "T" : "F";
                string abh1840 = bh1640.Checked == true ? "T" : "F";
                string query = @"insert into report (Name,age,sex,rpt_date,refferby,hb,tlc,polymorph,lymphocyte,eosinophil,monocyte,basophil,mp,esr,bt,ct,abs_eosinophil,platelet,HBs_Ag,rafactor,vdrltest,toxoplasma_igm,hiv,hcv,ns_i,igm,igg,blod_group_rh,pregnancy_test,BloodSugarFasting,BloodSugarR,BloodSugarPP,BloodUrea,SerumCreatinine,UricAcid,BloodCholesterol,HDLCholesterol,Triglycerides,SerumBilirubin,Direct,InDirect,SGPT,SGOT,SerumAlkalinePhosphatase,Protein,Albumin,Globulin,BileSalt,BilePigment,UrineSugar,Albumins,PusCells,UricAcids,EpithelialCell,Oxalate,to120,to140,to180,to1160,to1320,to1640,th120,th140,th180,th1160,th1320,th1640,ah120,ah140,ah180,ah1160,ah1320,ah1640,bh120,bh140,bh180,bh1160,bh1320,bh1840,LDL,VLDL,RBC) 
          values('" + name_txt.Text + "','" + age_txt.Text + "','" + this.gender_combo.GetItemText(this.gender_combo.SelectedItem) + "','" + dateReport.Value + "','" + dr_txt.Text + "','" + hemo_txt.Text + "','" + tlc_txt.Text + "','" + polymorph_txt.Text + "','" + lympho_txt.Text + "','" + eosino_txt.Text + "','" + mono_txt.Text + "','" + baso_txt.Text + "','" + this.mp_combo.GetItemText(this.mp_combo.SelectedItem) + "','"+esr_txt.Text+"','"+ bt_txt.Text+"','"+ ct_txt.Text+ "','" + abs_txt.Text + "', '" + platelet_txt.Text + "','"+this.hbs_combo.GetItemText(this.hbs_combo.SelectedItem) + "','"+this.ra_combo.GetItemText(this.ra_combo.SelectedItem) + "','"+ this.vdrl_txt.GetItemText(this.vdrl_txt.SelectedItem) + "','"+ this.toxo_combo.GetItemText(this.toxo_combo.SelectedItem) + "','"+ this.hiv_combo.GetItemText(this.hiv_combo.SelectedItem) + "','"+ this.hcv_combo.GetItemText(this.hcv_combo.SelectedItem) + "','"+ this.NS_combo.GetItemText(this.NS_combo.SelectedItem) + "','"+ this.igm_combo.GetItemText(this.igm_combo.SelectedItem) + "','"+ this.igg_combo.GetItemText(this.igg_combo.SelectedItem) + "','"+ rhtype_text.Text + "','"+ pregency_txt.Text + "','"+ sugarfasting_txt.Text + "','"+ txt_BloodSugarR.Text + "','"+ txt_BloodSugarPP.Text + "','"+ txt_BloodUrea.Text + "','"+ txt_SerumCreatinine.Text + "','"+ txt_SrUricAcid.Text + "','"+ txt_BloodCholesterol.Text + "','"+ txt_HdlCholesterol.Text + "','"+ txtTriglycerides.Text + "','"+ txt_serumbilirubin.Text + "','"+ txt_direct.Text + "','"+ txt_indirect.Text + "','"+ txt_sgpt.Text + "','"+ txt_sgot.Text + "','"+ txt_serumalkaline.Text + "','"+ txt_srprotein.Text + "','"+ txt_albumin.Text + "','"+ txt_globulin.Text + "','"+ txt_bilesalt.Text + "','"+ txt_bilepigment.Text + "','"+ txt_urinesugar.Text + "','"+ txt_albumins.Text + "','"+ txt_puscells.Text + "','"+ txt_uricacid.Text + "','"+ txt_epithelialcell.Text + "','"+ txt_caloxalate.Text + "','"+ ato120+"','"+ ato140 + "','"+ ato180 + "','"+ ato1160 + "','"+ ato1320 + "','"+ ato1640 + "','"+ ath120 + "','"+ ath140 + "','"+ ath180 + "','"+ ath1160 + "', '"+ ath1320 + "','"+ ath1640 + "','"+ aah120 + "','"+ aah140 + "','"+ aah180 + "','"+ aah1160 + "','"+ aah1320 + "','"+ aah1640 + "','"+ abh120 + "','"+ abh140 + "','"+ abh180 + "','"+ abh1160 + "','"+ abh1320 + "','"+ abh1840 + "','"+ txt_ldl.Text + "','"+ txt_vldl.Text + "','"+txt_rbc.Text+"')";
                con.Open();
                SqlCeCommand cmd = new SqlCeCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //using (Entities1 context = new Entities1())
                //{
                //    //context.Database.Initialize(true);
                //    report rep = new report();
                //    rep.Name = name_txt.Text;
                //    rep.age = age_txt.Text;
                //    rep.sex = this.gender_combo.GetItemText(this.gender_combo.SelectedItem);
                //    rep.rpt_date = dateReport.Value;
                //    rep.refferby = dr_txt.Text;
                //    rep.hb = hemo_txt.Text;
                //    rep.tlc = tlc_txt.Text;
                //    rep.polymorph = polymorph_txt.Text;
                //    rep.lymphocyte = lympho_txt.Text;
                //    rep.eosinophil = eosino_txt.Text;
                //    rep.monocyte = mono_txt.Text;
                //    rep.basophil = baso_txt.Text;
                //    rep.mp = this.mp_combo.GetItemText(this.mp_combo.SelectedItem);
                //    rep.esr = esr_txt.Text;
                //    rep.bt = bt_txt.Text;
                //    rep.ct = ct_txt.Text;
                //    rep.abs_eosinophil = abs_txt.Text;
                //    rep.platelet = platelet_txt.Text;
                //    rep.HBs_Ag = this.hbs_combo.GetItemText(this.hbs_combo.SelectedItem);
                //    rep.rafactor = this.ra_combo.GetItemText(this.ra_combo.SelectedItem);
                //    rep.vdrltest = this.vdrl_txt.GetItemText(this.vdrl_txt.SelectedItem);
                //    rep.toxoplasma_igm = this.toxo_combo.GetItemText(this.toxo_combo.SelectedItem);
                //    rep.hiv = this.hiv_combo.GetItemText(this.hiv_combo.SelectedItem);
                //    rep.hcv =  this.hcv_combo.GetItemText(this.hcv_combo.SelectedItem);
                //    rep.ns_i = this.NS_combo.GetItemText(this.NS_combo.SelectedItem);
                //    rep.igm = this.igm_combo.GetItemText(this.igm_combo.SelectedItem);
                //    rep.igg = this.igg_combo.GetItemText(this.igg_combo.SelectedItem);
                //    rep.blod_group_rh = rhtype_text.Text;
                //    rep.pregnancy_test = pregency_txt.Text;
                //    rep.BloodSugarFasting = sugarfasting_txt.Text;
                //    rep.BloodSugarR = txt_BloodSugarR.Text;
                //    rep.BloodSugarPP = txt_BloodSugarPP.Text;
                //    rep.BloodUrea = txt_BloodUrea.Text;
                //    rep.SerumCreatinine = txt_SerumCreatinine.Text;
                //    rep.UricAcid = txt_SrUricAcid.Text;
                //    rep.BloodCholesterol = txt_BloodCholesterol.Text;
                //    rep.HDLCholesterol = txt_HdlCholesterol.Text;
                //    rep.Triglycerides = txtTriglycerides.Text;
                //    rep.L_D_L = txt_ldl.Text;
                //    rep.V_L_D_L = txt_vldl.Text;
                //    rep.SerumBilirubin = txt_serumbilirubin.Text;
                //    rep.Direct = txt_direct.Text;
                //    rep.InDirect = txt_indirect.Text;
                //    rep.SGPT = txt_sgpt.Text;
                //    rep.SGOT = txt_sgot.Text;
                //    rep.SerumAlkalinePhosphatase = txt_serumalkaline.Text;
                //    rep.Protein = txt_srprotein.Text;
                //    rep.Albumin = txt_albumin.Text;
                //    rep.Globulin = txt_globulin.Text;
                //    rep.BileSalt = txt_bilesalt.Text;
                //    rep.BilePigment = txt_bilepigment.Text;
                //    rep.UrineSugar = txt_urinesugar.Text;
                //    rep.Albumins = txt_albumins.Text;
                //    rep.PusCells = txt_puscells.Text;
                //    rep.R_B_C = txt_rbc.Text;
                //    rep.UricAcid = txt_uricacid.Text;
                //    rep.EpithelialCell = txt_epithelialcell.Text;
                //    rep.Oxalate = txt_caloxalate.Text;
                //    rep.to120 = to120.Checked == true ? "T" : "F";
                //    rep.to140 = to140.Checked == true ? "T" : "F";
                //    rep.to180 = to180.Checked == true ? "T" : "F";
                //    rep.to1160 = to1180.Checked == true ? "T" : "F";
                //    rep.to1320 = to1320.Checked == true ? "T" : "F";
                //    rep.to1640 = to1640.Checked == true ? "T" : "F";
                //    rep.th120 = th120.Checked == true ? "T" : "F";
                //    rep.th140 = th140.Checked == true ? "T" : "F";
                //    rep.th180 = th180.Checked == true ? "T" : "F";
                //    rep.th1160 = th1180.Checked == true ? "T" : "F";
                //    rep.th1320 = th1320.Checked == true ? "T" : "F";
                //    rep.th1640 = th1640.Checked == true ? "T" : "F";
                //    rep.ah120 = ah120.Checked == true ? "T" : "F";
                //    rep.ah140 = ah140.Checked == true ? "T" : "F";
                //    rep.ah180 = ah180.Checked == true ? "T" : "F";
                //    rep.ah1160 = ah1180.Checked == true ? "T" : "F";
                //    rep.ah1320 = ah1320.Checked == true ? "T" : "F";
                //    rep.ah1640 = ah1640.Checked == true ? "T" : "F";
                //    rep.bh120 = bh120.Checked == true ? "T" : "F";
                //    rep.bh140 = bh140.Checked == true ? "T" : "F";
                //    rep.bh180 = bh180.Checked == true ? "T" : "F";
                //    rep.bh1160 = bh1180.Checked == true ? "T" : "F";
                //    rep.bh1320 = bh1320.Checked == true ? "T" : "F";
                //    rep.bh1840 = bh1640.Checked == true ? "T" : "F";

                //    context.reports.Add(rep);
                //    context.SaveChanges();
                Form3 frm = new Form3();
                //this.Hide();
                //frm.lbl_hemo.Text = hemo_txt.Text.ToString();
                //frm.label2.Text = tlc_txt.Text.ToString();
                //frm.label3.Text = polymorph_txt.Text.ToString();
                //frm.label4.Text = lympho_txt.Text.ToString();
                frm.Show();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
