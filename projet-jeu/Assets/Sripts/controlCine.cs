using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class controlCine : MonoBehaviour
{
    //game object de objet que l'on veux bouger pour ne pas qu'il soit dans le chemin de l'animation
    public GameObject persoBouge;
    //objet permettant de commencer un 2e dialogue avec le personnage qui vien de bouger
    public GameObject obj2;
    //variable qui s'assure que l'animation ne ce fasse qu'une fois
    public static bool faireUne = true;

    public void ctrlAnim()
    {
        //activer l'animation
        this.GetComponent<Animator>().enabled = true;
        //bouger le joueur pour éviter les problèmes de collisions
        persoBouge.transform.position = new Vector3(-18.5f, -13.47f,0);
        //désactiver le collider de lobjet
        this.GetComponent<BoxCollider2D>().enabled = false;
        //activer obj2
        obj2.SetActive(true);
        //mettre faire une à faux
        faireUne = false;
    }
}
