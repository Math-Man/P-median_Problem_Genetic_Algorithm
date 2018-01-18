using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_Median_Problem
{
    static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /// <summary>
        /// Static method that Finds Distance between 2 given nodes
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        public static double Find_Distance(Node n1, Node n2)
        {
            return (Math.Sqrt(((n2.Pos_X - n1.Pos_X) * (n2.Pos_X - n1.Pos_X)) + ((n2.Pos_Y - n1.Pos_Y) * (n2.Pos_Y - n1.Pos_Y))));
        }

    }
}
