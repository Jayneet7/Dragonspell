using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;



namespace Game
{ 
public class Gamecontroller : MonoBehaviour
{
        // Three text to one for words one for latter in word one for the score
        public Text wordIndicator;
        public Text scoreIndicator;
        public Text letterIndicator;

        public AudioSource correctAnswer; 
        public AudioSource gameWin;
        
        // Creating an object of dragoncontroller class
        private Firebarcontroller dragon;

        private string word;
        
        // Creating an arry of the charecters
        private char[] reveled;

        // Variable for the score and completed
        private int score;
        private bool completed;
    public void Start()
    {
            // Assinging an unity object to the dragon object of the dragon controller class
            dragon = GameObject.FindGameObjectWithTag("Player").GetComponent<Firebarcontroller>();

            // calling reset method
            ResetGame();   
    }

 
    void Update()
    {
            string s = Input.inputString;

            // Reviling the right answer for player to see but only if the game is completed 
            if (completed)
            {
                // Creating a temporary string for to save the user input
                string tmp = Input.inputString;
                if (Input.anyKeyDown)
                    NextWord();
                return;
            }
            // Getting valid input from user

            if (s.Length == 1 && Textutil.IsAlpha(s[0]))
            {
                if (!Check(s.ToUpper()[0]))
                {
                    dragon.Punish();

                    if (dragon.Isfired)
                    {
                        //Reveling each latter from user
                        wordIndicator.text = word;
                        completed = true;
                    }
                }
            }

            
    }
        // Checking each user input
        private bool Check(char c)
        {
            
            int completed = 0;
            int score = 0;
            bool ret = false;

            for (int i =0; i < reveled.Length; i++)
            {

                if (c == word[i])
                {
                    //check if the charecter is valid or not
                    ret = true;
                    if (reveled[i] == 0)
                    {
                        reveled[i] = c;
                        score++;
                    }
                }
                //check if the game is completed*
                if (reveled[i] != 0)
                {
                    completed++;
                }
                if(score != 0)
                {
                    // If all carecters are reveled
                    this.score += score;
                    if (completed == reveled.Length)
                    {
                        this.completed = true;
                        this.score += reveled.Length;
                        gameWin.Play();
                    }
                    UpdateWordIndicator();
                    UpdateScoreIndicator();
                }
            }
            return ret;
        }

        private void UpdateWordIndicator()
        {
            string displayed = " ";
            
            for(int i=0 ; i < reveled.Length ; i++)
            {
                char c = reveled[i];
                if (c == 0)
                {
                    c = '_';
                }
                displayed += ' ';
                displayed += c;

            }

            wordIndicator.text = displayed;
    
            
        }

        private void UpdateScoreIndicator()
        {
            scoreIndicator.text = "Score = " + score;
            correctAnswer.Play();
        }
        private void SetWord(string word)
        {
            word = word.ToUpper();
            this.word = word;

           //reveling charecters
            reveled = new char[word.Length];
            letterIndicator.text = "Letters = " + word.Length;

            UpdateWordIndicator();
        }
        public void NextWord()
        {
            // If the player runs out of tries reset the game
            dragon.Reset();

            completed = false;
            SetWord(WordList.Instance.NextWord(0));
        }
        public void ResetGame()
        {
            score = 0;
            //completed = false;
            UpdateScoreIndicator();
            NextWord();
        }
    }
}
