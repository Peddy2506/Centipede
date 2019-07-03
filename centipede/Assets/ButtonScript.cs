using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
   public void NewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
