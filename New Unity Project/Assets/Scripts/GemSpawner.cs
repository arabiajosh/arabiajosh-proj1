using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{

    Pooler gp;
    GameObject gem;

    [Range(1f, 3f)]
    public float maxWaitTime;

    [Range(.5f, 1.5f)]
    public float minWaitTime;

    private int numDropped = 0;

    private void Start()
    {
        gp = gameObject.GetComponent<Pooler>();
        StartCoroutine(dropGem());
    }


    IEnumerator dropGem()
    {
        while (true)
        {
            gem = gp.getPooledObject();
            if (gem != null)
            {
                gem.SetActive(true);
                numDropped++;
            }
            float waitTime = maxWaitTime - (numDropped / 25f);
            yield return new WaitForSeconds(Mathf.Max(minWaitTime, waitTime));
        }
    }
}
