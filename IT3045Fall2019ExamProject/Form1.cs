/**********************************************************
 * Cat form class
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 * ********************************************************/
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

namespace SQL {
    public partial class frmCats : Form {
        public frmCats() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
        /// <summary>
        /// Eventg Handle for Check Connection button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckConnection_Click(object sender, EventArgs e) {
            if (Utils.CheckConnection()) {
                MessageBox.Show("Connection succeeded");
            } else {
                MessageBox.Show("Connection failed");
            }
        }
        /// <summary>
        /// Read records from tCat and add to a list box
        /// modify to refuse to add records if there are already records in the LB
        /// </summary>
        private void readRecords() {
            if (lbCats.Items.Count == 0) {
                SqlDataReader dr = null;
                try {
                    SqlCommand cmd = new SqlCommand("SELECT * from tCat order by Cat", Config.myConnection);

                    // create data adapter
                    dr = cmd.ExecuteReader();   // Could fail in so many ways...

                    while (dr.Read()) {      // Advance to first record in the cursor
                        // Read all the records and populate the list box
                        lbCats.Items.Add(dr.GetString(1));      // The second column in the cursor
                    }
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    // If we can't close the data reader, just eat the exception
                    // code...

                    try { dr.Close(); } catch (Exception ex) { }
                }
            }
        }
        /// <summary>
        /// Event handler for Read Cats button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadCats_Click(object sender, EventArgs e) {
            readRecords();
        }
        /// <summary>
        /// Event handler for Add Cat button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCat_Click(object sender, EventArgs e) {
            // Add the cat name in txtCat to the tCat table
            // Default the CatBreedID to 12
            Utils.ExecuteNonQuery(
                "INSERT INTO tCat(Cat, CatBreedID) VALUES ('"+ txtCat.Text.Trim() + "', 12) ", 
                CommandType.Text, 
                null);
        }
        /// <summary>
        /// Event handler for Cat Scroll Bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCat_Scroll(object sender, EventArgs e) {
            int value = tbCat.Value;    // current position of the scroll bar
            float idx = value / lbCats.Items.Count;
        }
        /// <summary>
        /// Event handler for the lookup button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) {
            String catBreedID = Convert.ToString(Utils.MyDLookup("CatBreedID", "tCat", "Cat = " + "'" + lbCats.SelectedItem.ToString().Trim() + "'",""));
            String  catBreed = (String)Utils.MyDLookup("CatBreed", "tCatBreed", "CatBreedID = " + Convert.ToInt32(catBreedID), "");
            txtBreedID.Text = catBreedID + " : " + catBreed;
        }
    }
}
