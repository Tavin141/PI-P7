using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomadadeposicao4 : MonoBehaviour
{



    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Behaviour.vida == 0)
        {


            sprite.enabled = true;

        }
        if (vida_perdida.bn == true)
        {
            sprite.enabled = false;
        }


    }
}
