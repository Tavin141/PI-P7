using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida_perdida5 : MonoBehaviour
{
    
    private bool vidaLost;
    public SpriteRenderer sprite;
    public static bool morto;

    // Start is called before the first frame update
    void Start()
    {
        vidaLost = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Behaviour.vida <= 0 )
        {


            sprite.enabled = false;

            morto = true;
        

        }
        if (Checkpoint.check == true && Player_Behaviour.vida == 5)
        {

            sprite.enabled = true;


        }
    }
}
