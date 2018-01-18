namespace P_Median_Problem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nud_Mutation_Rate = new System.Windows.Forms.NumericUpDown();
            this.nud_Max_Iterations = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Start_Stop = new System.Windows.Forms.Button();
            this.rb_eil51 = new System.Windows.Forms.RadioButton();
            this.rb_eil76 = new System.Windows.Forms.RadioButton();
            this.eb_Random = new System.Windows.Forms.RadioButton();
            this.nud_Number_of_Facilities = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Restart = new System.Windows.Forms.Button();
            this.pb_MapBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_Iteration_Count = new System.Windows.Forms.Label();
            this.lb_Current_Solution = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_Best_Solution = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nud_Pop_Count = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.Tool_Tip = new System.Windows.Forms.ToolTip(this.components);
            this.nud_Number_of_Nodes = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.cbLogger = new System.Windows.Forms.CheckBox();
            this.cbKeepMap = new System.Windows.Forms.CheckBox();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_SelectionDifference = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nud_SelectionDifferenceHigh = new System.Windows.Forms.NumericUpDown();
            this.delay_timer = new System.Windows.Forms.Timer(this.components);
            this.lb_Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Mutation_Rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Max_Iterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Number_of_Facilities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_MapBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Pop_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Number_of_Nodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SelectionDifference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SelectionDifferenceHigh)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_Mutation_Rate
            // 
            this.nud_Mutation_Rate.DecimalPlaces = 2;
            this.nud_Mutation_Rate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_Mutation_Rate.Location = new System.Drawing.Point(107, 453);
            this.nud_Mutation_Rate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Mutation_Rate.Name = "nud_Mutation_Rate";
            this.nud_Mutation_Rate.Size = new System.Drawing.Size(71, 20);
            this.nud_Mutation_Rate.TabIndex = 0;
            this.Tool_Tip.SetToolTip(this.nud_Mutation_Rate, "Percent chance of mutation.");
            this.nud_Mutation_Rate.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nud_Mutation_Rate.ValueChanged += new System.EventHandler(this.nud_Mutation_Rate_ValueChanged);
            // 
            // nud_Max_Iterations
            // 
            this.nud_Max_Iterations.Location = new System.Drawing.Point(107, 478);
            this.nud_Max_Iterations.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nud_Max_Iterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Max_Iterations.Name = "nud_Max_Iterations";
            this.nud_Max_Iterations.Size = new System.Drawing.Size(71, 20);
            this.nud_Max_Iterations.TabIndex = 1;
            this.Tool_Tip.SetToolTip(this.nud_Max_Iterations, "Maximum iteration Count.\r\nProgram will terminate after this many generations\r\n if" +
        " no conclusive result is reached");
            this.nud_Max_Iterations.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nud_Max_Iterations.ValueChanged += new System.EventHandler(this.nud_Max_Iterations_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 480);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max iterations:";
            this.Tool_Tip.SetToolTip(this.label2, "Maximum iteration Count.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 455);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mutation Rate:";
            this.Tool_Tip.SetToolTip(this.label1, "Percent chance of mutation.");
            // 
            // btn_Start_Stop
            // 
            this.btn_Start_Stop.Location = new System.Drawing.Point(206, 455);
            this.btn_Start_Stop.Name = "btn_Start_Stop";
            this.btn_Start_Stop.Size = new System.Drawing.Size(118, 26);
            this.btn_Start_Stop.TabIndex = 5;
            this.btn_Start_Stop.Text = "Start/Stop";
            this.Tool_Tip.SetToolTip(this.btn_Start_Stop, "Start or Stop the Generational Behaviour");
            this.btn_Start_Stop.UseVisualStyleBackColor = true;
            this.btn_Start_Stop.Click += new System.EventHandler(this.btn_Start_Stop_Click);
            // 
            // rb_eil51
            // 
            this.rb_eil51.AutoSize = true;
            this.rb_eil51.Checked = true;
            this.rb_eil51.Location = new System.Drawing.Point(206, 539);
            this.rb_eil51.Name = "rb_eil51";
            this.rb_eil51.Size = new System.Drawing.Size(47, 17);
            this.rb_eil51.TabIndex = 6;
            this.rb_eil51.TabStop = true;
            this.rb_eil51.Text = "eil51";
            this.Tool_Tip.SetToolTip(this.rb_eil51, "Use Example with 51 nodes.");
            this.rb_eil51.UseVisualStyleBackColor = true;
            this.rb_eil51.CheckedChanged += new System.EventHandler(this.rb_eil51_CheckedChanged);
            // 
            // rb_eil76
            // 
            this.rb_eil76.AutoSize = true;
            this.rb_eil76.Location = new System.Drawing.Point(286, 539);
            this.rb_eil76.Name = "rb_eil76";
            this.rb_eil76.Size = new System.Drawing.Size(47, 17);
            this.rb_eil76.TabIndex = 7;
            this.rb_eil76.Text = "eil76";
            this.Tool_Tip.SetToolTip(this.rb_eil76, "Use example with 76 nodes.");
            this.rb_eil76.UseVisualStyleBackColor = true;
            this.rb_eil76.CheckedChanged += new System.EventHandler(this.rb_eil76_CheckedChanged);
            // 
            // eb_Random
            // 
            this.eb_Random.AutoSize = true;
            this.eb_Random.Location = new System.Drawing.Point(359, 539);
            this.eb_Random.Name = "eb_Random";
            this.eb_Random.Size = new System.Drawing.Size(65, 17);
            this.eb_Random.TabIndex = 8;
            this.eb_Random.Text = "Random";
            this.Tool_Tip.SetToolTip(this.eb_Random, "Randomly generate a list of nodes.");
            this.eb_Random.UseVisualStyleBackColor = true;
            this.eb_Random.CheckedChanged += new System.EventHandler(this.eb_Random_CheckedChanged);
            // 
            // nud_Number_of_Facilities
            // 
            this.nud_Number_of_Facilities.Location = new System.Drawing.Point(347, 487);
            this.nud_Number_of_Facilities.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Number_of_Facilities.Name = "nud_Number_of_Facilities";
            this.nud_Number_of_Facilities.Size = new System.Drawing.Size(77, 20);
            this.nud_Number_of_Facilities.TabIndex = 9;
            this.Tool_Tip.SetToolTip(this.nud_Number_of_Facilities, "Number of Facility nodes.");
            this.nud_Number_of_Facilities.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Number of Facilities (P) :";
            this.Tool_Tip.SetToolTip(this.label3, "Number of Facility nodes.");
            // 
            // btn_Restart
            // 
            this.btn_Restart.Enabled = false;
            this.btn_Restart.Location = new System.Drawing.Point(347, 455);
            this.btn_Restart.Name = "btn_Restart";
            this.btn_Restart.Size = new System.Drawing.Size(77, 26);
            this.btn_Restart.TabIndex = 14;
            this.btn_Restart.Text = "Restart";
            this.Tool_Tip.SetToolTip(this.btn_Restart, "Reset the current Generational algorithm and pause it.");
            this.btn_Restart.UseVisualStyleBackColor = true;
            this.btn_Restart.Click += new System.EventHandler(this.btn_Restart_Click);
            // 
            // pb_MapBox
            // 
            this.pb_MapBox.BackColor = System.Drawing.Color.Ivory;
            this.pb_MapBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_MapBox.Location = new System.Drawing.Point(12, 37);
            this.pb_MapBox.Name = "pb_MapBox";
            this.pb_MapBox.Size = new System.Drawing.Size(430, 410);
            this.pb_MapBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_MapBox.TabIndex = 15;
            this.pb_MapBox.TabStop = false;
            this.Tool_Tip.SetToolTip(this.pb_MapBox, "Where the visual representation of the nodes/facilities are shown.");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Cornsilk;
            this.label5.Location = new System.Drawing.Point(218, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Iteration:";
            this.Tool_Tip.SetToolTip(this.label5, "Current Iteration");
            // 
            // lb_Iteration_Count
            // 
            this.lb_Iteration_Count.AutoSize = true;
            this.lb_Iteration_Count.BackColor = System.Drawing.Color.Cornsilk;
            this.lb_Iteration_Count.Location = new System.Drawing.Point(263, 7);
            this.lb_Iteration_Count.Name = "lb_Iteration_Count";
            this.lb_Iteration_Count.Size = new System.Drawing.Size(13, 13);
            this.lb_Iteration_Count.TabIndex = 17;
            this.lb_Iteration_Count.Text = "_";
            // 
            // lb_Current_Solution
            // 
            this.lb_Current_Solution.AutoSize = true;
            this.lb_Current_Solution.BackColor = System.Drawing.Color.Cornsilk;
            this.lb_Current_Solution.Location = new System.Drawing.Point(429, 7);
            this.lb_Current_Solution.Name = "lb_Current_Solution";
            this.lb_Current_Solution.Size = new System.Drawing.Size(13, 13);
            this.lb_Current_Solution.TabIndex = 19;
            this.lb_Current_Solution.Text = "_";
            this.Tool_Tip.SetToolTip(this.lb_Current_Solution, "Finesse of the current solution");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Cornsilk;
            this.label8.Location = new System.Drawing.Point(316, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Current Best Solution:";
            // 
            // lb_Best_Solution
            // 
            this.lb_Best_Solution.AutoSize = true;
            this.lb_Best_Solution.BackColor = System.Drawing.Color.Cornsilk;
            this.lb_Best_Solution.Location = new System.Drawing.Point(614, 7);
            this.lb_Best_Solution.Name = "lb_Best_Solution";
            this.lb_Best_Solution.Size = new System.Drawing.Size(13, 13);
            this.lb_Best_Solution.TabIndex = 21;
            this.lb_Best_Solution.Text = "_";
            this.Tool_Tip.SetToolTip(this.lb_Best_Solution, "Finnese of the best solution");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Cornsilk;
            this.label10.Location = new System.Drawing.Point(539, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Best Solution";
            // 
            // nud_Pop_Count
            // 
            this.nud_Pop_Count.Location = new System.Drawing.Point(106, 505);
            this.nud_Pop_Count.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nud_Pop_Count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Pop_Count.Name = "nud_Pop_Count";
            this.nud_Pop_Count.Size = new System.Drawing.Size(72, 20);
            this.nud_Pop_Count.TabIndex = 22;
            this.Tool_Tip.SetToolTip(this.nud_Pop_Count, "How many set of nodes exists on one generation");
            this.nud_Pop_Count.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_Pop_Count.ValueChanged += new System.EventHandler(this.nud_Pop_Count_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 507);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Pop Count:";
            this.Tool_Tip.SetToolTip(this.label11, "How many set of nodes exists on one generation");
            // 
            // nud_Number_of_Nodes
            // 
            this.nud_Number_of_Nodes.Enabled = false;
            this.nud_Number_of_Nodes.Location = new System.Drawing.Point(347, 512);
            this.nud_Number_of_Nodes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Number_of_Nodes.Name = "nud_Number_of_Nodes";
            this.nud_Number_of_Nodes.Size = new System.Drawing.Size(77, 20);
            this.nud_Number_of_Nodes.TabIndex = 24;
            this.Tool_Tip.SetToolTip(this.nud_Number_of_Nodes, "Number of Nodes to generate when using \"Random\"");
            this.nud_Number_of_Nodes.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(203, 514);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Number of Nodes:";
            this.Tool_Tip.SetToolTip(this.label12, "Number of Nodes to generate when using \"Random\"");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 535);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Delay(ms):";
            this.Tool_Tip.SetToolTip(this.label6, "Delay between Processing generations");
            // 
            // nudDelay
            // 
            this.nudDelay.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudDelay.Location = new System.Drawing.Point(106, 533);
            this.nudDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudDelay.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(72, 20);
            this.nudDelay.TabIndex = 26;
            this.Tool_Tip.SetToolTip(this.nudDelay, "Delay between Processing generations\r\n");
            this.nudDelay.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudDelay.ValueChanged += new System.EventHandler(this.nudDelay_ValueChanged);
            // 
            // cbLogger
            // 
            this.cbLogger.AutoSize = true;
            this.cbLogger.Location = new System.Drawing.Point(15, 563);
            this.cbLogger.Name = "cbLogger";
            this.cbLogger.Size = new System.Drawing.Size(97, 17);
            this.cbLogger.TabIndex = 28;
            this.cbLogger.Text = "Create Log File";
            this.Tool_Tip.SetToolTip(this.cbLogger, "Create a Log .txt file at the root directory?\r\n");
            this.cbLogger.UseVisualStyleBackColor = true;
            this.cbLogger.CheckedChanged += new System.EventHandler(this.cbLogger_CheckedChanged);
            // 
            // cbKeepMap
            // 
            this.cbKeepMap.AutoSize = true;
            this.cbKeepMap.Location = new System.Drawing.Point(15, 587);
            this.cbKeepMap.Name = "cbKeepMap";
            this.cbKeepMap.Size = new System.Drawing.Size(80, 17);
            this.cbKeepMap.TabIndex = 29;
            this.cbKeepMap.Text = "Keep Maps";
            this.Tool_Tip.SetToolTip(this.cbKeepMap, "Keep all node maps generated? (Takes up some space)");
            this.cbKeepMap.UseVisualStyleBackColor = true;
            this.cbKeepMap.CheckedChanged += new System.EventHandler(this.cbKeepMap_CheckedChanged);
            // 
            // rtb_log
            // 
            this.rtb_log.BackColor = System.Drawing.Color.FloralWhite;
            this.rtb_log.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtb_log.Location = new System.Drawing.Point(452, 37);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.ReadOnly = true;
            this.rtb_log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtb_log.Size = new System.Drawing.Size(431, 564);
            this.rtb_log.TabIndex = 30;
            this.rtb_log.Text = "";
            this.Tool_Tip.SetToolTip(this.rtb_log, "Console for logging actions by the algorithm.");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Cornsilk;
            this.label9.Location = new System.Drawing.Point(99, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Status:";
            this.Tool_Tip.SetToolTip(this.label9, "Current Iteration");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 591);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Selection Range (Lower):";
            this.Tool_Tip.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // nud_SelectionDifference
            // 
            this.nud_SelectionDifference.Location = new System.Drawing.Point(339, 588);
            this.nud_SelectionDifference.Name = "nud_SelectionDifference";
            this.nud_SelectionDifference.Size = new System.Drawing.Size(85, 20);
            this.nud_SelectionDifference.TabIndex = 33;
            this.Tool_Tip.SetToolTip(this.nud_SelectionDifference, resources.GetString("nud_SelectionDifference.ToolTip"));
            this.nud_SelectionDifference.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 567);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Selection Range(Higher):";
            this.Tool_Tip.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
            // 
            // nud_SelectionDifferenceHigh
            // 
            this.nud_SelectionDifferenceHigh.Location = new System.Drawing.Point(338, 564);
            this.nud_SelectionDifferenceHigh.Name = "nud_SelectionDifferenceHigh";
            this.nud_SelectionDifferenceHigh.Size = new System.Drawing.Size(86, 20);
            this.nud_SelectionDifferenceHigh.TabIndex = 35;
            this.Tool_Tip.SetToolTip(this.nud_SelectionDifferenceHigh, resources.GetString("nud_SelectionDifferenceHigh.ToolTip"));
            this.nud_SelectionDifferenceHigh.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // delay_timer
            // 
            this.delay_timer.Interval = 500;
            this.delay_timer.Tick += new System.EventHandler(this.delay_timer_Tick);
            // 
            // lb_Status
            // 
            this.lb_Status.AutoSize = true;
            this.lb_Status.BackColor = System.Drawing.Color.Cornsilk;
            this.lb_Status.Location = new System.Drawing.Point(135, 8);
            this.lb_Status.Name = "lb_Status";
            this.lb_Status.Size = new System.Drawing.Size(24, 13);
            this.lb_Status.TabIndex = 32;
            this.lb_Status.Text = "Idle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(895, 615);
            this.Controls.Add(this.lb_Current_Solution);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lb_Status);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_Best_Solution);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lb_Iteration_Count);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nud_SelectionDifferenceHigh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nud_SelectionDifference);
            this.Controls.Add(this.rtb_log);
            this.Controls.Add(this.cbKeepMap);
            this.Controls.Add(this.cbLogger);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudDelay);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nud_Number_of_Nodes);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nud_Pop_Count);
            this.Controls.Add(this.pb_MapBox);
            this.Controls.Add(this.btn_Restart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nud_Number_of_Facilities);
            this.Controls.Add(this.eb_Random);
            this.Controls.Add(this.rb_eil76);
            this.Controls.Add(this.rb_eil51);
            this.Controls.Add(this.btn_Start_Stop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nud_Max_Iterations);
            this.Controls.Add(this.nud_Mutation_Rate);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Modelling";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Mutation_Rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Max_Iterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Number_of_Facilities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_MapBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Pop_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Number_of_Nodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SelectionDifference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SelectionDifferenceHigh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_Mutation_Rate;
        private System.Windows.Forms.NumericUpDown nud_Max_Iterations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Start_Stop;
        private System.Windows.Forms.RadioButton rb_eil51;
        private System.Windows.Forms.RadioButton rb_eil76;
        private System.Windows.Forms.RadioButton eb_Random;
        private System.Windows.Forms.NumericUpDown nud_Number_of_Facilities;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Restart;
        private System.Windows.Forms.PictureBox pb_MapBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_Iteration_Count;
        private System.Windows.Forms.Label lb_Current_Solution;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lb_Best_Solution;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nud_Pop_Count;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip Tool_Tip;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nud_Number_of_Nodes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.CheckBox cbLogger;
        private System.Windows.Forms.CheckBox cbKeepMap;
        private System.Windows.Forms.Timer delay_timer;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.Label lb_Status;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_SelectionDifference;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nud_SelectionDifferenceHigh;
    }
}

