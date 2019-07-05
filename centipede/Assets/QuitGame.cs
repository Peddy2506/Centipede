using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{

    public void GameQuit()
    {
        Debug.Log("I'm quitting");
        Application.Quit();
    }

}
