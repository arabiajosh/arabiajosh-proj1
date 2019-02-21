using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteSpawner : MonoBehaviour
{

    Pooler sp;
    GameObject stag;

    [Range(2f,5f)]
    public float maxWaitTime;

    [Range(.5f,1.5f)]
    public float minWaitTime;

    private int numDropped = 0;


    private void Start()
    {
        sp = gameObject.GetComponent<Pooler>();
        StartCoroutine(dropStag());
    }


    IEnumerator dropStag()
    {
        while (true)
        {
            stag = sp.getPooledObject();
            if(stag != null)
            {
                stag.SetActive(true);
                numDropped++;
            }
            float waitTime = maxWaitTime - (numDropped / 15f);
            yield return new WaitForSeconds(Mathf.Max(minWaitTime, waitTime));
        }
    }
}
