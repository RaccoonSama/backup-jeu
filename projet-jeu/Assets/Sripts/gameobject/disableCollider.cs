using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class disableCollider : MonoBehaviour
{
    //composante pour le collider de l'objet
    public Collider2D boxColli;
    //gameobjet pour le convoTrigger
    public GameObject convoTrigger;

    // Start is called before the first frame update
    void Start()
    {
        //faire que bocColli soit égale au composante de boxCollider2D  
        boxColli = GetComponent<BoxCollider2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        //si tuto fini ou tuto fini 2 ou anxieteFin ou interacPerso est vrai
        if (interacPerso.tutoFini || interacPerso.tutoFini2 || interacPerso.anxieteFin || interacPerso.depressionFin)
        {
            //rendre l'objet convotrigger non actif
            convoTrigger.SetActive(false);
            //le collider est activer
            boxColli.enabled = true;
        }
       

       
      
    }
}
