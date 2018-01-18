using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace P_Median_Problem
{
    public partial class Form1 : Form
    {

        Genetic_Algorithm Genetic_Alg { get; set; } //Alg is initilized after form loads
        bool Algorith_Paused { get; set; }   //Paused or not etc.
        public bool isLogging { get; set; }
        public bool isKeepingImages { get; set; }
        public List<Node> Nodes { get; set; }
        public Logger logger { get; set; }

        /// <summary>
        /// Draws the given nodeset to the pictureBox on the Form
        /// </summary>
        public void DrawMap(NodeSet set, string tag_value, string mark)
        {
            Bitmap map = Node_Map.Generate_Bitmap(set, tag_value, mark);
            pb_MapBox.Image = map;
        }

        /// <summary>
        /// Refreshes the node list passedo on to the algorithm, used by restart and initilization
        /// </summary>
        public void refreshNodeSetSelection()
        {
            //Create a new Nodesets depending on the selection (Read given files)
            this.Nodes = new List<Node>();

            //Create a nodeSet from eil51
            if (rb_eil51.Checked)
            {
                //Create readers for the files
                StreamReader Reader_Demands = new StreamReader(@"eil51\dem51.txt");
                StreamReader Reader_Posx = new StreamReader(@"eil51\x51.txt");
                StreamReader Reader_PosY = new StreamReader(@"eil51\y51.txt");

                //Go through the text files
                for (int i = 0; i < 51; i++)
                {
                    //Find value by readling the line and splitting the output and getting the 2nd value from the split output as integer
                    int demand = Int32.Parse(Reader_Demands.ReadLine().Split('\t')[1]);
                    int x = Int32.Parse(Reader_Posx.ReadLine().Split('\t')[1]);
                    int y = Int32.Parse(Reader_PosY.ReadLine().Split('\t')[1]);

                    Nodes.Add(new Node(x, y, demand));
                }

            }
            //Create a nodeSet from eil76
            else if (rb_eil76.Checked)
            {
                StreamReader Reader_Demands = new StreamReader(@"eil76\dem76.txt");
                StreamReader Reader_Posx = new StreamReader(@"eil76\x76.txt");
                StreamReader Reader_PosY = new StreamReader(@"eil76\y76.txt");

                //Go through the text files
                for (int i = 0; i < 76; i++)
                {
                    //Find value by readling the line and splitting the output and getting the 2nd value from the split output as integer
                    int demand = Int32.Parse(Reader_Demands.ReadLine().Split('\t')[1]);
                    int x = Int32.Parse(Reader_Posx.ReadLine().Split('\t')[1]);
                    int y = Int32.Parse(Reader_PosY.ReadLine().Split('\t')[1]);

                    Nodes.Add(new Node(x, y, demand));
                }
            }
            //Create a random nodeset
            else if (eb_Random.Checked)
            {
                Random r = new Random();
                //Iterate for the given number of nodes
                for (int i = 0; i < nud_Number_of_Nodes.Value; i++)
                {
                    Node n = new Node(r.Next(70), r.Next(70), r.Next(30));  //Attain a value between 0 and 70 for position and 0 to 30 for demand value (these are the highest values in eil51&eil76)
                    Nodes.Add(n);
                }
            }
        }

        #region Upon Startup
        public Form1()
        {
            InitializeComponent();

            logger = new Logger();
            //start puased
            Algorith_Paused = true;
            refreshNodeSetSelection();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #endregion

        /// <summary>
        /// Enables/disables the delay_timer (start/stop watch)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Start_Stop_Click(object sender, EventArgs e)
        {

           
            refreshNodeSetSelection();

            //Enable restart button
            btn_Restart.Enabled = true;

            //Toggle paused
            if (!Algorith_Paused)   //If algorithm is running, pause
            {
                //start the clock and update the property
                Algorith_Paused = true;
                lb_Status.Text = "Paused";
                delay_timer.Stop();
            }
            else//If algorithm is paused, unpause
            {
                //Stop the clock and update the property
                Algorith_Paused = false;
                lb_Status.Text = "Working...";
                delay_timer.Start();
            }

            //If the program is not "paused" let the timer tick
            if (!Algorith_Paused)
            {

                if (delay_timer.Enabled == false) delay_timer.Enabled = true;                //Just to make sure
                delay_timer.Start();
            }


        }
        private void btn_Restart_Click(object sender, EventArgs e)
        {
            //Display values
            logger.clearLines();
            rtb_log.Text = "";
            pb_MapBox.Image = null;
            lb_Best_Solution.Text = "_";
            lb_Current_Solution.Text = "_";
            lb_Iteration_Count.Text = "_";
            lb_Status.Text = "Idle";

            delay_timer.Stop();
            Algorith_Paused = true;

            //Wipe out the current algorithm
            Genetic_Alg = null;
            refreshNodeSetSelection();

            btn_Restart.Enabled = false;   
            btn_Start_Stop.Enabled = true;
        }

        private void eb_Random_CheckedChanged(object sender, EventArgs e)
        {
            //If random is checked enable the node count selection
            nud_Number_of_Nodes.Enabled = true;
            refreshNodeSetSelection();

        }

        private void rb_eil76_CheckedChanged(object sender, EventArgs e)
        {
            //If this is checked disable node count selection
            nud_Number_of_Nodes.Enabled = false;
            refreshNodeSetSelection();
        }

        private void rb_eil51_CheckedChanged(object sender, EventArgs e)
        {
            //If this is checked disable node count selection
            nud_Number_of_Nodes.Enabled = false;
            refreshNodeSetSelection();
        }

        private void cbLogger_CheckedChanged(object sender, EventArgs e)
        {
            isLogging = cbLogger.Checked;
        }

        private void cbKeepMap_CheckedChanged(object sender, EventArgs e)
        {
            isKeepingImages = cbKeepMap.Checked;
        }

        private void nudDelay_ValueChanged(object sender, EventArgs e)
        { 
            delay_timer.Interval = System.Convert.ToInt32(nudDelay.Value);
        }

        int ticker = 0;
        double avgCal = 0;
        /// <summary>
        /// "Internal Clock" of the program, cycles the algorithm and changes the map alongside the display values every clock tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delay_timer_Tick(object sender, EventArgs e)
        {
            //Stop watch used to track how long a cycle of the program takes in milliseconds
            Stopwatch st = new Stopwatch();
            st.Start();
            //If not initilized, initilize
            if (Genetic_Alg == null)
            {
                //Upon loading the form, Create a new genetic algorithm on the given property
                Genetic_Alg = new Genetic_Algorithm(Nodes, nud_Mutation_Rate.Value, nud_Pop_Count.Value, nud_Max_Iterations.Value, nud_Number_of_Facilities.Value, nud_SelectionDifference.Value, nud_SelectionDifferenceHigh.Value, logger);
            }

            //Upon tick cycle the genetic algorithm
            //Process the current 
            bool alg_Status = Genetic_Alg.Process_Current_Generation(); //If returns false, algorithm has hit a cap and wont continue
            
            //Update display values
            lb_Iteration_Count.Text = Genetic_Alg.Iteration_Count + "";
            lb_Current_Solution.Text = Genetic_Alg.CurrentBest_Fitness + "";
            lb_Best_Solution.Text = Genetic_Alg.Best_Fitness + "";

            //Draw Current Best's map
            DrawMap(Genetic_Alg.CurrentBest_Solution, "" + ticker, "Iteration: " + Genetic_Alg.Iteration_Count + "");
            if (cbKeepMap.Checked) ticker++;

            avgCal += Genetic_Alg.CurrentBest_Fitness;

            //Cycle to the next generation
            Genetic_Alg.Next_Generation();

            st.Stop();
            logger.AddLine("⟿Time elapsed this generation: " + st.ElapsedMilliseconds + "ms");

            //Push logger to the console box
            rtb_log.Text = logger.GiveCompleteString();

            //If the algorithm returned false, pause the program and disable the start/stop button, display the best solution, finalize algorithm
            if (!alg_Status)
            {
                logger.AddLine("Process Complete!");
                logger.AddLine("Avarage Best Fitness: " + avgCal/Genetic_Alg.Maximum_Iterations);
                logger.AddLine("Difference: " + ((avgCal / Genetic_Alg.Maximum_Iterations) - Genetic_Alg.Best_Fitness));
                logger.AddLine("Best Fitness: " + Genetic_Alg.Best_Fitness);
                rtb_log.Text = logger.GiveCompleteString();

                if (cbLogger.Checked)
                {
                    System.IO.StreamWriter writer = new StreamWriter("out.txt");
                    writer.Write(logger.GiveCompleteString());
                    writer.Close();
                }
                DrawMap(Genetic_Alg.Best_Solution, "BEST", "BEST SOLUTION, FITNESS: " + Genetic_Alg.Best_Fitness);
                lb_Status.Text = "Completed!";

                btn_Start_Stop.Enabled = false;
                delay_timer.Stop();
            }
        }

        private void nud_Mutation_Rate_ValueChanged(object sender, EventArgs e)
        {
            refreshNodeSetSelection();
        }

        private void nud_Max_Iterations_ValueChanged(object sender, EventArgs e)
        {
            refreshNodeSetSelection();
        }

        private void nud_Pop_Count_ValueChanged(object sender, EventArgs e)
        {
            refreshNodeSetSelection();
        }
    }
}
