﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HideAndSeek
{
    public partial class Form1 : Form
    {
        public string fileName1;
        public string fileName2;
        public string currentItem;
        public Graph graph = new Graph();

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                fileName1 = openFileDialog1.FileName;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog2.FileName;
                fileName2 = openFileDialog2.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click_1(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click_2(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if(fileName2 != null)
            {
                listBox1.BeginUpdate();
                string[] inputQuery = System.IO.File.ReadAllLines(@fileName2);
                for (int x = 1; x < inputQuery.Length; x++)
                {
                    if (graph.answerQuery(inputQuery[x],false))
                        listBox1.Items.Add(inputQuery[x] + " BERHASIL");
                    else
                        listBox1.Items.Add(inputQuery[x] + " GAGAL");
                }
                listBox1.EndUpdate();
            } else
            {
                string query = "";
                if (radioButton1.Checked)
                    query += 0;
                else
                    query += 1;
                query += " " + textBox3.Text;
                query += " " + textBox4.Text;
                listBox1.BeginUpdate();
                if (graph.answerQuery(query, false))
                    listBox1.Items.Add(query + " BERHASIL");
                else
                    listBox1.Items.Add(query + " GAGAL");
                listBox1.EndUpdate();
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            graph.answerQuery(currentItem,true);
            
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentItem = listBox1.SelectedItem.ToString();
        }

        private void Button5_Click(object sender, EventArgs e)
        { 
            if (fileName1 != "")
            {
                // Show the complete graph according to filePath
                graph.getInput(fileName1);
                graph.initialize();
                graph.drawGraph();
                graph.makeUnvisited();
                graph.getLevel(1, 1);
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            updateButtonShowGraph();
        }

        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            updateButtonShowGraph();
        }

        private void updateButtonShowGraph()
        {
            button5.Enabled = textBox1.Text != string.Empty && openFileDialog1.CheckFileExists;
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            updateButtonShowQuery();
        }

        private void TextBox2_Validating(object sender, CancelEventArgs e)
        {
            updateButtonShowQuery();
        }

        private void updateButtonShowQuery()
        {
            button3.Enabled = (textBox2.Text != string.Empty && openFileDialog2.CheckFileExists);
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
