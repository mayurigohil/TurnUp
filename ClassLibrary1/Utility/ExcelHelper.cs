using ClassLibrary1.Models;
//using CsvHelper;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LumenWorks.Framework.IO.Csv;

namespace ClassLibrary1.Utility
{
    class ExcelHelper
    {
        public  static IEnumerable TestDataCSV()
        {
            //Provide path of file and also change property to Copy always
            string filePath = "Models\\Data.csv"; // C: \Users\Dell\Documents\VB Feb 2021\FirstTests\ClassLibrary1\Models\

            //reading csv file
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filePath)), true))
            {
                //Iterating csv file
                while (csv.ReadNextRecord())
                {
                    yield return (csv[0], csv[1], csv[2], csv[3], csv[4], csv[5], csv[6], csv[7], csv[8], csv[9], csv[10], csv[11]);
                }
            }
        }

        public void TestDataCSV1()
        {
            //Provide path of file and also change property to Copy always
            string filePath = "Models\\Data.csv"; // C: \Users\Dell\Documents\VB Feb 2021\FirstTests\ClassLibrary1\Models\

            //reading csv file
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filePath)), true))
            {
                //Iterating csv file
                while (csv.ReadNextRecord())
                {
                  //  yield return (csv[0], csv[1], csv[2], csv[3], csv[4], csv[5], csv[6], csv[7], csv[8], csv[9], csv[10], csv[11]);
                }
            }
        }


    }
}
