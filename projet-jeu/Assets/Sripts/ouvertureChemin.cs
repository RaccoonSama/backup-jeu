using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ouvertureChemin : MonoBehaviour
{

    //le game object de la barriere bloquant le chemin au monde de reve
    public GameObject barriere;
    //game object pour le contour de la barrière
    public GameObject contourBarriere;
    // Start is called before the first frame update
    void Start()
    {
        barriere.SetActive(false);
        contourBarriere.SetActive(false);
    }

   
}
