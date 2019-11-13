using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody cuberb;
    [Range(0.5f,5f)]
    public float speed;
    private string word;


    // Start is called before the first frame update
    void Start()
    {
        cuberb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cuberb.transform.position += new Vector3(0, 0, 10f * speed) * Time.deltaTime;
    }


    public void ChangePosition(GameObject InputField)
    {
        word = InputField.GetComponent<InputField>().text;
        Debug.Log(word);

        if(word == "right")
        {
            word = "";
            InputField.GetComponent<InputField>().text = "";
            cuberb.transform.position += new Vector3(1, 0, 0);
        }
        if (word == "left")
        {
            word = "";
            InputField.GetComponent<InputField>().text = "";
            cuberb.transform.position += new Vector3(-1, 0, 0);
        }

    }



}
