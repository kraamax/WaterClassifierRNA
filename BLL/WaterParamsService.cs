using System;
using DAL;

namespace BLL
{
    public class WaterParamsService
    {
        WaterParamsRepository paramsRepository = new WaterParamsRepository();
        public double[,] ReadSimulationPatterns(string path)
        {
            return paramsRepository.ReadSimulationPatterns(path);
        }
        public string BuildOption(double[] array)
        {
            string option = "";
            for (int i = 0; i < array.Length; i++)
            {
                option = option + array[i];
            }
            return option;
        }
        public double[] RoundValuesFromArray(double[] inputArray)
        {
            double[] roundedArray = new double[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                roundedArray[i] = Math.Round(inputArray[i], 0);
            }
            return roundedArray;
        }
    }
}
