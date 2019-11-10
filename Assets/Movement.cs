using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 10;
    public Rigidbody rb;
    private string word = "";

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(word);
        if (Input.GetKeyDown("r"))
        {
            word += "r";
        }
        if (Input.GetKeyDown("i"))
        {
            word += "i";
        }
        if (Input.GetKeyDown("g"))
        {
            word += "g";
        }
        if (Input.GetKeyDown("h"))
        {
            word += "h";
        }
        if (Input.GetKeyDown("t"))
        {
            word += "t";
        }

        if (word == "right")
        {
            rb.AddForce(-speed * Time.deltaTime * 1000, 0, 0) ;
            Debug.Log("Succes");
            word = "";
        }
        if(word.Length > 5)
        {
            word = "";
        }
        if (Input.GetKey("o")) { word = ""; }
    }
}
