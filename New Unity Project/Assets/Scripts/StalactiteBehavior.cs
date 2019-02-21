using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteBehavior : MonoBehaviour
{


    Rigidbody2D rb;
    CircleCollider2D tip;
    PolygonCollider2D body;
    GameObject bg;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tip = gameObject.GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        bg = GameObject.Find("Background");

    }

    private void OnEnable()
    {
        float xPos = Random.Range(-9f, 9f);
        //Debug.Log(xPos);
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.position = new Vector3(xPos, 5f, 0f);
        tip.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(bg == null);
        if (collision.gameObject.tag.Equals("Floor"))
        {
            tip.enabled = false;
            //rb.isKinematic = false;
            //transform.rotation = Quaternion.identity;
            bg.GetComponent<SideScrollerBehavior>().movePiece(gameObject);
            if (transform.position.x < -11f || transform.position.x > 11)
            {
                gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.tag.Equals("Stalactite"))
        {
            tip.enabled = false;
        }
    }


    public IEnumerator destroy()
    {
        anim.SetBool("isDestroyed", true);
        yield return new WaitForSecondsRealtime(anim.GetCurrentAnimatorStateInfo(0).length);//+ anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        anim.SetBool("isDestroyed", false);
        gameObject.SetActive(false);
    }

}
