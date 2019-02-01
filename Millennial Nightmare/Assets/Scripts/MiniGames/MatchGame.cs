using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGame : MonoBehaviour {

    //Tells if player has flipped first card
    private bool isChoosing;
    private int cardClicked;

    //List of Cards
    private Card card1;
    private Card card2;
    private Card card3;
    private Card card4;
    private ArrayList cards;

    //List of Sprites for card faces
    public Sprite circleSprite;
    public Sprite pentagonSprite;
    public Sprite rectangleSprite;
    public Sprite squareSprite;
    public Sprite starSprite;
    public Sprite triangleSprite;
    private ArrayList sprites;


    // Use this for initialization
    void Start () {
        //Initialise Sprite list
        sprites = new ArrayList();
        sprites.Add(circleSprite);
        sprites.Add(pentagonSprite);
        sprites.Add(rectangleSprite);
        sprites.Add(squareSprite);
        sprites.Add(starSprite);
        sprites.Add(triangleSprite);

        //Initialise Cards
        card1 = GameObject.Find("Match Card 1").GetComponent<Card>();
        card2 = GameObject.Find("Match Card 2").GetComponent<Card>();
        card3 = GameObject.Find("Match Card 3").GetComponent<Card>();
        card4 = GameObject.Find("Match Card 4").GetComponent<Card>();

        //Arraylist
        cards = new ArrayList();
        cards.Add(card1);
        cards.Add(card2);
        cards.Add(card3);
        cards.Add(card4);

        //Set the Cards to Objects in Unity
        card1.setSpriteRenderer(GameObject.Find("Match Card 1").GetComponent<SpriteRenderer>());
        card2.setSpriteRenderer(GameObject.Find("Match Card 2").GetComponent<SpriteRenderer>());
        card3.setSpriteRenderer(GameObject.Find("Match Card 3").GetComponent<SpriteRenderer>());
        card4.setSpriteRenderer(GameObject.Find("Match Card 4").GetComponent<SpriteRenderer>());

        //Assgin Cards their faces
        assignCards();

        cardClicked = 0;
    }

    // Update is called once per frame
    void Update () {

        //Get the number of cards flipped
        foreach (Card card in cards) {
            if (card.getCardFlipped()) {
                cardClicked++;
            }
        }
        if (cardClicked == 1)
        {
            isChoosing = true;
        }
        else if (cardClicked == 2) {
            checkMatch();
            allCardsFlipped();
        }
        cardClicked = 0;

	}

    //Flips all cards facedown
    private void allCardsFlipped() {
        foreach (Card card in cards) {
            card.flipBack();
        }
    }

    //This function find the two cards that have been selected, then checks if they have the same face
    private void checkMatch() {
        //Get the two cards that are flipped
        ArrayList clickedCards = new ArrayList();
        foreach (Card card in cards) {
            if (card.getCardFlipped()) {
                clickedCards.Add(card);
            }
        }

        Card card1 = (Card)clickedCards[0];
        Card card2 = (Card)clickedCards[1];
        //check if the cards have the same face
        if (card1.getCardFace() == card2.getCardFace()) {
            card1.setMatched();
            card2.setMatched();
        }
    }

    //This method assigns card their faces at the beginning of the minigame
    private void assignCards() {
        //Get the number of sprites required to assign
        int numSprites = cards.Count / 2;
        //loop twice: Outer loop assigns each required sprite once
        for (int i = 0; i < 2; i++) {
            //inner loop: Assigns a sprite to a random unassigned card
            for (int j = 0; j < numSprites; j++) {
                bool assigned = false;
                while (!assigned){
                    System.Random getrandom = new System.Random();
                    int index = getrandom.Next(cards.Count);
                    Card cardToAssign = (Card)cards[index];
                    if (cardToAssign.getCardFace() == null) {
                        cardToAssign.setCardFace((Sprite)sprites[j]);
                        assigned = true;
                    }
                }
            }
        }
    }

    
}
