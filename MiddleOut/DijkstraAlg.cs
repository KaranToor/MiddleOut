﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleOut
{
    public class DijkstraAlg
    {
        private List<Location> myLocations;
        private List<Street> myStreets;
        public List<Street> output; //public for unit testing.

        public DijkstraAlg(List<Location> theLocs, List<Street> theSts)
        {
            myLocations = theLocs;
            myStreets = theSts;
        }

        /// <summary>
        /// Finds the shortest path between two locations! AWESOME!
        /// @Author Karanbir 
        /// </summary>
        /// <param name="theStart">The beginning location.</param>
        /// <param name="theEnd">The ending location.</param>
        /// <returns>A list of streets to draw for the shortest path.</returns>
        public List<Street> Dijkstra(Location theStart, Location theEnd)
        {
            if (theStart.Equals(theEnd))
            {
                return null;
            }

            List<Street> shortestPath = new List<Street>();
            Dictionary<Location, int> buildPaths = new Dictionary<Location, int>();
            Dictionary<Location, Location> previousSave = new Dictionary<Location, Location>();
            List<Location> unvisited = new List<Location>();

            buildPaths.Add(theStart, 0); // 0 for start point 

            // Initialize 
            foreach (Location loc in myLocations)
            {
                if (!loc.Equals(theStart))
                {
                    buildPaths.Add(loc, 100000); // 100000 means infinity
                }
                unvisited.Add(loc);
            }

            while (unvisited.Count != 0)
            {
                Location currentLoc = findMin(buildPaths, unvisited);
                unvisited.Remove(currentLoc);
                if (currentLoc.Equals(theEnd))
                {
                    break;
                }

                List<Location> neighbors = getNeighbors(currentLoc);
                foreach (Location loc in neighbors)
                {
                    int currentLocInt;
                    int neighborInt;
                    if (findStreet(currentLoc, loc) != null)
                    {
                        int alternativeInt = findStreet(currentLoc, loc).myWeight;
                        buildPaths.TryGetValue(currentLoc, out currentLocInt);
                        buildPaths.TryGetValue(loc, out neighborInt);
                        if (((alternativeInt + currentLocInt) < neighborInt))
                        {
                            if (buildPaths.ContainsKey(loc))
                            {
                                buildPaths.Remove(loc);
                            }
                            if (previousSave.ContainsKey(loc))
                            {
                                previousSave.Remove(loc);
                            }
                            buildPaths.Add(loc, (alternativeInt + currentLocInt));
                            previousSave.Add(loc, currentLoc);
                        }
                    }
                }
            }
            Location retrackLoc;
            Location firstLoc = theEnd;
            while (firstLoc != null && previousSave.TryGetValue(firstLoc, out retrackLoc))
            {
                shortestPath.Add(findStreet(retrackLoc, firstLoc));
                firstLoc = retrackLoc;
            }
            output = shortestPath;
            return shortestPath;
        }

        /// <summary>
        /// Finds the street based on two locations. 
        /// </summary>
        /// <param name="theA">The first location.</param>
        /// <param name="theB">The second location.</param>
        /// <returns>The street that links these two locations, otherwise null.</returns>
        public Street findStreet(Location theA, Location theB)
        {
            foreach (Street st in myStreets)
            {
                if ((st.myA.Equals(theA) || st.myB.Equals(theA)) &&
                    (st.myA.Equals(theB) || st.myB.Equals(theB)))
                {
                    return st;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds the minimum value location in the given dictinoary. Otherwise returns the first 
        /// value in the dictionary if it is unvisited. 
        /// </summary>
        /// <param name="theDic">The dictionary with values.</param>
        /// <param name="theUnvisited">The list of univisited locations.</param>
        /// <returns>The location with the lowest distance.</returns>
        public Location findMin(Dictionary<Location, int> theDic, List<Location> theUnvisited)
        {
            Location toReturn = null;
            foreach (Location loc in theDic.Keys)
            {
                if (toReturn == null && theUnvisited.Contains(loc))
                {
                    toReturn = loc;
                }
                else if (theUnvisited.Contains(loc))
                {
                    int newLocInt;
                    int toReturnInt;
                    theDic.TryGetValue(loc, out newLocInt);
                    theDic.TryGetValue(toReturn, out toReturnInt);
                    if (newLocInt < toReturnInt && newLocInt >= 0 && theUnvisited.Contains(loc))
                    {
                        toReturn = loc;
                    }
                }
            }
            theUnvisited.Remove(toReturn);
            return toReturn;
        }

        /// <summary>
        /// Gets the neighbors of the given location. 
        /// </summary>
        /// <param name="theStart">The location to find neighbors of.</param>
        /// <returns>Returns a list of location neighbors not including the location passed in.</returns>
        public List<Location> getNeighbors(Location theStart)
        {
            List<Location> neighbors = new List<Location>();
            for (int i = 0; i < myStreets.Count; i++)
            {
                Street temp = myStreets[i];
                if (temp.myA.Equals(theStart))
                {
                    neighbors.Add(temp.myB);
                }
                else if (temp.myB.Equals(theStart))
                {
                    neighbors.Add(temp.myA);
                }
            }
            return neighbors;
        }

        public string toString()
        {
            string temp = "";
            foreach (Street st in output)
            {
                temp = temp + " " + st.myA.myX + " " + st.myA.myY + " " + st.myB.myX + " " + st.myB.myY + "\n";
            }
            return temp;
        }
    }
}
