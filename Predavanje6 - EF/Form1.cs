using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Predavanje6___EF
{
    public partial class Form1 : Form
    {
        //upute za spajanje na bazu https://betterprogramming.pub/beginners-guide-to-entity-framework-d862c9aaec4


        // Kreiraj poveznicu na bazu
        DOTNPredavanje6Entities baza = new DOTNPredavanje6Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Spoji se na bazu i pročitaj objekte država
            cb_drzava.DataSource = baza.Drzave.ToList<Drzave>();
            cb_drzava.ValueMember = "Id";
            cb_drzava.DisplayMember = "Naziv"; // Prikaži u Combu
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Spremamo ono što je uneseno
            Slucajevi slucaj = new Slucajevi();
            slucaj.BrojZarazenih = Int32.Parse(tb_zarazeni.Text);
            slucaj.BrojUmrlih = Int32.Parse(tb_umrli.Text);
            slucaj.BrojIzlijecenih = Int32.Parse(tb_ozdravljeni.Text);
            // Pročitaj mi iz Comba Državu
            slucaj.Drzave = (Drzave)cb_drzava.SelectedItem;
            // sada idemo spremiti u bazu
            baza.Slucajevi.Add(slucaj);
            // Ajde sada spremi u bazu
            baza.SaveChanges();
            // Ajde sad prikaži listu svih slučajeva u Gridu
            gv_slucajevi.DataSource = baza.Slucajevi.ToList<Slucajevi>();
        }
    }
}
