using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cura : MonoBehaviour
{



    public static bool vidaGain;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (Player_Behaviour.vida <= 4)
        {


            if (collision.tag == "Player")
            {

                vidaGain = true;

                Destroy(gameObject);
            }
        }


    }
}
