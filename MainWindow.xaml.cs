using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Xml.Linq;
using System.Media;

namespace math_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Attributes

        /// <summary>
        /// Used to store the RadioButton that was pressed
        /// </summary>
        private RadioButton _gameType;


        /// <summary>
        /// Holds the players information
        /// </summary>
        private User _player;


        /// <summary>
        /// Used to store the users age once verified 
        /// </summary>
        private int _age;

        /// <summary>
        /// Used to store the user name once verified 
        /// </summary>
        private string _name;

        /// <summary>
        /// Stores the background music that plays
        /// </summary>
        private SoundPlayer bgm_mainWindow;

        /// <summary>
        /// setting up class for gameWindow
        /// </summary>
        public gameWindow gameWindowForm;

        /// <summary>
        /// Handles errors if exception is thrown
        /// </summary>
        public errorHandler errorHandler;

        #endregion


        #region Methods

        /// <summary>
        /// A holder for User object
        /// </summary>
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
        /// Checks to see if the age is a number and if so if its between 3 and 10
        /// </summary>
        /// <param name="age">The string we need to verify</param>
        private bool validateAge(string age)
        {
            try 
            { 
                if(age != string.Empty) 
                {
                    int ageInt = int.Parse(age);

                    if (ageInt >= 3 && ageInt <= 10)
                    {
                        _age = ageInt;
                        lbl_errorAge.Content = string.Empty;
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }

            } 
            catch(Exception ex) 
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                  MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Checks to make sure a name has been entered
        /// </summary>
        /// <param name="name">The string to be checked</param>
        private bool nameCheck(string name)
        {
            try
            {
                if (name == string.Empty)
                {
                    return false;
                }
                else
                {
                    _name = name;
                    lbl_errorName.Content = string.Empty;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }

        /// <summary>
        /// Checks if a radio button has been clicked
        /// </summary>
        private bool radioCheck()
        {
            try
            {
                if (_gameType == null)
                {
                    return false;
                }

                lbl_radioError.Content = string.Empty;
                return true;
                
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        #endregion


        public MainWindow()
        {
            InitializeComponent();

            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            gameWindowForm = new gameWindow();
            errorHandler = new errorHandler();

        }


        /// <summary>
        /// Checks to see if the _player info has been entered if so it.
        /// If so it sets up User object and passes what is needed to gameWindowForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!validateAge(txt_playerAge.Text))
                {
                    lbl_errorAge.Content = "Please enter an age between 3 and 10";
                }

                if(!nameCheck(txt_playerName.Text))
                {
                    lbl_errorName.Content = "Please enter a name";
                }

                if(!radioCheck())
                {
                    lbl_radioError.Content = "Please select a game type";
                }

                if (validateAge(txt_playerAge.Text) && nameCheck(txt_playerName.Text) && radioCheck())
                {
                    if(!gameWindowForm.IsActive)
                    {
                        gameWindowForm = new gameWindow();
                    }
                    _player = new User(_name, _age);
                    gameWindowForm.gameType = _gameType;
                    gameWindowForm.errorHandler = errorHandler;
                    gameWindowForm.Player = _player;
                    gameWindowForm.mainWindowForm = this;
                    this.Hide();
                    gameWindowForm.ShowDialog();
                    this.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Checks to make sure that the key pressed was a number, delete key, or backspace key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_playerAge_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
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
        /// Once a radio button is clicked it save the button into _gameType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdb_add_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                _gameType = (RadioButton)sender;
            }
            catch (Exception ex)
            {

                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the screen becomes foreground windows music starts playing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void on_active(object sender, EventArgs e)
        {

            try
            {
                bgm_mainWindow = new SoundPlayer("bgm_mainWindow.wav");
                bgm_mainWindow.Play();
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
                bgm_mainWindow.Stop();
            }
            catch (Exception ex)
            {

                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
