using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cristal5 : MonoBehaviour
{
    public GameObject vida_perdida_1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Behaviour.vida == 4)
        {
            //Instantiate(laserPrefab, transform.position + new Vector3(0, 0.5f), Quaternion.identity);
            Instantiate(vida_perdida_1, transform.position + new Vector3(0, 0.5f), Quaternion.identity);

        }
    }
}
