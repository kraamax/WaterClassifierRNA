using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITY;
using Models;
using Newtonsoft.Json;
using BLL;

namespace WaterClassifierRNA
{
    public partial class WatterClassifier : Form
    {
        Perceptron perceptron;
        double[,] paramsList;
        WaterParamsService paramsService;

        public WatterClassifier()
        {
            InitializeComponent();
            InitializeNetwork();
            paramsService = new WaterParamsService();
        }

        private void WatterClassifier_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            string option = paramsService.BuildOption(CalculatePerceptronOutputs());
            ClassifyWater(option);
        }
        private void ClassifyWater(string option) {
            /*0,0,0 - Sin riesgo - Verde
              0,0,1 - Bajo riesgo - Amarillo
              0,1,0 - Medio riesgo - Naranja
              0,1,1 Alto riesgo - Rojo
              1,0,0 - Inviable sanitariamente - Negro*/
            switch (option) {

                case "000": BuildTextBoxResult("\r\nSin riesgo\r\n", Color.Green);
                    break;
                case "001":
                    BuildTextBoxResult("Bajo riesgo", Color.Yellow);
                    break;
                case "010":
                    BuildTextBoxResult("Medio riesgo", Color.Orange);
                    break;
                case "011":
                    BuildTextBoxResult("Alto riesgo", Color.Red);
                    break;
                case "100":
                    BuildTextBoxResult("Inviable sanitariamente", Color.Black);
                    break;
            }   
        }
        private void BuildTextBoxResult(string message, Color color) {
            /*txtResult.Text = message;
            txtResult.TextAlign = HorizontalAlignment.Center;
            txtResult.BackColor = color;
            txtResult.ForeColor = Color.White;*/
            lblResult.Text = message;
            lblResult.BackColor = color;
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            lblResult.ForeColor = Color.White;
        }
        
        private double[] CalculatePerceptronOutputs() {
            WaterParams waterParams = SetWaterParamsModel();
            double[] inputArray = { };
            double[] outputs = { 0 };
            if (waterParams != null)
            {
                inputArray = CreateInputArray(waterParams);
                outputs= perceptron.Activate(inputArray);
            }
            printArray(outputs);
            outputs = paramsService.RoundValuesFromArray(outputs);
            Console.WriteLine("-----------------------------");
            printArray(outputs);
            return outputs;
        }
        void printArray(double[] array) {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        private void InitializeNetwork()
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(_filePath);
            //filepath = C:\Users\xxx?\source\repos\WaterClassifierRNA\WaterClassifierRNA\bin\Debug
            perceptron = LoadFile(_filePath+ @"\redEntrenada");

            if (perceptron == null)
            {
                MessageBox.Show("No se pudo cargar la red");
            }
        }

        public Perceptron LoadFile(string fileName)
        {
            FileStream fileStream = null;
            Perceptron p = null;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter deserializer = new BinaryFormatter();
                p = (Perceptron)deserializer.Deserialize(fileStream);
            }
            catch (Exception e)
            {
                Console.WriteLine("There's been an error. Here is the message: " + e.Message);
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            if (p == null)
            {
                MessageBox.Show("Fallé");
            }
            return p;
        }

        private double[] CreateInputArray(WaterParams waterParams) {

            double[] array = {
             waterParams.UPC,
            waterParams.UNT,
            waterParams.pH,
            waterParams.CRL,
            waterParams.CaCO3,
            waterParams.Ca,
            waterParams.PO43,
            waterParams.Mn,
            waterParams.Mo,
            waterParams.Mg,
            waterParams.Q_A,
            waterParams.Q_DT,
            waterParams.Q_HT,
            waterParams.Q_MG,
            waterParams.Q_S,
            waterParams.Q_CT,
            waterParams.Q_CF,
            waterParams.Q_MC,
            waterParams.Q_CLD,
            waterParams.Q_CT,
            waterParams.M_E,
            waterParams.M_MF
        };
            return array;            
        }

        private WaterParams SetWaterParamsModel()
        {
            WaterParams waterParams = new WaterParams();
            try
            {
                waterParams.UPC = double.Parse(txtUPC.Text);
                waterParams.UNT = double.Parse(txtUNT.Text);
                waterParams.pH = double.Parse(txtpH.Text);
                waterParams.CRL = double.Parse(txtCRL.Text);
                waterParams.CaCO3 = double.Parse(txtCaCO3.Text);
                waterParams.Ca = double.Parse(txtCa.Text);
                waterParams.PO43 = double.Parse(txtPO43.Text);
                waterParams.Mn = double.Parse(txtMn.Text);
                waterParams.Mo = double.Parse(txtMo.Text);
                waterParams.Mg = double.Parse(txtMg.Text);
                waterParams.Q_A = double.Parse(txtQ_A.Text);
                waterParams.Q_DT = double.Parse(txtQ_DT.Text);
                waterParams.Q_HT = double.Parse(txtQ_HT.Text);
                waterParams.Q_MG = double.Parse(txtQ_MG.Text);
                waterParams.Q_S = double.Parse(txtQ_S.Text);
                waterParams.Q_CT = double.Parse(txtQ_CT.Text);
                waterParams.Q_CF = double.Parse(txtQ_CF.Text);
                waterParams.Q_MC = double.Parse(txtQ_MC.Text);
                waterParams.Q_CLD = double.Parse(txtQ_CLD.Text);
                waterParams.Q_CT = double.Parse(txtQ_CT.Text);
                waterParams.M_E = double.Parse(txtM_E.Text);
                waterParams.M_MF = double.Parse(txtM_MF.Text);
            }
            catch (Exception)
            {
                waterParams = null;
                MessageBox.Show("Revise que los datos esten correctos");
            }
            return waterParams;
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadParamsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadParamsList();
            if (paramsList != null) {
                WaterParamsListClassifier waterParamsListClassifier = new WaterParamsListClassifier(paramsList, perceptron);
                waterParamsListClassifier.Show();
            }
        }
        private void LoadParamsList() {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            paramsList = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    paramsList = paramsService.ReadSimulationPatterns(openFileDialog.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo cargar el archivo");
                }

            }
        }
    }
}
