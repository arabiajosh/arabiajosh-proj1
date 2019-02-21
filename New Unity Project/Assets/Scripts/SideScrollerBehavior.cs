using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerBehavior : MonoBehaviour
{

    public GameObject topSprite;
    public GameObject bottomSprite;

    private float endPosition;
    private float spriteWidth;

    public GameObject currentActive;

    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        spriteWidth = bottomSprite.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        bottomSprite.transform.position = new Vector2(bottomSprite.transform.position.x + spriteWidth, bottomSprite.transform.position.y);
        endPosition = topSprite.transform.position.x - spriteWidth;
        currentActive = topSprite;
    }

    // Update is called once per frame
    void Update()
    {

        //Translate background sprites
        movePiece(bottomSprite);
        movePiece(topSprite);


        //Check and reset background sprite positions
        if(bottomSprite.transform.position.x <= endPosition)
        {
            resetPiece(bottomSprite);
        }
        if(topSprite.transform.position.x <= endPosition)
        {
            resetPiece(topSprite);
        }
    }

    //Translates a piece in the -x direction, based on the passed movement speed
    // param name="piece" the GameObject to translate
    public void movePiece(GameObject piece)
    {
        piece.transform.Translate(new Vector2(-transform.right.x * (movementSpeed / 100), 0f));
    }

    //Translates a piece in the x direction, a distance of 2*spriteWidth
    // param name="piece" the GameObject to translate
    void resetPiece(GameObject piece)
    {
        piece.transform.position = new Vector2(piece.transform.position.x + 2 * spriteWidth, piece.transform.position.y);
    }
}
