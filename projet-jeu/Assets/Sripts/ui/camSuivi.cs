using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSuivi : MonoBehaviour
{
    //composant transform de l'objet
    public Transform Joueur;
  
    // Update is called once per frame
    void FixedUpdate()
    {
        //prendre la position de l'objet et l'implémenter à la caméra
        this.transform.position = new Vector3(Joueur.position.x, Joueur.position.y, Joueur.position.z);
    }
}
