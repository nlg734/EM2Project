/* YValues.cs
 * Authors: Natasha Graham, Katherine Ventura, Benjamin Archibeque
 * EM2Project
 */

using System;

namespace EM2Project
{
    public class YValues
    {
        private double[] values = new double[255]; //values of each point on line
        const int c1 = 300000000; //speed of wave (m/s)
        const double dx = 0.01; //displacement of x (m)
        const double dt = dx / c1; //time displacement (s)
        const double x0 = 1; //initial x - start of pulse (m)
        const int k = 1000; //determines width of guassian envelope (m^-2)
        const double r1 = c1 * dt / dx; //constant used in algorithm - unitless

        /// <summary>
        /// Initializes a set of values at the time = 0
        /// </summary>
        public YValues()
        {
            //fixed endpoints
            values[0] = 0;
            values[254] = 0;

            for (int i = 1; i < values.Length - 1; i++)
            {
                values[i] = (-.666F * Math.Exp(-k * ((i * dx) - x0) * ((i * dx) - x0)));
            }
        }

        /// <summary>
        /// Initializes values with previous and current values at n*dt sec
        /// </summary>
        /// <param name="n">number of steps passed</param>
        /// <param name="past">past values</param>
        /// <param name="current">current values</param>
        /// <param name="cblue">speed through current medium</param>
        public YValues(int n, YValues past, YValues current, int cblue)
        {
            values[0] = 0;
            values[254] = 0;

            double r2 = cblue * dt / dx;

            for (int i = 1; i < values.Length / 2; i++)
            {
                values[i] = 2*(1 - (r1 * r1))*current.Element(i) - past.Element(i) + 
                    r1*r1*(current.Element(i + 1) + current.Element(i-1));
            }
            for(int i = values.Length / 2; i < values.Length - 1; i++)
            {
                values[i] = 2 * (1 - (r2 * r2)) * current.Element(i) - past.Element(i) +
                    r2 * r2 * (current.Element(i + 1) + current.Element(i - 1));
            }
        }

        /// <summary>
        /// returns the element at loc i
        /// </summary>
        /// <param name="i">location of element</param>
        /// <returns>element</returns>
        public double Element(int i)
        {
            return values[i];
        }

        public Double this[Int32 i]
        {
            get
            {
                return values[i];
            }
        }
    }
}
