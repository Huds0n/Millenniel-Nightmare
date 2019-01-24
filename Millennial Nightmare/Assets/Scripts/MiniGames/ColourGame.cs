using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGame : MonoBehaviour {

    //Colours
    public string[] colours = { "Red", "Green", "Blue", "Yellow" };
    //random number generator
    private static readonly System.Random getrandom = new System.Random();
    //num of colours to print
    private int numColours;

	// Use this for initialization
	void Start () {
        numColours = 5;
        InvokeRepeating("ChooseColour", 0.0f, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Chooses a random colour and prints to console
    void ChooseColour() {
        int colourNumber = 6 - numColours;
        int index = getrandom.Next(4);
        print("Colour Number " + colourNumber.ToString() + ": "+ colours[index]);
        //After set number of colours, stop choosing more
        if (--numColours == 0) {
            CancelInvoke("ChooseColour");
            print("No more colours");
        }
    }
}
