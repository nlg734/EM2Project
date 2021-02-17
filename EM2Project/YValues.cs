/* YValues.cs
 * Authors: Natasha Graham, Katherine Ventura, Benjamin Archibeque
 * EM2Project
 */

using System;

namespace EM2Project
{
    public class YValues
    {
        private readonly double[] _values = new double[255]; //values of each point on line
        const int _c1 = 300000000; //speed of wave (m/s)
        const double _dx = 0.01; //displacement of x (m)
        const double _dt = _dx / _c1; //time displacement (s)
        const double _x0 = 1; //initial x - start of pulse (m)
        const int _widthDeterminer = 100; //determines width of guassian envelope (m^-2)
        const double _r1 = _c1 * _dt / _dx; //constant used in algorithm - unitless

        /// <summary>
        /// Initializes a set of values at the time = 0
        /// </summary>
        public YValues()
        {
            //fixed endpoints
            _values[0] = 0;
            _values[254] = 0;

            for (int i = 1; i < _values.Length - 1; i++)
            {
                _values[i] = (-.666 * Math.Exp(-_widthDeterminer * ((i * _dx) - _x0) * ((i * _dx) - _x0)));
            }
        }

        /// <summary>
        /// Initializes values with previous and current values at n*dt sec
        /// </summary>
        /// <param name="n">number of steps passed</param>
        /// <param name="past">past values</param>
        /// <param name="current">current values</param>
        /// <param name="cblue">speed through current medium</param>
        public YValues(YValues past, YValues current, int cblue)
        {
            _values[0] = 0;
            _values[254] = 0;

            double r2 = cblue * _dt / _dx;

            for (int i = 1; i < _values.Length / 2; i++)
            {
                _values[i] = 2*(1 - (_r1 * _r1))*current.Element(i) - past.Element(i) + 
                    _r1*_r1*(current.Element(i + 1) + current.Element(i-1));
            }
            for(int i = _values.Length / 2; i < _values.Length - 1; i++)
            {
                _values[i] = 2 * (1 - (r2 * r2)) * current.Element(i) - past.Element(i) +
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
            return _values[i];
        }

        public Double this[Int32 i]
        {
            get
            {
                return _values[i];
            }
        }
    }
}