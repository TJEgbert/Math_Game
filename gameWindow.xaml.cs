using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
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

namespace math_game
{
    /// <summary>
    /// Interaction logic for gameWindow.xaml
    /// </summary>
    public partial class gameWindow : Window
    {

        #region Attributes

        /// <summary>
        /// The number of question user has done
        /// </summary>
        private int _questionCount;

        /// <summary>
        /// Keeps track if the game has started of not
        /// </summary>
        private bool _gameStarted;

        /// <summary>
        /// The game class that will run the business logic of the game
        /// </summary>
        private game gameLogic;

        /// <summary>
        /// Holds the players information
        /// </summary>
        private User _player;

        /// <summary>
        /// When the user started the game
        /// </summary>
        private DateTime startTime;

        /// <summary>
        /// When the user ends the game
        /// </summary>
        private DateTime endTime;

        /// <summary>
        /// Stores the background music that plays
        /// </summary>
        private SoundPlayer bgm_gameWindow;


        /// <summary>
        /// Setting up class for scoreWindow
        /// </summary>
        public scoreWindow scoreWindowForm;

        /// <summary>
        /// The radio button that was clicked in MainWindow for the game type
        /// </summary>
        public RadioButton gameType;

        /// <summary>
        /// Handles the errors from the exception
        /// </summary>
        public errorHandler errorHandler;

        /// <summary>
        /// Holds the mainWindowForm to pass to scoreWindow
        /// </summary>
        public MainWindow mainWindowForm;

        /// <summary>
        /// Keeps track of how longer the user has been playing
        /// </summary>
        private DispatcherTimer gameTimer;

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
        /// Updates lbl_timer every tick of the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void updateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                lbl_timer.Content = " " + DateTime.Now.Subtract(startTime).ToString("ss");
            }
            catch (Exception ex)
            {

                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
    
        }

        /// <summary>
        /// When gameWindow becomes active it resets it to the baseState
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods </exception>
        private void startState()
        {

            try
            {
                // Sets the buttons to right visibility
                cmd_submit.Visibility = Visibility.Hidden;
                cmd_gameStart.Visibility = Visibility.Visible;

                // Sets up the timer
                gameTimer = new DispatcherTimer();
                gameTimer.Interval = TimeSpan.FromSeconds(1);
                gameTimer.Tick += new EventHandler(updateTimer_Tick);
                scoreWindowForm = new scoreWindow();

                // Updates the UI to start state
                this.Title = gameType.Content.ToString() + " Game";
                gameLogic.GameType = gameType.Content.ToString();
                lbl_gameWindow.Content = string.Empty;
                lbl_timer.Content = " 00";
                lbl_errorInput.Content = string.Empty;
                lbl_answerStatus.Content = string.Empty;

                // Update attributes
                _questionCount = 0;
                _gameStarted = false;


            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        #endregion


        public gameWindow()
        {
            InitializeComponent();
            gameLogic = new game();
        }

        /// <summary>
        /// Passes the gameType to the gameLogic and has gameLogic generate the first question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_gameStart_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if(!_gameStarted)
                {
                    // Updates buttons visibility
                    cmd_gameStart.Visibility = Visibility.Collapsed;
                    cmd_submit.Visibility = Visibility.Visible;

                    // Gets the question from gameLogic object
                    lbl_gameWindow.Content = gameLogic.question();

                    // Starts timer
                    startTime = DateTime.Now;

                    // Update attributes
                    gameTimer.Start();
                    _gameStarted = true;

                    // Sets the focus to the text box
                    txt_answer.Focus();
                }

            }
            catch (Exception ex)
            {

                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Calls gameLogic class the check the players answer is correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_gameStarted)
                {
                    if (txt_answer.Text != string.Empty)
                    {
                       
                        lbl_errorInput.Content = String.Empty;
                        _questionCount++;

                        if (_questionCount <= 10)
                        {
                            // Sends the the player answer to gameLogic
                            if (gameLogic.isCorrect(txt_answer.Text))
                            {
                                _player.correct++;
                                lbl_answerStatus.Content = " Correct!";
                            }
                            else
                            {
                                _player.wrong++;
                                lbl_answerStatus.Content = " Incorrect!";
                            }

                            // Clears answer text box and calls for the next question
                            txt_answer.Text = string.Empty;
                            lbl_gameWindow.Content = gameLogic.question();

                        }

                        if (_questionCount == 10)
                        {
                            // Creates a timer to get the total time and stops the timer
                            endTime = DateTime.Now;
                            _player.TotalTime = endTime.Subtract(startTime);
                            gameTimer.Stop();

                            // Hides the screen and pass in the information needed for scoreWindow
                            this.Hide();
                            scoreWindowForm.errorHandler = errorHandler;
                            scoreWindowForm.Player = _player;
                            scoreWindowForm.ShowDialog();

                        }
                    }
                    else
                    {
                        lbl_errorInput.Content = "Please input an answer";
                    }
                }                
            
            }
            catch (Exception ex)
            {

                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Force the user only to be enter numbers and delete them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_answer_KeyDown(object sender, KeyEventArgs e)
        
        {
            try
            {


                // Checks if enter was clicked
                if (Key.Enter == e.Key)
                {
                    // If the game has not started and enter was pressed
                    if (!_gameStarted)
                    {
                        cmd_gameStart_Click(sender, e);
                        txt_answer.Text = string.Empty;
                    }
                    else
                    {
                        cmd_submit_Click(sender, e);
                    }
              
                }

                if (!(e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
                {
                    if (!(e.Key == Key.Back || e.Key == Key.Delete))
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {

                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the window is the active window it calls startState
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onOpen(object sender, EventArgs e)
        {

            try
            {
                if(!_gameStarted)
                {
                    startState();
                    bgm_gameWindow = new SoundPlayer("bgm_gameWindow.wav");
                    bgm_gameWindow.Play();
                }

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
                bgm_gameWindow.Stop();
            }
            catch (Exception ex)
            {

                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
