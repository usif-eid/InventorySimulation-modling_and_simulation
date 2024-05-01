using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryTesting;


using InventoryModels;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
        private SimulationSystem simulationSystem;

        private string path;

        public Form1(SimulationSystem system, string path)
        {
            InitializeComponent();
            this.simulationSystem = system;
            this.path = path;

        }

        private void RunSimulationButton_Click(object sender, EventArgs e)
        {
            DisplayResultsInDataGridView();
            DisplayPerformanceMetrics();
        }

        private void DisplayResultsInDataGridView()
        {
            // Assuming you have a form with a DataGridView named dataGridView1
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Add columns to DataGridView
            dataGridView1.Columns.Add("Day", " Day");
            dataGridView1.Columns.Add("cycle", " cycle");
            dataGridView1.Columns.Add("daywithincycle", " daywithincycle");
            dataGridView1.Columns.Add("beginning_inventory", "beginning_inventory ");
            dataGridView1.Columns.Add("random_digits", "  random_digits ");
            dataGridView1.Columns.Add("demand", "demand ");
            dataGridView1.Columns.Add("ending_inventory", " ending_inventory");
            dataGridView1.Columns.Add("shortage_quantity", "shortage_quantity ");
            dataGridView1.Columns.Add("order_quantity", "order_quantity ");
            dataGridView1.Columns.Add("random_digits_leadtime", "random_digits_leadtime ");
            dataGridView1.Columns.Add("leadtime", "leadtime ");
            dataGridView1.Columns.Add("day_unti_arrival", "day_unti_arrival ");
            // Add rows to DataGridView
            foreach (var simulationCase in simulationSystem.SimulationTable)
            {

                dataGridView1.Rows.Add(
               simulationCase.Day,
               simulationCase.Cycle,
               simulationCase.DayWithinCycle,
               simulationCase.BeginningInventory,
               simulationCase.RandomDemand, 
               simulationCase.Demand,
               simulationCase.EndingInventory,
               simulationCase.ShortageQuantity,
               simulationCase.OrderQuantity,
               simulationCase.RandomLeadDays,
               simulationCase.LeadDays,
               simulationCase.DaysTillArrival,
               simulationCase.OrderPlaced
               )
           ;
            }


            dataGridView1.Refresh();

        }
        private void DisplayPerformanceMetrics()
        {


            EndingInventoryAverage.Text = simulationSystem.PerformanceMeasures.EndingInventoryAverage.ToString();
            ShortageQuantityAverage.Text = simulationSystem.PerformanceMeasures.ShortageQuantityAverage.ToString();
            
        }


        


       
        private void testcase1_Click_1(object sender, EventArgs e)
        {
            DisplayResultsInDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayPerformanceMetrics();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

