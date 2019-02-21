using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehavior : MonoBehaviour
{

    public Sprite spr0;
    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;

    SpriteRenderer sr;

    [Range(1,4)]
    public int numSprites;

    public int baseScore;

    public AudioSource audio;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        audio = gameObject.GetComponent<AudioSource>();
        //sr.sortingLayerName = "Gem";
    }

    void OnEnable()
    {
        //audio.enabled = true;
        float xPos = Random.Range(-9f, 9f);
        //Debug.Log(xPos);
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.position = new Vector3(xPos, 5f, 0f);

        int i = Random.Range(1, numSprites+1);

        switch (i)
        {
            case 1:
                sr.sprite = spr0;
                break;
            case 2:
                sr.sprite = spr1;
                break;
            case 3:
                sr.sprite = spr2;
                break;
            case 4:
                sr.sprite = spr3;
                break;
        }

    }

    public int getValue()
    {
        return (int)Mathf.Round(baseScore * (transform.position.y + 5));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag.Equals("Floor"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")){
            audio.Play();
        }
    }

}
