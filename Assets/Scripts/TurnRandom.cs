using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRandom : MonoBehaviour
{
    public GameObject barrel;
    // Start is called before the first frame update
    void Start()
    {
        barrel.transform.Rotate(0, Random.Range(0f, 359f), 0);
    }


}
