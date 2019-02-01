using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    //Reference for the minigame
    private MatchGame matchGame;

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

    //Card Rotation
    Coroutine rotationCoroutine;
    Quaternion newRotation;

    // Use this for initialization
    void Start()
    {
        matchGame = GameObject.Find("Match Minigame").GetComponent<MatchGame>();
        frontShowing = false;
        cardMatched = false;

        //Hardcoded front card face
        backFace = backSprite;
    }

    // Update is called once per frame
    void Update()
    {
        //Show correct face of card
        if (cardMatched)
        {
            spriteRenderer.sprite = null;
        }
        else if (frontShowing)
        {
            //Tell the sprite renderer which face to show
            spriteRenderer.sprite = frontFace;
        }
        else
        {
            spriteRenderer.sprite = backFace;
        }

    }

    public void setSpriteRenderer(SpriteRenderer spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
    }

    public SpriteRenderer getSpriteRenderer()
    {
        return this.spriteRenderer;
    }

    public bool getCardFlipped()
    {
        return this.frontShowing;
    }

    public void flipBack()
    {
        this.frontShowing = false;
    }

    public Sprite getCardFace()
    {
        return this.frontFace;
    }

    public void setCardFace(Sprite sprite)
    {
        this.frontFace = sprite;
    }

    public void setMatched()
    {
        this.cardMatched = true;
    }

    public bool getMatched()
    {
        return this.cardMatched;
    }


    void cardFlipped()
    {
        frontShowing = !frontShowing;
    }

    //Flips card when clicked on
    private void OnMouseDown()
    {
        //TODO:Add a function that rotates the card
        rotateCard("clockwise");
        //Wait 1.5 seconds and rotate back
        StartCoroutine(Wait());
        print("Here");
        matchGame.checkCardFlips();
    }

    public void rotateCard(string direction)
    {
        // Spin our target rotation in the desired direction.
        if (direction == "clockwise")
        {
            newRotation = new Quaternion(0, Mathf.Sqrt(0.5f), 0, Mathf.Sqrt(0.5f));
        }
        else {
            newRotation = new Quaternion(0, 0, 0, Mathf.Sqrt(0.5f));
        }
        

        // If we're not already rotating, start a new rotation.
        // (Otherwise, the coroutine will automatically handle the new target)
        if (rotationCoroutine == null)
            rotationCoroutine = StartCoroutine(RotationCoroutine());
    }

    IEnumerator RotationCoroutine(){
        // Until our current rotation aligns with the target...
        while (Quaternion.Dot(transform.rotation, newRotation) < 1f)
        {
            // Rotate at a consistent speed toward the target.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, 200f * Time.deltaTime);

            // Wait a frame, then resume.
            yield return null;
        }

        // Clear the coroutine so the next input starts a fresh one.
        rotationCoroutine = null;
        frontShowing = !frontShowing;
        if (frontShowing == true) {
            rotateCard("anticlockwise");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.5f);
        rotateCard("clockwise");
    }
}
