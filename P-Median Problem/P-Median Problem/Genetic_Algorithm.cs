using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Median_Problem
{
    /// <summary>
    /// Genetic Algorithm part, Manages the generational behaviour
    /// Keeps track of the fitness and the Units within a generation <para/>
    /// Unit lists represents the units within the generations <para/>
    /// Cross-Over is done between 2 units within the Current_Units
    /// </summary>
    public class Genetic_Algorithm
    {
        public int Iteration_Count { get; set; }    //Property, keeps track of the current iteration number
        public double Best_Fitness { get; set; }    //Property, Keeps track of the best fitness ever occured in any generation
        public NodeSet Best_Solution { get; set; }  //Property, Keeps track of the best solution with best fitness ever occured in any generation
        public NodeSet CurrentBest_Solution { get; set; }   //Property, Current best solution with best fitness in the current generation
        public double CurrentBest_Fitness { get; set; } //Property, Current best fitness in the current generation
        public List<NodeSet> Current_NodeSets { get; set; } //Property, Current population
        public List<NodeSet> Next_NodeSets { get; set; }    //Property, Next population, which will replace the current population
        public Logger logger { get; set; }  //Property, Generic logger object.

        //Algoritmic parameters (values that are taken from outside)
        public double MutationRate { get; set; }    //Parameter, % chance of mutation
        public int Population_Count { get; set; }   //Parameter, Population count represents the number of nodesets within a generation
        public int Maximum_Iterations { get; set; } //Parameter, Iteration count, which the program will terminate after.
        public int FacilityCount { get; set; }  //Parameter, Number of facilities within a nodeset
        public int SelectionRangeDifferenceLow { get; set; } //Parameter, Percantage difference the selection will happen
        public int SelectionRangeDifferenceHigh { get; set; } //Parameter, Percantage difference the selection will happen

        /// <summary>
        /// Basic Constructor, takes the list of nodes as parameter
        /// </summary>
        public Genetic_Algorithm(List<Node> Nodes, decimal mutationRate, decimal popcount, decimal success_threshold, decimal maxIterations, decimal FacilityCo, decimal selectionRangeD, decimal selectionRangeDHigh)
        {
            //Set primary values (Conversion from Decimal to Double or Int is done here)
            MutationRate = System.Convert.ToDouble(mutationRate);
            Population_Count = System.Convert.ToInt32(popcount);
            Maximum_Iterations = System.Convert.ToInt32(maxIterations);
            FacilityCount = System.Convert.ToInt32(FacilityCo);
            SelectionRangeDifferenceLow = System.Convert.ToInt32(selectionRangeD);
            SelectionRangeDifferenceHigh = System.Convert.ToInt32(selectionRangeDHigh);
            //Select facilities randomly for the first generation, create a nodelist with randomly selected facilities
            Current_NodeSets = new List<NodeSet>();
            Next_NodeSets = new List<NodeSet>();

            logger.AddLine("Initilizing with " + Nodes.Count + " nodes, " + FacilityCount + " facilities.");

            Init(Nodes);
        }

        /// <summary>
        /// Basic Constructor with a built in logger
        /// </summary>
        public Genetic_Algorithm(List<Node> Nodes, decimal mutationRate, decimal popcount, decimal maxIterations, decimal FacilityCo, decimal selectionRangeD, decimal selectionRangeDHigh, Logger logger)
        {
            //Set primary values (Conversion from Decimal to Double or Int is done here)
            MutationRate = System.Convert.ToDouble(mutationRate);
            Population_Count = System.Convert.ToInt32(popcount);
            Maximum_Iterations = System.Convert.ToInt32(maxIterations);
            FacilityCount = System.Convert.ToInt32(FacilityCo);
            SelectionRangeDifferenceLow = System.Convert.ToInt32(selectionRangeD);
            SelectionRangeDifferenceHigh = System.Convert.ToInt32(selectionRangeDHigh);

            this.logger = logger;

            //Select facilities randomly for the first generation, create a nodelist with randomly selected facilities
            Current_NodeSets = new List<NodeSet>();
            Next_NodeSets = new List<NodeSet>();

            logger.AddLine("Initilizing with " + Nodes.Count + " nodes, " + FacilityCount + " facilities.");

            Init(Nodes);
        }


        /// <summary>
        ///Initilizes the object by creating a completly random first generation, takes in the nodeset and randomly assings facilities to the nodes and adds it to the Current_NodeSets
        /// </summary>
        private void Init(List<Node> nodes)
        {
            Iteration_Count = 0;    //Set iteration count to 0
            Random rnd = new Random();

            //Create new nodesets for the given population count
            for (int j = 0; j < Population_Count; j++)
            {
                //This is done to prevent index-collsion
                List<Node> t_nodes = new List<Node>(nodes);


                //Randomly pick Facility Nodes
                for (int i = 0; i < FacilityCount; i++)
                {
                    //Check if the selected node is already a facility
                    int selectionIndex = rnd.Next(t_nodes.Count);
                    if (t_nodes[selectionIndex].Facility)
                    {
                        while (t_nodes[selectionIndex].Facility)  //Keep changing selection index until its not a facility
                        {
                            selectionIndex = rnd.Next(t_nodes.Count);
                        }
                    }
                    t_nodes[selectionIndex].Facility = true;   //Make the randomly picked  node facility
                }
                //Create the nodeSet
                NodeSet set = new NodeSet(t_nodes);

                //Reset node list
                foreach (Node n in t_nodes) { if (n.Facility) n.Facility = false; }

                //Add a new random nodeset to the current node sets for the number of population count
                Current_NodeSets.Add(set);
            }

            double current_best_fitness = Double.MaxValue;
            //Calculate fitness for the current nodesets and select the best fitness and set the value
            foreach (NodeSet set in Current_NodeSets)
            {
                //If the fitness value that is found is considered better(lower) change the local value
                double calculatedFitness = Calculate_Fitness(set);
                if (calculatedFitness < current_best_fitness)
                {
                    current_best_fitness = calculatedFitness;
                    Best_Solution = set;
                }
            }

            //Change the global best fitness value
            CurrentBest_Fitness = current_best_fitness;
            Best_Fitness = current_best_fitness;

        }

        /// <summary>
        ///Calculate fitness of a given nodeset ( for all nodes in a nodeset: sum of (distance_between_facility_node * demand))
        /// <para/>Returns the fitness of the nodeset, Low values are better in terms of fitness
        /// </summary>
        private double Calculate_Fitness(NodeSet nodeset)
        {
            double fitness = 0;
            //Go through nodes in a nodeset and find weight of connections
            foreach (Tuple<Node, Node, double> tup in nodeset.Connections)
            {
                fitness += (tup.Item3); // Third item is the weight of the connection
            }
            return fitness;
        }

        /// <summary>
        ///Process the current generation, Go through Every Unit in the generation and calculate their fitness, Create a mating pool and Do cross-over between the selected parents, mutate and create the next generation
        /// </summary>
        public bool Process_Current_Generation()
        {

            Random rnd = new Random();
            //check if at Maximum_Iterations cap
            if (Iteration_Count >= Maximum_Iterations) { return false; }

            logger.AddLine("Iteration: " + (Iteration_Count+1) + " NodeCount: " + Current_NodeSets.Count + " FacilityCount: " + FacilityCount + " BestFitness: " + CurrentBest_Fitness);

            //Create mating pool
            #region MatingPool Creation (Selection)
            //Tuple<NodeSet, double> Nodeset and its fitness stored like this
            List<Tuple<NodeSet, double>> fitnessSet = new List<Tuple<NodeSet, double>>();

            //Mating pool, stores parents
            List<Tuple<NodeSet, NodeSet>> Mating_Pool = new List<Tuple<NodeSet, NodeSet>>();

            //Fill the set pool
            foreach (NodeSet set in Current_NodeSets)
            {
                Tuple<NodeSet, double> t = new Tuple<NodeSet, double>(set, Calculate_Fitness(set));
                fitnessSet.Add(t);
            }

            //Create a mating pool with selection weights depending on the fitness using the weighted selecting with cumilitive disturbution function
            for (int i = 0; i < Population_Count; i++)
            {
                //Select parents
                //Randomly select a set from the current fitnessset, representing parents
                Tuple<NodeSet, double> Parent1 = fitnessSet[rnd.Next(0, fitnessSet.Count)];
                Tuple<NodeSet, double> Parent2 = fitnessSet[rnd.Next(0, fitnessSet.Count)];


                //Do a random selection with a chance to switch the parent to a better candidate, this chance depends on the ration of the fitness difference between current parent and the candidate parent
                //Do a random amount of checks on the fitness set (one third of the population count) 
                //A parent will only be replaced by a parent with similar aptitude, this threshold here is set as 75%
                for (int j = 0; j < rnd.Next((Population_Count / 3)); j++)
                {
                    //Select a random node
                    int selectionIndex = rnd.Next(0, fitnessSet.Count);
                    double selectionFitness = Calculate_Fitness(fitnessSet[selectionIndex].Item1);  //Fitness of the randomly selected candidate

                    double percantageDifference = (Calculate_Fitness(Parent1.Item1) / selectionFitness) * 100;
                    //logger.AddLine("DEBUG: " + percantageDifference + "%");
                    if (percantageDifference > 100 - SelectionRangeDifferenceLow && percantageDifference < 100 + SelectionRangeDifferenceHigh)
                    {
                        //logger.AddLine("DEBUG: " + "CHANGING");
                        Parent1 = fitnessSet[selectionIndex];
                    }
                }

                for (int j = 0; j < rnd.Next((Population_Count / 3)); j++)
                {
                    //Select a random node
                    int selectionIndex = rnd.Next(0, fitnessSet.Count);
                    double selectionFitness = Calculate_Fitness(fitnessSet[selectionIndex].Item1);  //Fitness of the randomly selected candidate

                    double percantageDifference = (Calculate_Fitness(Parent2.Item1) / selectionFitness) * 100;
                    //logger.AddLine("DEBUG: " + percantageDifference + "%");
                    if (percantageDifference > 100 - SelectionRangeDifferenceLow && percantageDifference < 100 + SelectionRangeDifferenceHigh)
                    {
                        //logger.AddLine("DEBUG: " + "CHANGING");
                        Parent2 = fitnessSet[selectionIndex];
                    }
                }
                //Add parents to the mating pool
                Mating_Pool.Add(new Tuple<NodeSet, NodeSet>(Parent1.Item1, Parent2.Item1));
            }
            #endregion

            //Foreach parent set in the mating pool
            foreach (Tuple<NodeSet, NodeSet> t in Mating_Pool)
            {

                /*GIVES ERROR BECOUSE PARENTS NODES LISTS DOESNT HAVE ANY FACILITIES BUT FACILITY LISTS HAS FACILITIES, WORKAROUND IS FOLLOWING*/
                foreach (Node n in t.Item1.Facility_Nodes)
                {
                    foreach (Node m in t.Item1.Nodes)
                    {
                        if (n.Pos_X == m.Pos_X && n.Pos_Y == m.Pos_Y)
                        {
                            m.Facility = true;
                        }
                    }
                }
                foreach (Node n in t.Item2.Facility_Nodes)
                {
                    foreach (Node m in t.Item2.Nodes)
                    {
                        if (n.Pos_X == m.Pos_X && n.Pos_Y == m.Pos_Y)
                        {
                            m.Facility = true;
                        }
                    }
                }

                NodeSet child = CrossOver(t.Item1, t.Item2);
                //If passes the mutation chance check, mutate the child, second and third mutations can occur if pases the formula (sqrt(MutationRate)/2)
                //This multiple mutation formula makes mutation to be more "decisive" on lower mutation rates
                if (rnd.NextDouble() < MutationRate)
                {
                    child = Mutate(child);

                    //Method for deciding multiple mutation chances
                    double altRate = Math.Sqrt(MutationRate)/2;
                    while (rnd.NextDouble() < altRate)
                    {
                        child = Mutate(child);
                        altRate = Math.Sqrt(altRate) / 2;
                    }
                }
                //Add the child to the future generation
                Next_NodeSets.Add(child);
            }

            //Update best solution and current best solution
            NodeSet q = Find_Best_Solution(Next_NodeSets);

            CurrentBest_Solution = q;
            CurrentBest_Fitness = Calculate_Fitness(q);
            if (Calculate_Fitness(q) < Best_Fitness)//Check for the best solution replace it if one is found
            {
                Best_Fitness = Calculate_Fitness(q);
                Best_Solution = q;
            }

            Iteration_Count++;  //Increment iteration
            return true;    //Return true if the generation was processed succesfully
        }

        /// <summary>
        /// Switches to the next generation, replacing the current generation with the next generation <para/>
        /// Clears the current nodeset, puts the next generation's nodeset into it and clears the next generation's nodeset
        /// </summary>
        public void Next_Generation()
        {
            Current_NodeSets.Clear();
            Current_NodeSets.AddRange(Next_NodeSets);
            Next_NodeSets.Clear();
        }

        /// <summary>
        /// Cross-Over between 2 Nodesets, generating a brand new unit relative to the parent Nodeset
        /// Position of the child's facilities are one or the other between 2 units
        /// </summary>
        private NodeSet CrossOver(NodeSet set1, NodeSet set2)
        {
            Random rnd = new Random();
            int changeCounter = 0;

            NodeSet child;
            List<Node> child_nodes = set1.Nodes;    //Create the child node list and flush its facility nodes
            foreach (Node n in child_nodes)
            {
                if (n.Facility) n.Facility = false;
            }

            //Create a list of all facilities between 2 parents
            List<Node> ChildFacilityNodes = new List<Node>();
            ChildFacilityNodes.AddRange(set1.Facility_Nodes);
            ChildFacilityNodes.AddRange(set2.Facility_Nodes);

            //Select facility nodes
            for (int i = 0; i < FacilityCount; i++)
            {
                bool selected = false;
                //Select a random node from the list and make it a facility 
                while (!selected)    //Stays in the while loop as long as the selected facility is a facility (makes sure always facilities by the facility count are selected)
                {
                    //Select a random node from parent's combined faciltiy nodes list
                    Node selected_node = ChildFacilityNodes[rnd.Next(ChildFacilityNodes.Count)];

                    //Find selected facility in the child nodes
                    foreach (Node ns in child_nodes)
                    {
                        if (ns.Pos_X == selected_node.Pos_X && ns.Pos_Y == selected_node.Pos_Y)
                        {
                            //Make the randomly selected parent facility node, child's facility node
                            if (ns.Facility == false)    //check if this randomly selected node was already a facility
                            {
                                ns.Facility = true;//If it is not a facility select it and escape the while loop
                                selected = true;
                                changeCounter++;
                            }
                        }
                    }
                }
            }

            child = new NodeSet(child_nodes);
            child.Connect_Nodes();

            logger.AddLine("   ↳ CrossOver Between: " + Math.Floor(Calculate_Fitness(set1)) + " | " + Math.Floor(Calculate_Fitness(set2)) + " | Child: " + Math.Floor(Calculate_Fitness(child)));
            return child;

        }
        /// <summary>
        /// Mutate a NodeSet, Returns the mutated nodeset
        /// </summary>
        private NodeSet Mutate(NodeSet set)
        {
            Random rnd = new Random();

            List<Node> mutationNodes = set.Nodes;
            List<Node> facilities = set.Facility_Nodes;

            //Select a random facility from the facilities and disable its facility property
            int facInd = rnd.Next(0, facilities.Count);
            facilities[facInd].Facility = false;

            //Find the same node in mutationNodes and disable it
            foreach (Node n in mutationNodes)
            {
                if (n.Pos_X == facilities[facInd].Pos_X && n.Pos_Y == facilities[facInd].Pos_Y)
                {
                    n.Facility = false;
                    break;
                }
            }

            //Find a non-facility node in mutationNodes and make it a facility, make sure its not a facility
            bool picked = false;
            int ind = -9999;//temporary value assignment, has no meaning
            while (!picked)
            {
                ind = rnd.Next(0, mutationNodes.Count);
                if (mutationNodes[ind].Facility == false)
                {
                    mutationNodes[ind].Facility = true;
                    picked = true;
                }
            }
            //Build the nodeset with mutationNodes
            NodeSet MutatedChild = new NodeSet(mutationNodes);
            logger.AddLine("      ↳ Mutation: " + Math.Floor(Calculate_Fitness(set)) + " -> " + Math.Floor(Calculate_Fitness(MutatedChild)) + " | (x,y) => (" + facilities[facInd].Pos_X + "," + facilities[facInd].Pos_Y + ") -> (" + mutationNodes[ind].Pos_X + "," + mutationNodes[ind].Pos_Y + ")");
            return MutatedChild;
        }


        /// <summary>
        /// Finds the nodeset with the best fitness in a given list
        /// </summary>
        /// <param name="Set_List"></param>
        /// <returns></returns>
        private NodeSet Find_Best_Solution(List<NodeSet> Set_List)
        {
            double best = double.MaxValue;
            NodeSet bestSolution = null;

            foreach (NodeSet set in Set_List)
            {
                double val = Calculate_Fitness(set);
                if (val < best)
                {
                    best = val;
                    bestSolution = set;
                }
            }
            return bestSolution;
        }


    }
}
