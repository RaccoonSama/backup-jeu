using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mondeReve : MonoBehaviour
{
    //game object du filtre de camera pour les couleurs
    public GameObject EffetReve;
    //game object du mur bloquant l'acces au monde de rêve
    public GameObject Blocage;
    //game object de la tile map du monde de êve
    public GameObject mondeReves;

    void Start()
    {
        //remettre les variable à faux pour (on le refait au cas ou l'autre n'a pas fonctionner)
        Debug.Log("faux");
        interacPerso.anxieteFin = false;
        interacPerso.depressionFin = false;
        interacPerso.facheFin = false;
        interacPerso.tutoFini = false;
        interacPerso.tutoFini2 = false;
    }
    //fonction pour fermer le monde de rêve
    public void fermeeMondeReve()
    {
        //désactiver l'effet du monde de rêve
        EffetReve.SetActive(false);
        // désactiver le boss
        ouvrirBarriere.mondeEmotion = false;

        //si la scène active est maison-bleu
        if (SceneManager.GetActiveScene().name == "maison-bleu")
        {
            //rendre anxieteFin vrai
            interacPerso.anxieteFin = true;
        }//si la scène active est cafe
        else if (SceneManager.GetActiveScene().name == "cafe")
        {
            //rendre depressionFin vrai
            interacPerso.depressionFin = true;
        }//si la scène active est dehors3
        else if (SceneManager.GetActiveScene().name == "dehors3")
        {
            //rendre facheFin vrai
            interacPerso.facheFin = true;
        }
       
    }
    //fonction pour activer le monde de rêve
    public void activeMondeReve()
    {
        //activer l'effet du monde de rêve
        EffetReve.SetActive(true);
        //si la scène charger est maison-bleu ou cafe
    if(SceneManager.GetActiveScene().name == "maison-bleu" || SceneManager.GetActiveScene().name == "cafe") {
            //desactiver le blocage et activer la tilemap du monde de rêve
            Blocage.SetActive(false);
            mondeReves.SetActive(true);
        }
    //rendre monde emotion vrai
        ouvrirBarriere.mondeEmotion = true;
    }
}
