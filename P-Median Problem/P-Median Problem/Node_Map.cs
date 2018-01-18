using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace P_Median_Problem
{
    /// <summary>
    /// Creates a bmp file of the given node list, Draws Nodes and paths between those nodes alongside the cost of the connection <para/>
    /// bmp File is always 720x720
    /// </summary>
    public static class Node_Map
    {
      
        /// <summary>
        /// Create a bitmap from the given NodeSet
        /// </summary>
        /// <param name="u"></param>
        public static Bitmap Generate_Bitmap(NodeSet u, string tag, string mark)
        {
            Bitmap bmp = new Bitmap(720, 720);
            Graphics g = Graphics.FromImage(bmp);

            Brush bBackground = new SolidBrush(ColorTranslator.FromHtml("#000000"));
            Brush bFacility = new SolidBrush(ColorTranslator.FromHtml("#ff0000"));
            Brush bNode = new SolidBrush(ColorTranslator.FromHtml("#fff0ff"));
            Pen bPath = new Pen(ColorTranslator.FromHtml("#ffff00"));
            Brush brPath_String = new SolidBrush(ColorTranslator.FromHtml("#ffff00"));

            //Paint background black
            g.FillRectangle(bBackground, 0, 0, 860, 820);

            //Create Lines between connected nodes
            foreach (Tuple<Node, Node, double> t in u.Connections)
            {
                g.DrawLine(bPath, t.Item1.Pos_X * 9, t.Item1.Pos_Y * 9, t.Item2.Pos_X * 9, t.Item2.Pos_Y * 9);

                //NODE DEMAND TEXT
                //Draw a string on top of the line, indicating the weight of that line
                Font DF = new Font("Arial", 9);
                Point DP = new Point(- 6 +t.Item1.Pos_X* 9, t.Item1.Pos_Y* 9);  //Finds mid-point

                // Draw string to screen.
                g.DrawString((t.Item1.Demand) + "", DF, bNode, DP);

                //LINE WEIGHT TEXT
                //Draw a string on top of the line, indicating the weight of that line
                Font df = new Font("Arial", 9); 
                Point dp = new Point( -10 + (((t.Item1.Pos_X * 9) + (t.Item2.Pos_X * 9))/2) , -3 + (((t.Item1.Pos_Y * 9) + (t.Item2.Pos_Y * 9)) / 2));  //Finds mid-point

                // Draw string to screen.
                g.DrawString(Math.Floor(t.Item3)+"", df, brPath_String, dp);
            }

            //The positional values are multiplied by 10 to fit them into the bitmap
            foreach (Node n in u.Nodes)
            {
                //If the node is a facility color it accordingly
                if (!n.Facility)
                {
                    g.FillEllipse(bNode, (n.Pos_X * 9) - 2, (n.Pos_Y * 9) - 2, 3, 3);
                }
                else
                {
                    foreach (Node m in u.Facility_Nodes)
                    {
                        if (m.Pos_X == n.Pos_X && m.Pos_Y == n.Pos_Y)
                        {
                            g.FillEllipse(bFacility, (n.Pos_X * 9) - 2, (n.Pos_Y * 9) - 2, 3, 3);
                            break;
                        }
                    }
                }
            }

            //Draw the "mark" string to top left
            Font drawFont = new Font("Arial", 16);
            PointF drawPoint = new PointF(20.0F, 20.0F);
            // Draw string to screen.
            g.DrawString(mark, drawFont, bNode, drawPoint);

            bmp.Save("out" + tag + ".png", System.Drawing.Imaging.ImageFormat.Png);
            return bmp;
        }

      

    }
}
