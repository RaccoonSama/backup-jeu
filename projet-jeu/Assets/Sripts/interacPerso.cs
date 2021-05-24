using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interacPerso : MonoBehaviour
{
    //variables

    /* dialogue venant du personnage */
    public dialogue dia;

    public dialogue dia2;

    public dialogue dia3;

    public dialogue dia4;

    /* variable de fin de niveau */

    public static bool tutoFini = false;

    public static bool tutoFini2 = false;

    public static bool anxieteFin = false;
    
    public static bool depressionFin = false;

    public static bool facheFin = false;

    /* variable de nom des personnage (pour l'affichage du texte) */
    public static string quiParle;
    public static string xtraInfoPerso;


    void Start()
    {

        //remettre toute les variables de fin de niveau a faux pour éviter les bugs avec les portes
        anxieteFin = false;
        depressionFin = false;
        facheFin = false;
        tutoFini = false;
        tutoFini2 = false;
        choiixDialogue.finDialogue = false;
    }
    //le fonction pour enclancher le dialogue 1
    public void triggerDialogue()
    {
        //commencer le dialogue avec le dialogue 1
        FindObjectOfType<dialogueManager>().commenceDialogue(dia);
    }
    //le fonction pour enclancher le dialogue 2
    public void triggerDialogue2()
    {
        //commencer le dialogue avec le dialogue 2
        FindObjectOfType<dialogueManager>().commenceDialogue(dia2);
    }
    //le fonction pour enclancher le dialogue 3
    public void triggerDialogue3()
    {
        //commencer le dialogue avec le dialogue 3
        FindObjectOfType<dialogueManager>().commenceDialogue(dia3);
    }
    //le fonction pour enclancher le dialogue 4
    public void triggerDialogue4()
    {
        //commencer le dialogue avec le dialogue 4
        FindObjectOfType<dialogueManager>().commenceDialogue(dia4);
    }

    void OnCollisionEnter2D(Collision2D interac)
    {
        //si on touche l'objet convoTrigger
        if (interac.gameObject.name == "convoTrigger")
        {
            //si tutofini est faux
            if (!tutoFini)
            {
                //quiparle est égale à porte
                quiParle = "porte";
                xtraInfoPerso = "porte";
                //commencer le dialogue1
                triggerDialogue();
            }
        }
        //si on touche l'objet porte
        else if (interac.gameObject.name == "porte")
        {
            //si tutofini est vrai 
            if (tutoFini)
            {
                //charger la scène de la porte
                SceneManager.LoadScene("maison-perso");
                //remettre les variable de tuto à faux
                tutoFini = false;
                tutoFini2 = false;
            }
        }
        //si on touche l'objet monstre
        else if (interac.gameObject.name == "monstre")
        {
            //quiparle est égale à 2perso
            quiParle = "2perso";
            //commencer le dialogue2
            triggerDialogue2();
            tutoFini = true;
        }
        //si on touche l'objet mere
        else if (interac.gameObject.name == "mere")
        {
            //xtraInfoPerso est égale à mere
            xtraInfoPerso = "mere";
            //quiparle est égale à 2perso
            quiParle = "2perso";
            //commencer le dialogue 2
            triggerDialogue2();
            //enCine = vrai
            mouvementPerso.enCine = true;
        }
        //si on touche l'objet convotrigger2
        else if (interac.gameObject.name == "convoTrigger-2")
        {
            //si tutofini est faux
            if (!tutoFini2)
            {
                //quiparle est égale à porte
                quiParle = "porte";
                //commencer le dialogue 1
                triggerDialogue();
            }
        }
        //si on touche l'objet porte 2
        else if (interac.gameObject.name == "porte-2")
        {
            //si tutofini2 est vrai
            if (tutoFini2)
            {
                //charger la scène de dehors
                SceneManager.LoadScene("dehors1");
            }
        }
        //si on touche l'objet collider2
        else if (interac.gameObject.name == "collider2")
        {
            //quiparle est égale à 2perso
            quiParle = "2perso";
            //xtraInfoPerso est égale à mere
            xtraInfoPerso = "mere";
            //commencer le dialogue 3
            triggerDialogue3();
            //tuto fini 2 est égale à vrai
            tutoFini2 = true;
        }
        //si l'on touche l'objet convoTrigger-3 
        else if (interac.gameObject.name == "convoTrigger-3")
        {
            // et que anxieteFin est faux
            if (!anxieteFin)
            {
                //quiparle est égale à porte
                quiParle = "porte";
                //commencer le dialogue 1
                triggerDialogue();
            }
        }
        //si on touche l'objet porte 3
        else if (interac.gameObject.name == "porte-3")
        {
            // et que anxieteFin est vrai
            if (anxieteFin)
            {
                //charger la scène de dehors
                SceneManager.LoadScene("dehors2");
            }
        }
        //si on touche l'objet anxiete
        else if (interac.gameObject.name == "anxiete")
        {
            //les informations relatives à anxiete s'ajuste
            quiParle = "2perso";
            xtraInfoPerso = "anxiete";
            //on commence le dialogue 3
            triggerDialogue3();
        }
        //si on touche l'objet boss
        else if (interac.gameObject.name == "boss")
        {
            //les informations relatives au boss s'ajuste
            quiParle = "2perso";
            xtraInfoPerso = "boss";
            //on commence le dialogue 4
            triggerDialogue4();
        }
        // si on touche l'objet maison-bleu
        else if (interac.gameObject.name == "maison-bleu")
        {
            //on charge la scène du même nom
            SceneManager.LoadScene("maison-bleu");
        }
        //si on touche l'objet cafe-porte
        else if (interac.gameObject.name == "cafe-porte")
        {
            //on charge la scène du cafe
            SceneManager.LoadScene("cafe");
        }
        //si on touche l'objet depression
        else if (interac.gameObject.name == "depression")
        {
            //les informations relatives à depression s'ajuste
            quiParle = "2perso";
            xtraInfoPerso = "depression";
            //on commence le dialogue 2
            triggerDialogue2();
        }
        //si on touche l'objet porte 4
        else if (interac.gameObject.name == "porte-4")
        {
            //si depressionFin est vrai
            if (depressionFin)
            {
                //charger la scène de dehors3
                SceneManager.LoadScene("dehors3");
            }
        }
        //si on touche l'objet fache
        else if (interac.gameObject.name == "fache")
        {
            //les informations relatives à faché s'ajuste
            quiParle = "2perso";
            xtraInfoPerso = "fache";
            //on commence le dialogue 2
            triggerDialogue2();
        }
    }


    public void Update()
    {
        
        //si la touche e est appuyée
        if (Input.GetKeyUp(KeyCode.E) && !choiixDialogue.enChoix)
        {
            //aller à la prochaine phrase
            FindObjectOfType<dialogueManager>().prochainePhrase();
            
        }
    }

}


