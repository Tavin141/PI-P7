using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text score;
    void Update()
    {
        score.text = Player_Behaviour.pontos.ToString();
    }
}
