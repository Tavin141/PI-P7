﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida_perdida3 : MonoBehaviour
{
    
    private bool vidaLost;
    public SpriteRenderer sprite;
    public static bool bn;

    // Start is called before the first frame update
    void Start()
    {
        vidaLost = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Behaviour.vida <= 2 && vidaLost)
        {
            sprite.enabled = false;
        }
        if (Player_Behaviour.vida == 2 && cura.vidaGain == true)
        {
            sprite.enabled = true;
            cura.vidaGain = false;
            Player_Behaviour.vida = 3;
            Debug.Log("deu certo");
        }
        if(Player_Behaviour.restore == true && Player_Behaviour.vida == 5)
        {
            sprite.enabled = true;
        }
    }
}