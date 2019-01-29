using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButtonClick : MonoBehaviour {

    ColourGame game;

	// Use this for initialization
	void Start () {
        game = GameObject.Find("Colour Minigame").GetComponent<ColourGame>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        game.checkColour("Green");
    }
}
