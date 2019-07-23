using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Voltar : MonoBehaviour
{

    void Start()
    {
        StartCoroutine("FadeOut");
    }
    public void Volta()
    {
        SceneManager.LoadScene("Menuinicial");
    }
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject.Find("nomes").GetComponent<Animator>().SetBool("aparecer", true); 
    }
}
