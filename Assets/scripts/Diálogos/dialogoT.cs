using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogoT : MonoBehaviour
{
    public dialogos dialogo;
        

    public void ativarD ()
    {
       
        FindObjectOfType<ativadorD>().ComecarD(dialogo);
       
       
    }

   
}
