using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace math_game
{
    /// <summary>
    /// Interaction logic for scoreWindow.xaml
    /// </summary>
    public partial class scoreWindow : Window
    {
        #region Attributes
        /// <summary>
        /// Holds the players information
        /// </summary>
        private User _player;

        /// <summary>
        /// Stores the background music that plays
        /// </summary>
        private SoundPlayer bgm_scoreWindow;


        /// <summary>
        /// Holds the errorHandler class
        /// </summary>
        public errorHandler errorHandler;
        #endregion

        #region Methods
        /// <summary>
        /// Holds the User class that gets passed in
        /// </summary>
        public User Player
        {


            get
            {
                try
                {
                    return _player;

                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }
            set
            {
                try
                {
                    _player = value;

                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }

        }

        /// <summary>
        /// Displays the information from the User object
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods </exception>
        private void showStats()
        {
            try
            {
                lbl_playerName.Content = "Name: " + _player.Name;
                lbl_playerAge.Content = "Age: " + _player.Age;
                lbl_correctAns.Content = "Correct Answers: " + _player.correct;
                lbl_incorrectAns.Content = "Incorrect Answers: " + _player.wrong;
                lbl_time.Content = "Total Time: " + _player.TotalTime.ToString("ss") + " seconds";
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        #endregion

        public scoreWindow()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Class showStats and starts the music when the screen is active
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onOpen(object sender, EventArgs e)
        {

            try
            {
                showStats();
                bgm_scoreWindow = new SoundPlayer("bgm_scoreWindow.wav");
                bgm_scoreWindow.Play();
            }
            catch (Exception ex)
            {

                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the screen becomes background windows music stops playing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void on_deactivate(object sender, EventArgs e)
        {
            try
            {
                bgm_scoreWindow.Stop();
            }
            catch (Exception ex)
            {

                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
