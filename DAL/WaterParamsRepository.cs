using System;
using System.IO;
namespace DAL
{
    public class WaterParamsRepository
    {
        public double[,] ReadSimulationPatterns(string path)
        {
            StreamReader sr = File.OpenText(path);
            StreamReader auxSr = File.OpenText(path);
            string s = "";
            var columns = 0;
            var rows = 0;
            while ((s = sr.ReadLine()) != null)
            {
                var a = s.Split(';');
                if (rows == 0) columns = a.Length;
                rows++;
            }
            double[,] result = new double[rows, columns];
            int currentRow = 0;
            while ((s = auxSr.ReadLine()) != null)
            {
                var a = s.Split(';');
                for (int i = 0; i < a.Length; i++)
                {
                    result[currentRow, i] = double.Parse(a[i]);
                }
                currentRow++;

            }
            return result;
        }
    }
}
