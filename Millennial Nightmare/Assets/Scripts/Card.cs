using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    //Is the front or back of card showing
    private bool frontShowing;
    private bool cardMatched;

    //Sprite Renderer Ref
    private SpriteRenderer spriteRenderer;

    //Card SPrites
    private Sprite frontFace;
    private Sprite backFace;

    //Back of card sprite
    public Sprite backSprite;

    // Use this for initialization
    void Start () {
        frontShowing = false;
        cardMatched = false;

        //Hardcoded front card face
        backFace = backSprite;
    }

    // Update is called once per frame
    void Update () {
        //Show correct face of card
        if (cardMatched) {
            spriteRenderer.sprite = null;
        }
        else if (frontShowing)
        {
            //Tell the sprite renderer which face to show
            spriteRenderer.sprite = frontFace;
        }
        else {
            spriteRenderer.sprite = backFace;
        }

	}

    public void setSpriteRenderer(SpriteRenderer spriteRenderer) {
        this.spriteRenderer = spriteRenderer;
    }

    public SpriteRenderer getSpriteRenderer() {
        return this.spriteRenderer;
    }

    public bool getCardFlipped() {
        return this.frontShowing;
    }

    public void flipBack() {
        this.frontShowing = false;
    }

    public Sprite getCardFace() {
        return this.frontFace;
    }

    public void setCardFace(Sprite sprite) {
        this.frontFace = sprite;
    }

    public void setMatched() {
        this.cardMatched = true;
    }

    public bool getMatched() {
        return this.cardMatched;
    }


    void cardFlipped() {
        frontShowing = !frontShowing;
    }

    private void OnMouseDown(){
        cardFlipped();
        print(this.frontFace);
    }
}
