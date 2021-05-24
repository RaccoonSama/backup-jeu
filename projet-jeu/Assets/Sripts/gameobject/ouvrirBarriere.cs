using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ouvrirBarriere : MonoBehaviour
{
    //variable pour déterminer si le monde de rêve est activé
    public static bool mondeEmotion = false;
    //varible pour activer le boss
    public GameObject boss;

    // Update is called once per frame
    void Update()
    {
        //si le monde d'emotion est actif
        if (mondeEmotion == true)
        {
            //activer le boss
            boss.SetActive(true);
        }
        else
        {
           // boss.SetActive(false);
        }
    }
}

