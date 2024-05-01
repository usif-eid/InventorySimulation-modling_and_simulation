using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            DemandDistribution = new List<Distribution>();
            LeadDaysDistribution = new List<Distribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
        }


        ///////////// INPUTS /////////////

        public int OrderUpTo { get; set; }
        public int ReviewPeriod { get; set; }
        public int NumberOfDays { get; set; }
        public int StartInventoryQuantity { get; set; }
        public int StartLeadDays { get; set; }
        public int StartOrderQuantity { get; set; }
        public List<Distribution> DemandDistribution { get; set; }
        public List<Distribution> LeadDaysDistribution { get; set; }

        private SimulationSystem system;

        private Random r = new Random();


        ///////////// OUTPUTS /////////////

        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

        public decimal TotalEndInventory;

        public decimal TotalShortage;


        public void test_num(string path)
        {
            string[] lines = File.ReadAllLines(path);

            int lineIndex = 0; // Start from the first line

            // Read the OrderUpTo
            OrderUpTo = int.Parse(lines[lineIndex + 1].Trim());

            // Read the ReviewPeriod
            ReviewPeriod = int.Parse(lines[lineIndex + 4].Trim());

            // Read the StartInventoryQuantity
            StartInventoryQuantity = int.Parse(lines[lineIndex + 7].Trim());

            // Read the StartLeadDays
            StartLeadDays = int.Parse(lines[lineIndex + 10].Trim());

            // Read the StartOrderQuantity
            StartOrderQuantity = int.Parse(lines[lineIndex + 13].Trim());

            // Read the NumberOfDays
            NumberOfDays = int.Parse(lines[lineIndex + 16].Trim());

            // Read the DemandDistribution
            lineIndex += 19; // Move to the line where DemandDistribution starts
            while (lineIndex < lines.Length && lines[lineIndex] != "")
            {
                string[] distributionParts = lines[lineIndex].Split(',');
                DemandDistribution.Add(new Distribution
                {
                    Value = int.Parse(distributionParts[0].Trim()),
                    Probability = decimal.Parse(distributionParts[1].Trim()),
                });

                lineIndex++;
            }

            // Read the LeadDaysDistribution
            lineIndex += 2; // Move to the line where LeadDaysDistribution starts
            while (lineIndex < lines.Length && lines[lineIndex] != "")
            {
                string[] distributionParts = lines[lineIndex].Split(',');
                LeadDaysDistribution.Add(new Distribution
                {
                    Value = int.Parse(distributionParts[0].Trim()),
                    Probability = decimal.Parse(distributionParts[1].Trim()),
                });

                lineIndex++;
            }
        }



        //public SimulationSystem Read_fromFile(string path)
        //{
        //    string w = "";
        //    FileStream fs = new FileStream(path, FileMode.Open); // Use the provided path instead of "TestCase1.txt"
        //    StreamReader sr = new StreamReader(fs);
        //    system = new SimulationSystem();

        //    while ((w = sr.ReadLine()) != null)
        //    {
        //        if (w == "") continue;

        //        if (w == "OrderUpTo")
        //            system.OrderUpTo = int.Parse(sr.ReadLine());
        //        else if (w == "ReviewPeriod")
        //            system.ReviewPeriod = int.Parse(sr.ReadLine());
        //        else if (w == "StartInventoryQuantity")
        //            system.StartInventoryQuantity = int.Parse(sr.ReadLine());
        //        else if (w == "StartLeadDays")
        //            system.StartLeadDays = int.Parse(sr.ReadLine());
        //        else if (w == "StartOrderQuantity")
        //            system.StartOrderQuantity = int.Parse(sr.ReadLine());
        //        else if (w == "NumberOfDays")
        //            system.NumberOfDays = int.Parse(sr.ReadLine());
        //        else if (w == "DemandDistribution")
        //        {
        //            // Read and parse demand distribution data
        //            while ((w = sr.ReadLine()) != null && !string.IsNullOrWhiteSpace(w))
        //            {
        //                string[] parts = w.Split(',');
        //                if (parts.Length == 2 && int.TryParse(parts[0], out int demand) && double.TryParse(parts[1], out double probability))
        //                {
        //                    system.DemandDistribution.Add(new Distribution { Value = demand, Probability = (decimal)probability });
        //                }
        //            }
        //        }
        //        else if (w == "LeadDaysDistribution")
        //        {
        //            // Read and parse lead days distribution data
        //            while ((w = sr.ReadLine()) != null && !string.IsNullOrWhiteSpace(w))
        //            {
        //                string[] parts = w.Split(',');
        //                if (parts.Length == 2 && int.TryParse(parts[0], out int leadDays) && double.TryParse(parts[1], out double probability))
        //                {
        //                    system.LeadDaysDistribution.Add(new Distribution { Value = leadDays, Probability = (decimal)probability });
        //                }
        //            }
        //        }
        //        else
        //            continue;
        //    }

        //    sr.Close();
        //    fs.Close();
        //    return system;
        //}


        public void ServerBegin()
        {
            FillSimTable();

        }


        public void Calc_DemandDistribution()
        {
            for (int i = 0; i < DemandDistribution.Count; i++)
            {
                if (i == 0)
                {
                    DemandDistribution[i].CummProbability = DemandDistribution[i].Probability;
                }
                else
                {
                    DemandDistribution[i].CummProbability = DemandDistribution[i].Probability + DemandDistribution[i - 1].CummProbability;
                    DemandDistribution[i].MinRange = DemandDistribution[i - 1].MaxRange + 1;
                }

                DemandDistribution[i].MaxRange = (int)(DemandDistribution[i].CummProbability * 100);
            }
        }

        public void Calc_LeadDaysDistribution()
        {
            for (int i = 0; i < LeadDaysDistribution.Count; i++)
            {
                if (i == 0)
                {

                    LeadDaysDistribution[i].CummProbability = LeadDaysDistribution[i].Probability;
                }
                else
                {
                    LeadDaysDistribution[i].CummProbability = LeadDaysDistribution[i].Probability + LeadDaysDistribution[i - 1].CummProbability;
                    LeadDaysDistribution[i].MinRange = LeadDaysDistribution[i - 1].MaxRange +1;

                }


                //LeadDaysDistribution[i].MaxRange = (int)(LeadDaysDistribution[i].CummProbability * 10);//test1
                 LeadDaysDistribution[i].MaxRange = (int)(LeadDaysDistribution[i].CummProbability * 100);//test2
            }
        }


        public void Calc_Demand(int i)
        {
            int random_Num = r.Next(1, 101);
            SimulationTable[i].RandomDemand = random_Num;
            for (int J = 0; J < DemandDistribution.Count(); J++)
            {
                if (DemandDistribution[J].MinRange <= random_Num && random_Num <= DemandDistribution[J].MaxRange)
                {
                    SimulationTable[i].Demand = DemandDistribution[J].Value;
                    break;
                }
            }
        }

        public void Calc_LeadDays(int i)
        {
            if (SimulationTable[i].DayWithinCycle==ReviewPeriod)
            {
                int random_Num = r.Next(1,11);//test1
              //int random_Num = r.Next(1,20);//test2

                SimulationTable[i].RandomLeadDays = random_Num;
                    for (int j = 0; j < LeadDaysDistribution.Count(); j++)
                    {
                        if (LeadDaysDistribution[j].MinRange <= random_Num && random_Num <= LeadDaysDistribution[j].MaxRange)
                        {
                            SimulationTable[i].LeadDays = LeadDaysDistribution[j].Value;
                            break;
                        }
                    }
            }
            else
            {
                SimulationTable[i].RandomLeadDays = 0;
                SimulationTable[i].LeadDays = 0;
            }
        }

        public void Calc_Day(int i)
        {
            SimulationTable[i].Day = ++i;
        }

        public void Calc_Cycle(int i)
        {
            SimulationTable[i].Cycle = (SimulationTable[i].Day + ReviewPeriod - 1) / ReviewPeriod;
        }

        public void Calc_DayWithinCycle(int i)
        {

            if (SimulationTable[i].Day == 1)
            {
                SimulationTable[i].DayWithinCycle = 1; 
            }
            else
            {
                SimulationTable[i].DayWithinCycle = SimulationTable[i - 1].DayWithinCycle + 1; 
                if (SimulationTable[i].DayWithinCycle > ReviewPeriod)
                {
                    SimulationTable[i].DayWithinCycle = 1; 
                }
            }

            //if (SimulationTable[i].Day == 1)
            //{
            //    SimulationTable[i].DayWithinCycle = 1;
            //}
            //if (SimulationTable[i].Day != 1 && SimulationTable[i-1].DayWithinCycle<ReviewPeriod)
            //{
            //    SimulationTable[i].DayWithinCycle = SimulationTable[i-1].DayWithinCycle++;
            //}
            //else if (SimulationTable[i].Day != 1 && SimulationTable[i-1].Day==ReviewPeriod)
            //{
            //    SimulationTable[i].DayWithinCycle = 1;
            //}
        }

        public void Calc_BeginingInventory(int i)
        {
            if (SimulationTable[i].Day == 1)
            {
                SimulationTable[i].BeginningInventory = StartInventoryQuantity;
            }
            else if (SimulationTable[i].Day == StartLeadDays + 1)
            {
                SimulationTable[i].BeginningInventory = SimulationTable[i - 1].EndingInventory + StartOrderQuantity;
            }
            else if (SimulationTable[i - 1].DaysTillArrival == 0 && SimulationTable[i - 2].DaysTillArrival == 1)
            {
                for (int j = SimulationTable[i - 1].Day; j >= 1; j--)
                {
                    if (SimulationTable[j].OrderPlaced == true)
                    {
                        SimulationTable[i].BeginningInventory = SimulationTable[i - 1].EndingInventory + SimulationTable[j].OrderQuantity;
                        break;
                    }
                }
            }
            else
            {
                SimulationTable[i].BeginningInventory = SimulationTable[i - 1].EndingInventory;
            }
        }

        public void Calc_EndingInventory(int i)
        {
            if (i != 0)
            {
                if ((SimulationTable[i].Demand + SimulationTable[i - 1].ShortageQuantity) >= (SimulationTable[i].BeginningInventory ))
                {
                    SimulationTable[i].EndingInventory = 0;

                }
                else
                {
                    SimulationTable[i].EndingInventory = SimulationTable[i].BeginningInventory - (SimulationTable[i].Demand + SimulationTable[i - 1].ShortageQuantity);
                    /*if (SimulationTable[i].Day!=1 && SimulationTable[i].EndingInventory>SimulationTable[i-1].ShortageQuantity)
                    {
                        SimulationTable[i].EndingInventory -= SimulationTable[i-1].ShortageQuantity;
                    }*/

                }
            }
            else
                SimulationTable[i].EndingInventory = SimulationTable[i].BeginningInventory - SimulationTable[i].Demand;


        }

        public void Calc_ShortageQuantity(int i ,int sho )
        {
            if (SimulationTable[i].Demand + sho<= SimulationTable[i].BeginningInventory  )
            {
                SimulationTable[i].ShortageQuantity = 0;
            }
            else
            {
                SimulationTable[i].ShortageQuantity = ((SimulationTable[i].BeginningInventory - SimulationTable[i].Demand) * -1)+ SimulationTable[i-1].ShortageQuantity;
            }
        }

        public void Calc_OrderQuantity(int i)
        {
            SimulationTable[i].OrderPlaced = false;
            if (SimulationTable[i].DayWithinCycle == ReviewPeriod)
            {
                SimulationTable[i].OrderPlaced = true;
                SimulationTable[i].OrderQuantity = OrderUpTo - (SimulationTable[i].EndingInventory)+SimulationTable[i].ShortageQuantity;
                //SimulationTable[i].OrderQuantity = OrderUpTo - SimulationTable[i].EndingInventory;
            }
        }

        public void Calc_DaysUntillArrival(int i)
        {
            if (SimulationTable[i].Day == 1)
            {
                if ((StartLeadDays - 1) >= 0)
                {
                    SimulationTable[i].DaysTillArrival = StartLeadDays - 1;

                }
                else
                    SimulationTable[i].DaysTillArrival = 0;
            }
            else if (SimulationTable[i].LeadDays != 0)
            {
                SimulationTable[i].DaysTillArrival = SimulationTable[i].LeadDays;
            }
            else if (SimulationTable[i - 1].DaysTillArrival != 0 && SimulationTable[i].LeadDays == 0)
            {
                SimulationTable[i].DaysTillArrival = SimulationTable[i-1].DaysTillArrival-1;
            }
            else
            {
                    SimulationTable[i].DaysTillArrival = 0;
            }
        }

        public void Calc_TotalEndInventory(int i)
        {
            TotalEndInventory += SimulationTable[i].EndingInventory;
        }
        public void Calc_TotalShortage(int i)
        {
            TotalShortage += SimulationTable[i].ShortageQuantity;
        }
        public void FillSimTable()
        {
            Calc_DemandDistribution();
            Calc_LeadDaysDistribution();

            TotalEndInventory = 0;
            TotalShortage = 0;


            for (int i = 0; i < NumberOfDays; i++)
            {

                SimulationTable.Add(new SimulationCase());
                Calc_Day(i);
                Calc_Cycle(i);
                Calc_DayWithinCycle(i);
                Calc_BeginingInventory(i);
                Calc_Demand(i);
                Calc_EndingInventory(i);
                if (i == 0)
                {
                    if (SimulationTable[i].Demand < SimulationTable[i].BeginningInventory)
                        SimulationTable[i].ShortageQuantity = 0;
                    else
                    {
                        SimulationTable[i].ShortageQuantity = SimulationTable[i].Demand - SimulationTable[i].BeginningInventory;
                        SimulationTable[i].EndingInventory = 0;
                    }
                }
                else
                    Calc_ShortageQuantity(i, SimulationTable[i - 1].ShortageQuantity);
                Calc_OrderQuantity(i);
                Calc_LeadDays(i);
                Calc_DaysUntillArrival(i);
                Calc_TotalEndInventory(i);
                Calc_TotalShortage(i);
            }
            PerformanceMeasures.EndingInventoryAverage = TotalEndInventory / NumberOfDays;
            PerformanceMeasures.ShortageQuantityAverage = TotalShortage / NumberOfDays;
        }

    }
}
