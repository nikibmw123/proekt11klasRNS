using Project12.Controllers;
using Project12.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project12
{
    public partial class Form1 : Form
    {
        VeganContoller veganController = new VeganContoller();
        VeganTypeController veganTypeController = new VeganTypeController();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllVegans();
            LoadAllVeganTypes();
        }

        // Vegan CRUD Operations
        private void btnCreateVegan_Click(object sender, EventArgs e)
        {
                var vegan = new Vegan
                {
                    // ID is auto-increment, so we don't set it
                    Name = txbVeganName.Text,
                    Description = txbVeganDescription.Text,
                    Price = decimal.Parse(txbVeganPrice.Text),
                    VeganTypeId = int.Parse(txbVeganTypeId.Text)
                };

                veganController.Create(vegan);
                MessageBox.Show("Vegan created successfully!");
                ClearVeganFields();
                LoadAllVegans();
          
        }

        private void btnUpdateVegan_Click(object sender, EventArgs e)
        {
           
                if (string.IsNullOrEmpty(txbVeganId.Text))
                {
                    MessageBox.Show("Please enter a Vegan ID to update.");
                    return;
                }

                int id = int.Parse(txbVeganId.Text);
                var vegan = new Vegan
                {
                    Id = id,
                    Name = txbVeganName.Text,
                    Description = txbVeganDescription.Text,
                    Price = decimal.Parse(txbVeganPrice.Text),
                    VeganTypeId = int.Parse(txbVeganTypeId.Text)
                };

                veganController.Update(id, vegan);
                MessageBox.Show("Vegan updated successfully!");
                ClearVeganFields();
                LoadAllVegans();
           
        }

        private void btnDeleteVegan_Click(object sender, EventArgs e)
        {
           
                if (string.IsNullOrEmpty(txbVeganId.Text))
                {
                    MessageBox.Show("Please enter a Vegan ID to delete.");
                    return;
                }

                int id = int.Parse(txbVeganId.Text);
                var result = MessageBox.Show("Are you sure you want to delete this vegan?", "Confirm Delete", MessageBoxButtons.YesNo);
                
                if (result == DialogResult.Yes)
                {
                    veganController.Delete(id);
                    MessageBox.Show("Vegan deleted successfully!");
                    ClearVeganFields();
                    LoadAllVegans();
                }
            
        }

        // VeganType CRUD Operations
        private void btnCreateVeganType_Click(object sender, EventArgs e)
        {
           
                var veganType = new VeganType
                {
                    // ID is auto-increment, so we don't set it
                    Name = txbVeganTypeName.Text
                };

                veganTypeController.Create(veganType);
                MessageBox.Show("Vegan Type created successfully!");
                ClearVeganTypeFields();
                LoadAllVeganTypes();
            
        }

        private void btnUpdateVeganType_Click(object sender, EventArgs e)
        {
           
                if (string.IsNullOrEmpty(txbVeganTypeIdType.Text))
                {
                    MessageBox.Show("Please enter a Vegan Type ID to update.");
                    return;
                }

                int id = int.Parse(txbVeganTypeIdType.Text);
                var veganType = new VeganType
                {
                    Id = id,
                    Name = txbVeganTypeName.Text
                };

                veganTypeController.Update(id, veganType);
                MessageBox.Show("Vegan Type updated successfully!");
                ClearVeganTypeFields();
                LoadAllVeganTypes();
            
        }

        private void btnDeleteVeganType_Click(object sender, EventArgs e)
        {
           
                if (string.IsNullOrEmpty(txbVeganTypeIdType.Text))
                {
                    MessageBox.Show("Please enter a Vegan Type ID to delete.");
                    return;
                }

                int id = int.Parse(txbVeganTypeIdType.Text);
                var result = MessageBox.Show("Are you sure you want to delete this vegan type?", "Confirm Delete", MessageBoxButtons.YesNo);
                
                if (result == DialogResult.Yes)
                {
                    veganTypeController.Delete(id);
                    MessageBox.Show("Vegan Type deleted successfully!");
                    ClearVeganTypeFields();
                    LoadAllVeganTypes();
                }
        }

        // Helper methods
        private void LoadAllVegans()
        {
            
                var vegans = veganController.GetAll();
                listBoxVegans.DataSource = null;
                listBoxVegans.DataSource = vegans.Select(v => new { 
                    FullInfo = $"ID: {v.Id} - {v.Name} - {v.Price:F2} лв - Type: {v.VeganTypeId}",
                    Vegan = v 
                }).ToList();
                listBoxVegans.DisplayMember = "FullInfo";
                listBoxVegans.ValueMember = "Vegan";
        }

        private void LoadAllVeganTypes()
        {
           
                var veganTypes = veganTypeController.GetAll();
                listBoxVeganTypes.DataSource = null;
                listBoxVeganTypes.DataSource = veganTypes.Select(vt => new { 
                    FullInfo = $"ID: {vt.Id} - {vt.Name}",
                    VeganType = vt 
                }).ToList();
                listBoxVeganTypes.DisplayMember = "FullInfo";
                listBoxVeganTypes.ValueMember = "VeganType";
        }

        private void ClearVeganFields()
        {
            txbVeganId.Clear();
            txbVeganName.Clear();
            txbVeganDescription.Clear();
            txbVeganPrice.Clear();
            txbVeganTypeId.Clear();
        }

        private void ClearVeganTypeFields()
        {
            txbVeganTypeIdType.Clear();
            txbVeganTypeName.Clear();
        }

        // ListBox selection events
        private void listBoxVegans_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxVegans.SelectedItem != null)
            {
                var selectedItem = listBoxVegans.SelectedItem;
                var vegan = selectedItem.GetType().GetProperty("Vegan").GetValue(selectedItem) as Vegan;
                
                if (vegan != null)
                {
                    txbVeganId.Text = vegan.Id.ToString();
                    txbVeganName.Text = vegan.Name;
                    txbVeganDescription.Text = vegan.Description;
                    txbVeganPrice.Text = vegan.Price.ToString();
                    txbVeganTypeId.Text = vegan.VeganTypeId.ToString();
                }
            }
        }

        private void listBoxVeganTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxVeganTypes.SelectedItem != null)
            {
                var selectedItem = listBoxVeganTypes.SelectedItem;
                var veganType = selectedItem.GetType().GetProperty("VeganType").GetValue(selectedItem) as VeganType;
                
                if (veganType != null)
                {
                    txbVeganTypeIdType.Text = veganType.Id.ToString();
                    txbVeganTypeName.Text = veganType.Name;
                }
            }
        }
    }
}
