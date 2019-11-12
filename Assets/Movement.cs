using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 10;
    public Rigidbody rb;
    private string word = "";
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Debug.Log(word);
        
            if (word == "right")
        {
            //rb.AddForce(-speed * Time.deltaTime * 1000, 0, 0) ;
            rb.AddForce(0, speed * Time.deltaTime * 1000, 0);
            Debug.Log("Succes");
            word = "";
        }
        if(word.Length > 5)
        {
            text.GetComponent<TextAsset>().text.Insert(0, "");
        }
        if (Input.GetKey("o")) { word = ""; }
    }
}
