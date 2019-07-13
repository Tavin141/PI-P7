using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perseguicao : MonoBehaviour
{
    
    public Transform Player;
    public float velocidade;
    
    void Update()
    {
        float distancia = Vector2.Distance(transform.position,Player.position);

        if (distancia > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, velocidade * Time.deltaTime);

        }
    }
}
