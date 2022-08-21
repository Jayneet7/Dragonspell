using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game 
{
    public class Firebarcontroller : MonoBehaviour
    {
        // Creating game objects for geting it on screen and deleting when player enter wrong buttonn
        public GameObject fire;
        public GameObject fire1;
        public GameObject fire2;
        public GameObject fire3;
        public GameObject fire4;
        public GameObject fire5;
        public GameObject fire6;
        public Gamecontroller gameController;
        
        public GameObject display;

        // Creating a variable to count the tries
        
        private int tries;
        // Creating an arry of fire objects 
        private GameObject[] parts;
        public AudioSource loseSound;
        
        // Checking if the tries runs out or not
        public bool Isfired 
        {
            get { return tries < 0; }
        }

        private void Start()
        {
            // Adding objects in to the array
            parts = new GameObject[] { fire, fire1, fire2, fire3, fire4, fire5, fire6 };
            Reset();
        }
       
        public void Punish() 
        {
            if(tries >=0)
            {
                loseSound.Play();
                display.SetActive(false);
                parts[tries--].SetActive(true);
            }
        }

        // Exicuted on every wrong answer
        public void Reset()
        {
            // Checking if the parts array is null
            if(parts == null)
            {
                gameController.scoreIndicator.text = "0";
                return;
            }
            tries = parts.Length - 1;

            foreach (GameObject g in parts)
            {
                //
                g.SetActive(false);
            }
        }
    }
}
