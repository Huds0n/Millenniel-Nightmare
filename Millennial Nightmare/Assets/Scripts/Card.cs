using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    //Is the front or back of card showing
    private bool frontShowing;

    //Sprite Renderer Ref
    private SpriteRenderer spriteRenderer;

    //Card SPrites
    private Sprite frontFace;
    private Sprite backFace;

    //List of Sprites for card
    public Sprite backSprite;
    public Sprite circleSprite;
    public Sprite pentagonSprite;
    public Sprite rectangleSprite;
    public Sprite squareSprite;
    public Sprite starSprite;
    public Sprite triangleSprite;

    // Use this for initialization
    void Start () {
        frontShowing = true;

        //Hardcoded front card face
        frontFace = circleSprite;
        backFace = backSprite;
    }

    // Update is called once per frame
    void Update () {

        //Show correct face of card
        if (frontShowing)
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

    public SpriteRenderer setSpriteRenderer() {
        return this.spriteRenderer;
    }
}
