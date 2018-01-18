using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Median_Problem
{
    /// <summary>
    /// Node object represents the demand nodes
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Position X of this Node
        /// </summary>
        public int Pos_X { get; set; }
        /// <summary>
        /// Position Y of this node
        /// </summary>
        public int Pos_Y { get; set; }
        /// <summary>
        /// Demand of This Node
        /// </summary>
        public int Demand { get; set; }
        /// <summary>
        /// Does this Node contain a facility
        /// </summary>
        public bool Facility { get; set; }

        /// <summary>
        /// Nodes this node is physically connected to in terms of Demand/Facility 
        /// </summary>
        public List<Node> ConnectedNodes { get; set; }

        /// <summary>
        /// Basic Constructor, takes in Position and demand as parameters
        /// </summary>
        public Node(int x, int y, int demand)
        {
            ConnectedNodes = new List<Node>();

            this.Pos_X = x;
            this.Pos_Y = y;
            this.Demand = demand;
        }

    }
}
