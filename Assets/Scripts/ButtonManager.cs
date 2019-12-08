using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public void newGame()
    {
        SceneManager.LoadScene("Game");
    }
}
