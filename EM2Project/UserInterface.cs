/* UserInterface.cs
 * Authors: Natasha Graham, Katherine Ventura, Benjamin Archibeque
 * EM2Project
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace EM2Project
{
    public partial class UserInterface : Form
    {
        YValues _ycurrent = new YValues(); //current values - initialized at t = 0
        YValues _ypast = new YValues(); //past values - initiaized at t = 0
        YValues _yfuture = new YValues(); // future values - initialized at t = 0
        int _numOfSteps = 0; //number of steps - initialized at 0
        const double _dx = 0.01; //step size, in meters
        const double _dt = _dx / _air; //time step, in seconds
        double _timeElapsed = 0; //the amount of time passed, in seconds

        //speeds, in m/s
        const int _diamond = (int) (_air / 2); //speed of light in diamond
        const int _air = 300000000; //speed of light in air
        const int _glass = (int) (_air / 1.5); //speed of light in glass
        const int _brett = 0; //speed of light in brett
        const int _water = (int) (_air / 1.3); //speed of light in water
        const int _mystery = (int) (_air / 1.2); //speed of light in mystery item

        int _current = _air; //current speed on right side

        //drawer of the lines
        private Graphics _graphics;

        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Draws the values to show the current set of values in a line. 
        /// </summary>
        /// <param name="g">The drawer</param>
        private void DrawIt(Graphics g)
        {
            _timeShown.Text = _timeElapsed.ToString("E03");

            Pen leftPen = new Pen(Brushes.Black, 5.0F);
            Pen rightPen = new Pen(Brushes.Blue, 5.0F);

            double heightDisplacement = this.Height / 2; // spacing from top
            double sizeMult = 250; // size multiplier

            double x1 = 0;
            double y1 = _ycurrent.Element(0);

            //Left Side
            for (int i = 0; i <= 254/2; i++)
            {
                g.DrawLine(leftPen, (float)(x1 * sizeMult), (float)(y1 * sizeMult + heightDisplacement), 
                    (float)((i*_dx) * sizeMult), (float)(_ycurrent[i] * sizeMult + heightDisplacement));

                x1 = (i * _dx);
                y1 = _ycurrent[i];
            }


            //right side
            for (int i = 254/2; i < 255; i++)
            {
                g.DrawLine(rightPen, (float)(x1 * sizeMult), (float)(y1 * sizeMult + heightDisplacement), 
                    (float)((i * _dx) * sizeMult), (float)(_ycurrent[i] * sizeMult + heightDisplacement));

                x1 = (i * _dx);
                y1 = _ycurrent[i];
            }

            leftPen.Dispose();
            rightPen.Dispose();
        }

        /// <summary>
        /// Occurs for each tick of the timer. Increases the time elapsed, the step number, 
        /// and moves the functions and creates a new future.
        /// </summary>
        private void TimeStep()
        {
            _timeElapsed += _dt;
            _ypast = _ycurrent;
            _ycurrent = _yfuture;
            _yfuture = new YValues(_numOfSteps, _ypast, _ycurrent, _current);
            _numOfSteps++;
        }

        /// <summary>
        /// Handles the event that the start button is pressed.
        /// Enables and disables buttons. Draws the graphic. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _startButton_Click(object sender, EventArgs e)
        {
            _graphics = this.CreateGraphics();
            _graphics.Clear(Color.Beige);
            DrawIt(_graphics);

            _timer.Enabled = true;
            _pauseButton.Enabled = true;
            _startButton.Enabled = false;
            _clearButton.Enabled = true;
        }

        /// <summary>
        /// Handles the event that the timer ticks.
        /// Clears the graphic, does a timestep, and draws the new graphic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            _graphics.Clear(Color.Beige);
            TimeStep();
            DrawIt(_graphics);
        }

        /// <summary>
        /// Pauses the timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _pauseButton_Click(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            _resumeButton.Enabled = true;
            _pauseButton.Enabled = false;
        }

        /// <summary>
        /// Resumes the timer. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _resumeButton_Click(object sender, EventArgs e)
        {
            _timer.Enabled = true;
            _pauseButton.Enabled = true;
            _resumeButton.Enabled = false;
        }

        /// <summary>
        /// Clears out the graphic and resets the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _clearButton_Click(object sender, EventArgs e)
        {
            _startButton.Enabled = true;
            _resumeButton.Enabled = false;
            _pauseButton.Enabled = false;
            _clearButton.Enabled = false;
            _timer.Enabled = false;
            _graphics.Clear(Color.Beige);
            _timeElapsed = 0;
            _timeShown.Text = _timeElapsed.ToString("E03");
            _graphics.Dispose();

            _ycurrent = new YValues();
            _ypast = new YValues();
            _yfuture = new YValues();
        }

        /// <summary>
        /// Changes the current medium, and resets the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _materialsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            _startButton.Enabled = true;
            _pauseButton.Enabled = false;
            _resumeButton.Enabled = false;
            _clearButton.Enabled = false;
            _timeElapsed = 0;
            _timeShown.Text = _timeElapsed.ToString("E03");

            if(_materialsList.SelectedIndex == 0)
            {
                _current = _glass;
            }
            else if(_materialsList.SelectedIndex == 1)
            {
                _current = _diamond;
            }
            else if(_materialsList.SelectedIndex == 2)
            {
                _current = _water;
            }
            else if(_materialsList.SelectedIndex == 3)
            {
                _current = _air;
            }
            else if(_materialsList.SelectedIndex == 4)
            {
                _current = _brett;
            }
            else if(_materialsList.SelectedIndex == 5)
            {
                _current = _mystery;
            }

            _ycurrent = new YValues();
            _ypast = new YValues();
            _yfuture = new YValues();
        }
    }
}