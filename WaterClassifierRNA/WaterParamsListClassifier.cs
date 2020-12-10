using ENTITY;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace WaterClassifierRNA
{
    public partial class WaterParamsListClassifier : Form
    {
        Perceptron _perceptron;
        WaterParamsService paramsService;
        double[,] inputParamsList;
        public WaterParamsListClassifier()
        {
            InitializeComponent();
        }
        public WaterParamsListClassifier(double[,] paramsList, Perceptron perceptron)
        {
            InitializeComponent();
            FillDataGridWaterParams(paramsList);
            inputParamsList = paramsList;
            _perceptron = perceptron;
            paramsService = new WaterParamsService();
            CalculateResults();
        }

        private void dgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void InitializateColumnsWaterParams(int columnCount)
        {
            string[] headers ={ "UPC", "UNT", "pH", "CRL", "CaCO3", 
                                "Ca", "PO4 ^ 3", "Mn", "Mo", "Mg", 
                                "Q_A", "Q_DT", "Q_HT", "Q_MG", "Q_S", 
                                "Q_CT", "Q_CF", "Q_MC", "Q_CLD", "M_CT", "M_E", "M_MF"};
            
            dgWaterParams.ColumnCount = columnCount;
            for (int i = 0; i < columnCount; i++)
            {
                dgWaterParams.Columns[i].Name = headers[i];
            }

        }
        private void FillDataGridWaterParams(double[,] a)
        {
            int totalColumns = a.GetLength(1);
            int totalRows = a.GetLength(0);
            InitializateColumnsWaterParams(totalColumns);
            dgWaterParams.Rows.Clear();
            int n = 0;
            for (int i = 0; i < totalRows; i++)
            {
                dgWaterParams.Rows.Add();
                for (int j = 0; j < totalColumns; j++)
                {
                    dgWaterParams.Rows[i].Cells[j].Value = a[i, j];
                }
            }
        }
        
        private CellStyle ClassifyWater(string option)
        {
            /*0,0,0 - Sin riesgo - Verde
              0,0,1 - Bajo riesgo - Amarillo
              0,1,0 - Medio riesgo - Naranja
              0,1,1 Alto riesgo - Rojo
              1,0,0 - Inviable sanitariamente - Negro*/
            CellStyle cellStyle=new CellStyle("",Color.White,Color.Black);
            switch (option)
            {

                case "000":
                    cellStyle=new CellStyle("Sin riesgo", Color.Green, Color.White);
                    break;
                case "001":
                    cellStyle = new CellStyle("Bajo riesgo", Color.Yellow, Color.Black);
                    break;
                case "010":
                    cellStyle = new CellStyle("Medio riesgo", Color.Orange, Color.White);
                    break;
                case "011":
                    cellStyle = new CellStyle("Alto riesgo", Color.Red, Color.White);
                    break;
                case "100":
                    cellStyle = new CellStyle("Inviable sanitariamente", Color.Black, Color.White);
                    break;
            }
            return cellStyle;
        }
        private double[] CalculatePerceptronOutputs(double[] inputArray)
        {
            double[] outputs = { 0 };
            outputs = _perceptron.Activate(inputArray);
            outputs = paramsService.RoundValuesFromArray(outputs);
            return outputs;
        }
        private List<double[]> convertToList(double[,] a)
        {
            List<double[]> lista = new List<double[]>();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                double[] b = new double[a.GetLength(1)];
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    b[j] = a[i, j];
                }
                lista.Add(b);
            }
            return lista;
        }
        private void CalculateResults()
        {
            if (_perceptron != null)
            {
                var patterns = convertToList(inputParamsList);
                dgOutputs.Rows.Clear();
                dgOutputs.ColumnCount = 1;
                dgOutputs.Columns[0].Name = "Resultado";
                for (int i = 0; i < patterns.Count; i++)
                {
                    dgOutputs.Rows.Add();
                    var option = paramsService.BuildOption(CalculatePerceptronOutputs(patterns[i]));
                    var cellStyle = ClassifyWater(option);

                    dgOutputs.Rows[i].Cells[0].Value =cellStyle.Text;
                    dgOutputs.Rows[i].Cells[0].Style.BackColor = cellStyle.BackColor;
                    dgOutputs.Rows[i].Cells[0].Style.ForeColor = cellStyle.FontColor;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    class CellStyle {
        public string Text { get; set; }
        public Color BackColor { get; set; }
        public Color FontColor { get; set; }
        public CellStyle(string text, Color backColor,  Color fontColor )
        {
            Text = text;
            BackColor = backColor;
            FontColor = fontColor;
        }
    }
}
