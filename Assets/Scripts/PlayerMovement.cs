using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody cuberb;
    [Range(0.5f,5f)]
    public float speed;
    public float jumptime = 3;
    public float power;
    private string word = "";
    public GameObject FadeOut;
    public GameObject tempInput;
    private bool clear = false;
    private float time;



    // Start is called before the first frame update
    void Start()
    {
        cuberb = gameObject.GetComponent<Rigidbody>();
        cuberb.transform.position += new Vector3(0, 0, 30);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        jumptime += Time.deltaTime;
        time += Time.deltaTime;
        tempInput.GetComponent<InputField>().Select();


        cuberb.transform.position += new Vector3(0, 0, 10f * speed) * Time.deltaTime;

        if(time > 0.75f)
        {
            clear = true;
            ChangePosition(tempInput);

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            Debug.Log("Bam");
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            speed = 0;

            //Hier Neustart Screen starten

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

            word = "";
            InputField.GetComponent<InputField>().text = "";
            cuberb.transform.position += new Vector3(1, 0, 0);
            
        }
        else if (word == "left" && gameObject.transform.position.x >= -1.9f)
        {
            FadeOut.GetComponent<InputField>().text = word;
            FadeOut.GetComponent<Animator>().Play(0);

            word = "";
            InputField.GetComponent<InputField>().text = "";
            cuberb.transform.position += new Vector3(-1, 0, 0);
        }
        else if (word == "jump" && jumptime > 3f )
        {
            FadeOut.GetComponent<InputField>().text = word;
            FadeOut.GetComponent<Animator>().Play(0);

            word = "";
            InputField.GetComponent<InputField>().text = "";
            cuberb.AddForce(0, 10000f * Time.deltaTime * power, 0) ;
            jumptime = 0;
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
