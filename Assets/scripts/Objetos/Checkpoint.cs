using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator an;
    private bool aceso = false;


    // Update is called once per frame

   
    void Update()
    {
        an = GetComponent<Animator>();

        if (Player_Behaviour.check == true)
        {
            StartCoroutine("tempo");
            an.SetBool("Check", Player_Behaviour.check);
            an.SetBool("PontosPagos", Player_Behaviour.check);
            // a segunda condição de PontosPagos deveria ser os pontos necessários mas ainda não fiz isso
            an.SetBool("TimeIsOver", aceso);

        }
    }

   
    private IEnumerator tempo()
    {

        yield return new WaitForSeconds(2.2f);
        aceso = true;
       
    }
  
       
}
