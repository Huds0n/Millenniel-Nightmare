using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGame : MonoBehaviour {

    //Colours
    public string[] colours = { "Red", "Green", "Blue", "Yellow" };
    public string[] coloursToRemember;
    public string currentColorOn;
    //random number generator
    private static readonly System.Random getrandom = new System.Random();
    //num of colours to print
    private int numColours;
    //Coloured buttons on phone
    private SpriteRenderer redButton;
    private SpriteRenderer greenButton;
    private SpriteRenderer yellowButton;
    private SpriteRenderer blueButton;
    //8 colour options
    Color redOff = new Color(1, 0.2f, 0.2f, 0.5f);
    Color redOn = new Color(1, 0, 0, 1);
    Color greenOff = new Color(0.2f, 1, 0.2f, 0.5f);
    Color greenOn = new Color(0, 1, 0, 1);
    Color yellowOff = new Color(1, 1, 0.2f, 0.5f);
    Color yellowOn = new Color(1, 1, 0, 1);
    Color blueOff = new Color(0.2f, 0.2f, 1, 0.5f);
    Color blueOn = new Color(0, 0, 1, 1);
    //Light up time
    private float lightTime = 2.5f;
    private float currentTimeOn = 0.0f;

    // Use this for initialization
    void Start () {
        numColours = 5;
        InvokeRepeating("ChooseColour", 0.0f, 3.0f);
        coloursToRemember = new string[numColours];

        //Initialise buttons on phone
        redButton = GameObject.Find("Coloured Blocks Red").GetComponent<SpriteRenderer>();
        greenButton = GameObject.Find("Coloured Blocks Green").GetComponent<SpriteRenderer>();
        yellowButton = GameObject.Find("Coloured Blocks Yellow").GetComponent<SpriteRenderer>();
        blueButton = GameObject.Find("Coloured Blocks Blue").GetComponent<SpriteRenderer>();

        //Initialise their colours as "off"
        redButton.color = redOff;
        greenButton.color = greenOff;
        yellowButton.color = yellowOff;
        blueButton.color = blueOff;
    }
	
	// Update is called once per frame
	void Update () {
        if (currentColorOn != null) {
            currentTimeOn += Time.deltaTime;
        }
        if (currentTimeOn >= lightTime) {
            if (currentColorOn == "Red")
            {
                redButton.color = redOff;
            }
            else if (currentColorOn == "Green")
            {
                greenButton.color = greenOff;
            }
            else if (currentColorOn == "Yellow") {
                yellowButton.color = yellowOff;
            }
            else{
                blueButton.color = blueOff;
            }
            currentColorOn = null;
            currentTimeOn = 0.0f;
        }
	}

    //Chooses a random colour and prints to console
    void ChooseColour() {
        int colourNumber = 6 - numColours;
        int index = getrandom.Next(4);
        string nextColour = colours[index];

        //Make the button light up
        if (nextColour == "Red"){
            currentColorOn = "Red";
            redButton.color = Color.red;
        }
        else if (nextColour == "Green"){
            currentColorOn = "Green";
            greenButton.color = greenOn;
        }
        else if (nextColour == "Yellow"){
            currentColorOn = "Yellow";
            yellowButton.color = yellowOn;
        }
        else {
            currentColorOn = "Blue";
            blueButton.color = blueOn;
        }
        coloursToRemember[colourNumber - 1] = nextColour;
        print("Colour Number " + colourNumber.ToString() + ": "+ nextColour);
        //After set number of colours, stop choosing more
        if (--numColours == 0) {
            CancelInvoke("ChooseColour");
            print("No more colours");
        }
    }

    //This function asks for input and checks each input against what it should be
    void EnterColours() {
        for(int i = 0; i < 5; i++) {
            string input = "hi";
            CheckColour(input, coloursToRemember[i]);
        }
    }

    bool CheckColour(string input, string colour) {
        if (input == colour) {
            return true;
        }
        else {
            return false;
        }
    }
}
