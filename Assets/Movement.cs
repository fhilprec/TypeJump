using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    private Rigidbody cuberb;
    public float speed = 1;
    public float power = 1;
    public string word = "";
    private GameObject InputFieldg;
    private bool clear = false;
    private bool newstart = false;
    private float deltimer = 0f;
    private void Start()
    {
        cuberb = gameObject.GetComponent<Rigidbody>();
        cuberb.freezeRotation = true;
    }
    private void Update()
    {
        deltimer += Time.deltaTime;
        cuberb.transform.position += Vector3.forward * speed * 1f * Time.deltaTime;
        cuberb.AddForce(0, -power * 10f, 0);

        if(clear && deltimer > 1f)
        {
            word = "";
            clear = false;
            InputFieldg.GetComponent<InputField>().text = "";
        }
        if(deltimer > 3f &&  InputFieldg != null)
        {
            word = "";
            InputFieldg.GetComponent<InputField>().text = "";
            deltimer = 0;
        }
        
    }




    public void Changeposition(GameObject InputField)
    {
        if (newstart)
        {
            InputFieldg.GetComponent<InputField>().text = "";
            newstart = false;
        }

        InputFieldg = InputField;
        InputField.GetComponent<Animator>().Play(0);

        word = InputField.GetComponent<InputField>().text;
        Debug.Log(word);
        if(word.Length > 5)
        {
            deltimer = 0;
            clear = true; 
            word = "";
            newstart = true;
        }
        if(word == "right")
        {
            cuberb.transform.position += new Vector3(1, 0, 0);
            deltimer = 0;
            clear = true;
            word = "";
            newstart = true;
        }
        if (word == "left")
        {
            cuberb.transform.position += new Vector3(-1, 0, 0);
            deltimer = 0;
            clear = true;
            word = "";
            newstart = true;
        }
        if (word == "up")
        {
            cuberb.AddForce(0, power * 200f, 0);
            deltimer = 0;
            clear = true;
            word = "";
            newstart = true;
        }
    }




}
