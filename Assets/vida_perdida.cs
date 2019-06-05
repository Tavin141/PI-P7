using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class vida_perdida : MonoBehaviour
{
    
    public SpriteRenderer sprite;
    private bool vidaGain;
    public static bool vidaLost;
    public static bool bn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Behaviour.vida <= 4 && vidaLost)
        {


            sprite.enabled = false;


           

        }


        if (Player_Behaviour.vida == 4 && cura.vidaGain == true)
        {


            sprite.enabled = true;


            Player_Behaviour.vida = 5;

            cura.vidaGain = false;



            Debug.Log("deu certo");


        }
        if (Checkpoint.check == true && Player_Behaviour.vida == 5)
        {

            sprite.enabled = true;


        }


    }

}


