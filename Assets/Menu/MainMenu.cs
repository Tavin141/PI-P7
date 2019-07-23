using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Persona PI");
        }        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void creditos()
    {
        SceneManager.LoadScene("creditos");
    }
}
