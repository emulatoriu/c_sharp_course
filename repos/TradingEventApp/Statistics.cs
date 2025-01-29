using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingEventApp
{    
    internal class Statistics
    {
        public String Name { get; set; }
        private List<float> allBudgets = new List<float>();

        public Statistics(String name)
        {
            Name = name;
        }

        public void addBudget(float budget)
        {
            allBudgets.Add(budget);
        }

        public String getBudgetMapping()
        {
            String readyString = "['Times', 'Budget', 'Budget'],";
            for(int i=0; i<allBudgets.Count; i++)
            {
                readyString += $"['{i + 1}', {(int)allBudgets[i]}, {(int)allBudgets[i]}],";
            }
            return readyString.Substring(0, readyString.Length - 1);
        }

        public void generateStatisticsFile()
        {
            string sPath = @"D:\"+Name+".html";

            using (StreamWriter sw = new StreamWriter(sPath))
            {
                sw.WriteLine("<html>"
  +"<head>"
  +"<script type=\"text/javascript\" src=\"https://www.gstatic.com/charts/loader.js\"></script>"
  +"<script type=\"text/javascript\">"
      + "google.charts.load('current', {'packages': ['imagelinechart']});"
                + "google.charts.setOnLoadCallback(drawChart);"
+ "                function drawChart(){"
+ "                    var data = google.visualization.arrayToDataTable(["

   /*+ "                   ['Times', 'Budget'],"

                      + "['1', 1000],"

                      + "['2', 1170],"

                      + "['3', 660],"

                      + "['4', 1030]"
    */ + getBudgetMapping() + "]);"

                + "var chart = new google.visualization.ImageLineChart(document.getElementById('chart_div'));"

                + "chart.draw(data, { width: 400, height: 240, min: 0});"
            + "}"
    + "</script>"
  + "</head>"
  + "<body>"
    + "<div id = \"chart_div\" style = \"width: 400px; height: 240px;\"></div>"

     + "</body>"
   + "</html>");                
            }
        }
    }
}
