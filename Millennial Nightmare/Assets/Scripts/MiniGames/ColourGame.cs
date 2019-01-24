using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGame : MonoBehaviour {

    //Colours
    public string[] colours = { "Red", "Green", "Blue", "Yellow" };
    public string[] coloursToRemember;
    //random number generator
    private static readonly System.Random getrandom = new System.Random();
    //num of colours to print
    private int numColours;

	// Use this for initialization
	void Start () {
        numColours = 5;
        InvokeRepeating("ChooseColour", 0.0f, 3.0f);
        coloursToRemember = new string[numColours];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Chooses a random colour and prints to console
    void ChooseColour() {
        int colourNumber = 6 - numColours;
        int index = getrandom.Next(4);
        string nextColour = colours[index];
        coloursToRemember[colourNumber - 1] = nextColour;
        print("Colour Number " + colourNumber.ToString() + ": "+ nextColour);
        //After set number of colours, stop choosing more
        if (--numColours == 0) {
            CancelInvoke("ChooseColour");
            print("No more colours");
            print(coloursToRemember[0]);
            print(coloursToRemember[1]);
            print(coloursToRemember[2]);
            print(coloursToRemember[3]);
            print(coloursToRemember[4]);

        }
    }
}
