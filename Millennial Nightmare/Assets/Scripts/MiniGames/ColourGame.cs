using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColourGame : MonoBehaviour {
    private Text loseText;
    //Minigame Level Counters
    private int currentLevel;
    private int numLevels;
    //Timer to track level time
    private float levelTimeLeft = 5.0f;
    private bool levelTimerOn;
    //Colours
    public string[] colours = { "Red", "Green", "Blue", "Yellow" };
    public ArrayList coloursToRemember;
    public string currentColorOn;
    public string colourToChoose;
    //random number generator
    private static readonly System.Random getrandom = new System.Random();
    //num of colours to print
    private int numColours;
    private int coloursThisRound;
    //Coloured buttons on phone
    private SpriteRenderer redButton;
    private SpriteRenderer greenButton;
    private SpriteRenderer yellowButton;
    private SpriteRenderer blueButton;
    //Time and Level Counter on Phone
    private TextMeshPro levelCounter;
    private TextMeshPro levelTimer;
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
    private float lightTime = 1.3f;
    private float currentTimeOn = 0.0f;
    //Listen Time or Selecting Time
    private bool SimonSaying;
    //Collider for yellow button
    private Collider2D yellowButtonCollider;

    // Use this for initialization
    void Start () {
        //For when wrong button is pressed
        loseText = GameObject.Find("Lose").GetComponent<Text>();
        //Simon is always talking first
        SimonSaying = true;

        numColours = 3;
        coloursThisRound = 3;
        InvokeRepeating("ChooseColour", lightTime, lightTime);
        coloursToRemember = new ArrayList();

        //Initialise buttons on phone
        redButton = GameObject.Find("Coloured Blocks Red").GetComponent<SpriteRenderer>();
        greenButton = GameObject.Find("Coloured Blocks Green").GetComponent<SpriteRenderer>();
        yellowButton = GameObject.Find("Coloured Blocks Yellow").GetComponent<SpriteRenderer>();
        blueButton = GameObject.Find("Coloured Blocks Blue").GetComponent<SpriteRenderer>();

        //Initialise button colliders
        Vector2 YellowSize = yellowButton.sprite.bounds.size;
        yellowButton.GetComponent<BoxCollider2D>().size = YellowSize;

        //Initialise their colours as "off"
        redButton.color = redOff;
        greenButton.color = greenOff;
        yellowButton.color = yellowOff;
        blueButton.color = blueOff;

        //Initialise Level Counter and Timer
        levelCounter = GameObject.Find("Minigame Level Counter").GetComponent<TextMeshPro>();
        levelTimer = GameObject.Find("Minigame Level Time").GetComponent<TextMeshPro>();
        levelTimerOn = false;

        //Initialise Levels for Minigame
        currentLevel = 1;
        numLevels = 3;

        //TextMesh Testing
        levelCounter.text = currentLevel.ToString() + "/" + numLevels.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (currentLevel > numLevels) {
            levelCounter.fontSize = 10;
            levelCounter.text = "Done";
            turnOffButton(currentColorOn);
            return;
        }
        if (currentColorOn != null) {
            currentTimeOn += Time.deltaTime;
        }
        if (SimonSaying && currentTimeOn >= (lightTime - 0.3)) {
            turnOffButton(currentColorOn);
            //If all colours are done, change simon talking and timer bool
            if (numColours == 0) {
                SimonSaying = false;
                levelTimerOn = true;
            }
        }

        if (!SimonSaying)
        {
            if (currentTimeOn >= 0.2) {
                turnOffButton(currentColorOn);
            }
            if (coloursToRemember.Count == 0)
            {
                SimonSaying = true;
                levelTimerOn = false;
                levelTimeLeft = 5.0f;
                currentLevel++;
                coloursThisRound++;
                numColours = coloursThisRound;
                if (!(currentLevel > numLevels))
                {
                    InvokeRepeating("ChooseColour", lightTime, lightTime);
                }
            }
            else
            {
                colourToChoose = (String)coloursToRemember[0];
                print(colourToChoose.ToString());

                //Deal with timer at bottom
                if (levelTimeLeft <= 0)
                {
                    loseText.text = "git gud";
                    Time.timeScale = 0;
                }
                else if (levelTimerOn)
                {
                    levelTimeLeft -= Time.deltaTime;
                }
            }
        }

        //Show the time left
        levelTimer.text = levelTimeLeft.ToString("0.00");
        //Show current level
        levelCounter.text = currentLevel.ToString() + "/" + numLevels.ToString();
    }

    //Chooses a random colour and prints to console
    void ChooseColour() {
        int colourNumber = (coloursThisRound + 1) - numColours;
        int index = getrandom.Next(4);
        string nextColour = colours[index];

        //Make the button light up
        activateButton(nextColour);
        coloursToRemember.Add(nextColour);
        //After set number of colours, stop choosing more
        if (--numColours == 0) {
            CancelInvoke("ChooseColour");
        }
    }

    public void checkColour(string colour) {
        if (!SimonSaying)
        {
            if (colour == colourToChoose)
            {
                activateButton(colour);
                coloursToRemember.RemoveAt(0);
                print("right");
            }
            else
            {
                loseText.text = "Git Gud";
                Time.timeScale = 0;
            }
        }
    }

    private void activateButton(string colour)
    {
        if (colour == "Blue")
        {
            currentColorOn = "Blue";
            blueButton.color = blueOn;
        }
        else if (colour == "Red")
        {
            currentColorOn = "Red";
            redButton.color = redOn;
        }
        else if (colour == "Yellow")
        {
            currentColorOn = "Yellow";
            yellowButton.color = yellowOn;
        }
        else {
            currentColorOn = "Green";
            greenButton.color = greenOn;
        }
    }

    private void turnOffButton(string colour) {
        if (colour == "Blue")
        {
            blueButton.color = blueOff;
        }
        else if (colour == "Red")
        {
            redButton.color = redOff;
        }
        else if (colour == "Yellow")
        {
            yellowButton.color = yellowOff;
        }
        else
        {
            greenButton.color = greenOff;
        }
        currentColorOn = null;
        currentTimeOn = 0.0f;
    }
}
