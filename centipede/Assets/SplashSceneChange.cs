using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSceneChange : MonoBehaviour
{

    public float delay = 2f;
    public string nextScene = "";

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
            SceneManager.LoadScene(nextScene);
    }
}
