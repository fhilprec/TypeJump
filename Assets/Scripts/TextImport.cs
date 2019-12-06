using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextImport : MonoBehaviour
{
    public GameObject player;
    public int maxWords = 1000;
    private List<string> words = new List<string>();
    public int wordsmaxlength = 8;
    public int wordsminlength = 3;
    public string left, right, jump;
    private int currentwords;



    public string changeWord(GameObject textfield)
    {

        string word = words[Random.Range(0, currentwords)];
        while(word == left || word == right || word == jump)
        {
            Debug.Log("I found one");
            Debug.Log(word + "--" + left + "--" + right + "--" + jump); 
            word = words[Random.Range(0, currentwords)];

        }
        Debug.Log(left + "--" + jump + "--" + right);
        textfield.GetComponent<Text>().text = word;
        return word;
    }





    void Start()
    {
        //Script for turning the text file to an array of strings
        currentwords = 0;
        string tempstring = "";
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Florian\Documents\GitHub\TypeJump\Assets\Scripts\text.txt");
        for (int i = 0; i < lines.Length; i++)
        {
            for(int j = 0; j < lines[i].Length; j++)
            {
                int asci = lines[i][j];
                //very bad Solution should be fixed later
                //if (lines[i][j] != ' ' && lines[i][j] != '.' && lines[i][j] != ',' && lines[i][j] != '!' && lines[i][j] != '?' &&  lines[i][j] != '(' && lines[i][j] != '–')
                if(asci >= 'a' && asci <= 'z' || asci >= 'A' && asci <= 'Z' || asci == 'ä' || asci == 'ö' || asci == 'ü' || asci == 'Ä' || asci == 'Ö' || asci == 'Ü' || asci == 'ß')
                {

                    tempstring += lines[i][j];
                }
                else { 
                    if(currentwords < maxWords && tempstring != "" && tempstring.Length < wordsmaxlength && tempstring.Length > wordsminlength)
                    {
                        if(tempstring != null)
                        {
                            words.Add(tempstring);
                            currentwords++;
                            //Debug.Log(words[currentwords]);
                        }


                    }
                                    
                    tempstring = "";
                
                }
                
            }
            
        }

      


    }

}

