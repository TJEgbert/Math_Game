using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace math_game
{
    public class User
    {
        #region Attributes

        /// <summary>
        /// The age of the player
        /// </summary>
        private int _age;

        /// <summary>
        /// The name of the player
        /// </summary>
        private string _name;

        /// <summary>
        /// The number of correct answers
        /// </summary>
        private int _correct = 0;

        /// <summary>
        /// The number of wrong answers
        /// </summary>
        private int _wrong = 0;

        /// <summary>
        /// The time it took the user to finish the game
        /// </summary>
        private TimeSpan _totalTime;

        #endregion

        #region Methods

        /// <summary>
        /// The users name
        /// </summary>
        public string Name
        {
            get
            {
                try
                {
                    return _name;

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
                    _name = value;

                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }

        }

        /// <summary>
        /// The users age
        /// </summary>
        public int Age
        {
            get
            {
                try
                {
                    return _age;

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
                    _age = value;

                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }
        }

        /// <summary>
        /// The number of the user correct answers
        /// </summary>
        public int correct
        {
            get
            {
                try
                {
                    return _correct;

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
                    _correct = value;

                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }
        }

        /// <summary>
        /// The number of incorrect answer
        /// </summary>
        public int wrong
        {
            get
            {
                try
                {
                    return _wrong;

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
                    _wrong = value;

                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }

        }

        /// <summary>
        /// The time it took the user to complete the game
        /// </summary>
        public TimeSpan TotalTime
        {
            get
            {
                try
                {
                    return _totalTime;

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
                    _totalTime = value;

                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }
        }

        /// <summary>
        /// A non default constructer for the User takes in the name
        /// </summary>
        /// <param name="name"> A string used for the User name</param>
        /// <param name="age">an int used for the User age</param>
        public User(string name, int age)
        {

            try
            {
                _name = name;
                _age = age;
                correct = 0;
                wrong = 0;
                TotalTime = TimeSpan.Zero;

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
