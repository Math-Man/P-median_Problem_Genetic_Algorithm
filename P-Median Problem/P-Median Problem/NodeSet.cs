using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Median_Problem
{
    /// <summary>
    /// NodeSet class objects represents a single NodeSet used within the genetic Algorithm<para/>
    /// Every NodeSet is a list of nodes, the generational DNA revolves around the position of the facilities
    /// </summary>
    public class NodeSet
    {

        /// <summary>
        /// List of Nodes within this NodeSet
        /// </summary>
        public List<Node> Nodes { get; set; }
        /// <summary>
        /// List of nodes marked as facilities
        /// </summary>
        public List<Node> Facility_Nodes { get; set; }

        /// <summary>
        /// List of connections between nodes and their weight (distance * demand of the 1st node)
        /// </summary>
        public List<Tuple<Node, Node, double>> Connections { get; set; }

        /// <summary>
        /// Basic NodeSet Constructor. Creates a nodeset structure and connects demand nodes to facility nodes<para>Takes a list of Nodes as input</para>
        /// </summary>
        public NodeSet(List<Node> node_list)
        {
            Nodes = node_list;
            Facility_Nodes = new List<Node>();
            Connections = new List<Tuple<Node, Node, double>>();

            //Find Facility nodes and add them to the Facility_Nodes List.
            foreach (Node n in Nodes) if (n.Facility) Facility_Nodes.Add(n);

            //Create connections 
            Connect_Nodes();
        }

        /// <summary>
        /// Connects all Demand nodes to the closest facility node, remaps everytime this method is called. Also updates the facility nodes list
        /// </summary>
        public void Connect_Nodes()
        {
            Facility_Nodes = new List<Node>();

            foreach (Node n in Nodes) if (n.Facility) Facility_Nodes.Add(n);    //Go through nodes marked as facility add them to the facility nodes list

            Connections = new List<Tuple<Node, Node, double>>();
            //Go through nodes and find the closest facility node to that node
            foreach (Node n in Nodes)
            {
                if (!n.Facility)    //If n is not a facility
                {
                    Node closestFac = Find_Closest_Facility(n);    //Get the closest facility node
                    double Connection_Weight = (Program.Find_Distance(n, closestFac)) * n.Demand;
                    Connections.Add(Tuple.Create(n, closestFac, Connection_Weight));  //Create a new (Node,Node) tuple
                }
            }
        }

        /// <summary>
        /// Finds the closest Facility node to the given node n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private Node Find_Closest_Facility(Node N)
        {
            double minDistance = Double.MaxValue;
            Node ClosestFacilityNode = null;
            
            //Go throught every node
            foreach (Node facilitynode in Facility_Nodes)
            {   
                double distance = Program.Find_Distance(N, facilitynode);
                if (distance < minDistance)  //If the distance between Facility and the current Node is less than the best
                {
                    minDistance = distance;
                    ClosestFacilityNode = facilitynode;
                }
            }
            return ClosestFacilityNode;
        }


    }
}
