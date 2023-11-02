using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace math_game
{
    public class game
    {

        #region Attributes
        /// <summary>
        /// The type of math problems that will be generated
        /// </summary>
        private string _gameType;

        /// <summary>
        /// The answer to the question
        /// </summary>
        private int _answer;

        /// <summary>
        /// The first number of the problem
        /// </summary>
        private int _num1;

        /// <summary>
        /// The second number of the problem
        /// </summary>
        private int _num2;

        /// <summary>
        /// The sign for the math problem
        /// </summary>
        private char _mathSign;

        #endregion

        #region Methods

        /// <summary>
        /// The type of math problems that will be generated
        /// </summary>
        public string GameType
        {
            get
            {
                try
                {
                    return _gameType;

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
                    _gameType = value;

                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }
        }


        /// <summary>
        /// Generates a random problem depending on the game type
        /// </summary>
        /// <exception cref="Exception"> Throws the information about the method to the higher level methods</exception>
        private void gameLogic()
        {
            try
            {
                var rnd = new Random();
                _num1 = rnd.Next(1, 11);
                _num2 = rnd.Next(1, 11);

                if (_gameType == "Addition")
                {
                    _mathSign = '+';
                    _answer = _num1 + _num2;

                }
                else if (_gameType == "Subtraction")
                {
                    _mathSign = '-';
                    while( _num1 < _num2)
                    {
                        _num2 = rnd.Next(1, 11);
                    }
                    _answer = _num1 - _num2;

                }
                else if (_gameType == "Multiplication")
                {
                    _mathSign = 'X';
                    _answer = _num1 * _num2;
                }
                else if (_gameType == "Division")
                {
                    _mathSign = '/';
                    _num1 *= _num2;
                    _answer = _num1 / _num2;

                }

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// Checks if the players answer is correct of not
        /// </summary>
        /// <param name="playerAnswer">The string containing the player answer</param>
        /// <returns>true if correct false if its wrong</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public bool isCorrect(string playerAnswer)
        {

            try
            {
                if (_answer == int.Parse(playerAnswer))
                {
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// Creates the question for the player
        /// </summary>
        /// <returns>A string of the question</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string question()
        {
            try
            {
                gameLogic();
                string question = " " +_num1 + " " + _mathSign + " " + _num2 + " = ";
                return question;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        #endregion
    }
}
