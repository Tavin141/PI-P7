using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Voltar : MonoBehaviour
{
    public void Volta()
    {
        SceneManager.LoadScene("Menuinicial");
    }
}
