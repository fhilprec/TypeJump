using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody cuberb;
    [Range(0f,5f)]
    public float speed;
    public float power;
    private string word = "";
    public GameObject FadeOut;
    public GameObject tempInput;
    private bool clear = false;
    private float time;
    private int pos = 0;
    public AnimationClip PickUp;


    void Start()
    {
        cuberb = gameObject.GetComponent<Rigidbody>();
        cuberb.transform.position += new Vector3(0, 0, 30);
        
    }

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

    //Collision detection for Powerups
    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.gameObject.tag == "ModSpeedUp")
        {
            //Switch the animation
            collision.gameObject.GetComponent<Animator>().SetBool("PickedUp", true);
            collision.gameObject.GetComponent<FadeOut>().startFadind();
            speed *= 1.25f;
        }
        if (collision.gameObject.tag == "ModSpeedDown")
        {
            //Switch the animation
            collision.gameObject.GetComponent<Animator>().SetBool("PickedUp", true);
            collision.gameObject.GetComponent<FadeOut>().startFadind();
            speed *= 0.8f;
        }

    }

    
    public void ChangePosition(GameObject InputField)
    { 
        //reset Time if things are written
        time = 0;
        //needed if words should be cleared after 0.75 sec
        if (clear)
        {
            clear = false;
            word = "";
            InputField.GetComponent<InputField>().text = word;
            FadeOut.GetComponent<InputField>().text = word;
        }

        //Start the Fading animation
        InputField.GetComponent<Animator>().Play(0);

        word = InputField.GetComponent<InputField>().text;


        //Following if conditions start the animation of the second FadeOutField, delete the old word and move the cube
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
