﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit_Proje
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-S155I3V\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            //toplam personel sayısı
            
            
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from Tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplamPersonel.Text= dr1[0].ToString();
            }

            baglanti.Close();

            //evli personel sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvli.Text= dr2[0].ToString();
            }

            baglanti.Close();
            // bekar personel sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3= komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekar.Text = dr3[0].ToString();
            }

            baglanti.Close();

            //şehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count( distinct(PerSehir)) from Tbl_Personel", baglanti);
            SqlDataReader dr4= komut4.ExecuteReader();
            while (dr4.Read())
            {
                Lblsehir.Text= dr4[0].ToString();
            }

            baglanti.Close();

            //toplam maas
            baglanti.Open ();
            SqlCommand komut5 = new SqlCommand("select sum(permaas) from tbl_personel",baglanti);
            SqlDataReader dr5=komut5.ExecuteReader();
            while (dr5.Read())
            {
                LbltoplamMaas.Text  = dr5[0].ToString();    
            }

            baglanti.Close ();

            //ortalama
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(permaas) from Tbl_personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblortalamaMaas.Text = dr6[0].ToString();
            }



            baglanti.Close();
        }
    }
}