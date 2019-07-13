using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public void IrParaOMenu()
    {
        SceneManager.LoadScene("Menuinicial");
    }
    public void JogarDenovo()
    {
        SceneManager.LoadScene("Persona PI");
    }
}
