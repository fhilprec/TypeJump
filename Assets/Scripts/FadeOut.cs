using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    
    IEnumerator FadeOutEnumerator()
    {
        for (float f  = 1f; f  > 0f; f-= 0.05f)
        {
            Color c = gameObject.GetComponent<MeshRenderer>().materials[0].color;
            c.a = f;
            gameObject.GetComponent<MeshRenderer>().material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void startFadind()
    {
        StartCoroutine("FadeOutEnumerator");
    }
}
