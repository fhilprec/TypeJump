using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody cuberb;
    [Range(0.5f,5f)]
    public float speed;
    public float power;
    private string word = "";
    public GameObject FadeOut;
    public GameObject tempInput;
    private bool clear = false;
    private float time;
    private int pos = 0;



    // Start is called before the first frame update
    void Start()
    {
        cuberb = gameObject.GetComponent<Rigidbody>();
        cuberb.transform.position += new Vector3(0, 0, 30);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        tempInput.GetComponent<InputField>().Select();


        cuberb.transform.position += new Vector3(0, 0, 10f * speed) * Time.deltaTime;

        if(time > 0.75f)
        {
            clear = true;
            ChangePosition(tempInput);

        }

        //guarantees that the x-position is an integer value;
        cuberb.transform.position = new Vector3(pos, cuberb.transform.position.y, cuberb.transform.position.z);



    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            speed = 0;

            //Hier Neustart Screen starten

        }

    }

    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.gameObject.tag == "ModSpeedUp")
        {
            Debug.Log("PowerUp Gesammelt");
            collision.gameObject.SetActive(false);
        }
    }

    public void ChangePosition(GameObject InputField)
    { 
        time = 0;
        if (clear)
        {
            clear = false;
            if(word != "") { Debug.Log(word[word.Length - 1]); }
            
            word = "";
            InputField.GetComponent<InputField>().text = word;
            FadeOut.GetComponent<InputField>().text = word;
        }


        InputField.GetComponent<Animator>().Play(0);

        word = InputField.GetComponent<InputField>().text;

        if(word == "right" && gameObject.transform.position.x <= 1.9f)
        {
            FadeOut.GetComponent<InputField>().text = word;
            FadeOut.GetComponent<Animator>().Play(0);
            pos++;
            word = "";
            InputField.GetComponent<InputField>().text = "";
            
            
        }
        else if (word == "left" && gameObject.transform.position.x >= -1.9f)
        {
            FadeOut.GetComponent<InputField>().text = word;
            FadeOut.GetComponent<Animator>().Play(0);
            pos--;
            word = "";
            InputField.GetComponent<InputField>().text = "";

        }
        else if (word == "jump" && cuberb.transform.position.y < 0.1f )
        {
            FadeOut.GetComponent<InputField>().text = word;
            FadeOut.GetComponent<Animator>().Play(0);

            word = "";
            InputField.GetComponent<InputField>().text = "";
            cuberb.AddForce(0, 10000f * Time.deltaTime * power, 0) ;
        }
        else if(word.Length >= 5 || word == "left" && gameObject.transform.position.x < -1.9f)
        {
            FadeOut.GetComponent<InputField>().text = word;
            FadeOut.GetComponent<Animator>().Play(0);

            word = "";
            InputField.GetComponent<InputField>().text = "";
        }


        

    }



}
