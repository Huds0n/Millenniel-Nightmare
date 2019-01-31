using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGame : MonoBehaviour {

    //Tells if player has flipped first card
    private bool isChoosing;

    //List of Cards
    private Card card1;
    private Card card2;
    private Card card3;
    private Card card4;


    // Use this for initialization
    void Start () {
        //Initialise Cards
        card1 = GameObject.Find("Match Card 1").GetComponent<Card>();
        card2 = GameObject.Find("Match Card 2").GetComponent<Card>();
        card3 = GameObject.Find("Match Card 3").GetComponent<Card>();
        card4 = GameObject.Find("Match Card 4").GetComponent<Card>();

        //Set the Cards to Objects in Unity
        card1.setSpriteRenderer(GameObject.Find("Match Card 1").GetComponent<SpriteRenderer>());
        card2.setSpriteRenderer(GameObject.Find("Match Card 2").GetComponent<SpriteRenderer>());
        card3.setSpriteRenderer(GameObject.Find("Match Card 3").GetComponent<SpriteRenderer>());
        card4.setSpriteRenderer(GameObject.Find("Match Card 4").GetComponent<SpriteRenderer>());

    }

    // Update is called once per frame
    void Update () {
		
	}
}
