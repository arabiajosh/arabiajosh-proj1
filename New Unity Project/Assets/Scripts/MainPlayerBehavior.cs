using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerBehavior : MonoBehaviour
{

    public GameObject gameManager;

    public Animator anim;
    public AudioSource audio1;
    public AudioSource audio2;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance == null)
        {
           Instantiate(gameManager);
        }

        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Stalactite"))
        {
            audio1.Play();
            collision.gameObject.GetComponent<StalactiteBehavior>().StartCoroutine("destroy");
            GameManager.instance.takeDamage();


        } else if(collision.gameObject.tag.Equals("Gem")) {
            GameManager.instance.increaseScore(collision.gameObject.GetComponent<GemBehavior>().getValue()) ;
            audio2.Play();
            collision.gameObject.SetActive(false);
        }
    }


}
