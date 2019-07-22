using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ativadorD : MonoBehaviour
{
    public Queue<string> frases;
    public Text nometexto;
    public Text dialogotexto;
    public static bool fim;
    public Animator an;
    public GameObject botao;
    public GameObject pontos;
    public GameObject dica;
    public Animator ann;

    void Start()
    {
        frases = new Queue<string>();    
        fim = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DisplayNextSentence();
        }
    }

    public void ComecarD (dialogos dialogo)
    {
        nometexto.text = dialogo.nome;
        an.SetBool("con", true);
        ann.SetBool("con", true);

        frases.Clear();

        foreach (string frase in dialogo.frases)
        {
            frases.Enqueue(frase);
        }
        DisplayNextSentence();
    }
     public void DisplayNextSentence ()
    {
        if (frases.Count == 0)
        {
            FimDialogo();
            return;
        }

        string frase =frases.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(frase));

       
    }

     IEnumerator TypeSentence (string frase)
    {
        dialogotexto.text = "";
        foreach (char letras in frase.ToCharArray())
        {
            dialogotexto.text += letras;
            yield return null;
            
        }
    }
     
    void FimDialogo()
    {
        an.SetBool("con", false);
        ann.SetBool("con", false);
        Destroy(this.botao);
        Destroy(this.pontos);
        Destroy(this.dica);

    }


  
}
