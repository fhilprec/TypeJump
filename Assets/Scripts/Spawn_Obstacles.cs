using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Obstacles : MonoBehaviour
{
    public GameObject Player;
    public GameObject Obstacle_small;
    public GameObject Obstacle_big;
    public GameObject[] mods;

    public int interval = 30;
    public int spawnrange = 2;
    [Range(0f,1f)]
    public float chance = 0.5f;
    [Range(0f, 1f)]
    public float bigchance = 0.5f;
    [Range(0f, 1f)]
    public float modchance = 1f;
    private Vector3 lastposition = new Vector3(0,0,0);

    private void Start()
    {
        lastposition = Player.transform.position;

        for (int i = 0; i < spawnrange - 1; i++)
        {
            float tempbigchance = bigchance;
            for (int j = 0; j < 5; j++)
            {

                if (Random.Range(0f, 1f) < chance)
                {
                    if (Random.Range(0f, 1f) < tempbigchance)
                    {
                        GameObject obs = GameObject.Instantiate(Obstacle_big) as GameObject;
                        obs.transform.position = new Vector3(0, 0.5f, interval + i * interval) + new Vector3(0, 0, (int)Player.transform.position.z) + new Vector3(j - 2, 0, 0 +interval);
                        tempbigchance -= 0.25f;
                    }
                    else
                    {
                        GameObject obs = GameObject.Instantiate(Obstacle_small) as GameObject;
                        obs.transform.position = new Vector3(0, 0, interval * 2 + i * interval) + new Vector3(0, 0, (int)Player.transform.position.z) + new Vector3(j - 2, 0, 0 + interval);
                    }
                }
                else if (Random.Range(0f, 1f) < modchance)
                {
                    GameObject obs = GameObject.Instantiate(mods[0]) as GameObject;
                    obs.transform.position = new Vector3(0, 0.75f, interval * 2 + i * interval) + new Vector3(0, 0, (int)Player.transform.position.z) + new Vector3(j - 2, 0, 0);

                }
            }


        }
        lastposition = Player.transform.position;
    }

        // Update is called once per frame
        
        void FixedUpdate()
        {
            if (Player.transform.position.magnitude - lastposition.magnitude > interval)
            {
                lastposition = Player.transform.position;
                float tempbigchance = bigchance;
                for (int j = 0; j < 5; j++)
                {

                    if (Random.Range(0f, 1f) < chance)
                    {
                        if (Random.Range(0f, 1f) < tempbigchance)
                        {
                            GameObject obs = GameObject.Instantiate(Obstacle_big) as GameObject;
                            obs.transform.position = new Vector3(0, 0.5f, interval + (spawnrange-1) * interval) + new Vector3(0, 0, (int)Player.transform.position.z) + new Vector3(j - 2, 0, 0);
                            tempbigchance -= 0.25f;
                        }
                        else
                        {
                            GameObject obs = GameObject.Instantiate(Obstacle_small) as GameObject;
                            obs.transform.position = new Vector3(0, 0, interval + (spawnrange-1) * interval) + new Vector3(0, 0, (int)Player.transform.position.z) + new Vector3(j - 2, 0, 0);
                        }
                    }
                    else if(Random.Range(0f, 1f) < modchance)
                {
                    GameObject obs = GameObject.Instantiate(mods[0]) as GameObject;
                    obs.transform.position = new Vector3(0, 0.75f, interval + (spawnrange - 1) * interval) + new Vector3(0, 0, (int)Player.transform.position.z) + new Vector3(j - 2, 0, 0);

                }

            }
            }
        }
        
    }
            
            


        
 

   

