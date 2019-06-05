using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public static bool check;
    // Start is called before the first frame update
    void Start()
    {
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Player_Behaviour.vida = 5;
            check = true;
        }
    }
}
