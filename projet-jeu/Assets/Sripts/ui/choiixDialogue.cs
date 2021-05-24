using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class choiixDialogue : MonoBehaviour
{

   
    //dialogue quand le personnage rate son choix
    public dialogue mauvaisDia;

    
    //dialogues quand le personnage prends le bon choix
    public dialogue bondialogue;
    public dialogue bondialogue2;
    public dialogue bondialogue3;
    public dialogue bondialogue4;
    public dialogue bondialogue5;

    //variable de texte pour les choix
    public Text choixDroittxt;
    public Text choixGauchetxt;

    // string pour d�finir les choix � faire (bon)
    public string choixBon;
    public string choixBon2;
    public string choixBon3;
    public string choixBon4;
    public string choixBon5;

    // string pour d�finir les choix � faire (mauvais)
    public string choixMauvais;
    public string choixMauvais2;
    public string choixMauvais3;
    public string choixMauvais4;
    public string choixMauvais5;

    //variable permettant d'incr�menter le dialogue quand le jouer fait un choix
    public static int incrementChoix;
    //variable incr�mentant quand le personnage fait un bon choix
    public int incrementBon;
    //la variable pour le choix de d�part
    public int choix = 8;
    //variable pour s'assurer que le choix ne ce fasse que lorseque le personnage en � le choix
    public bool executer1Fois = true;
    //arrays pour choisir quelle suite de choix sera la bonne (avec 1 ou 0)
    public float[] suiteChoix;
    public float[] bonChoix;
    // game object pour activer le texte des choix
    public GameObject texteChoix;

    //variable pour dire que le personnage fait un choix
    public static bool enChoix = false;
    //variable pour dire que le personnage � rat� son choix
    public static bool choixRate = false;
    //variable pour dire que le dialogue est fini
    public static bool finDialogue = false;

    //fonction pour quand le personnage � un choix
    public void avoirChoix()
    {
        //appeler choixTxtDialogue
        choixTxtDialogue();
        //faire que le personnage soit en position de choix
        enChoix = true;
        //activer le texte de choix
        texteChoix.SetActive(true);
    }
    
    public void Start()
    {
        //mettre le choix � 8 pour �viter les probl�mes de s�lection de choix
        choix = 8;
        //mettre le compteur de choix � 0
        incrementChoix = 0;
    }

    public void FixedUpdate()
    {

        //si la touche C est appuyer et que le personnage est en choix
        if (Input.GetKey(KeyCode.C) && enChoix)
        {
            
            
           
            enChoix = false;
            //d�sactiver le texte de choix
            texteChoix.SetActive(false);
            // faire que executer1Fois soit vrai
            executer1Fois = true;

            //si le chiffre � la place du array correspondant � la position de incrementChoix est �gal � 0
            if (bonChoix[incrementChoix] == 0)
            {
                // le choix est �gal � 0
                choix = 0;
            
            }
            //sinon
            else
            {   
                //commencer le dialogue du mauvais choix
                FindObjectOfType<dialogueManager>().commenceDialogue(mauvaisDia);
                //faire que choixRate est vrai
                choixRate = true;
            }
            
        }
        else if (Input.GetKey(KeyCode.V) && enChoix)
        {

            //faire qu'il ne soit plus en choix
            enChoix = false;
            //d�sactiver le texte de choix
            texteChoix.SetActive(false);
            // faire que executer1Fois soit vrai
            executer1Fois = true;


            //si le chiffre � la place du array correspondant � la position de incrementChoix est �gal � 1
            if (bonChoix[incrementChoix] == 1)
            {
                // le choix est �gal � 1
                choix = 1;
                

            }
            //sinon
            else
            {  //commencer le dialogue du mauvais choix
                FindObjectOfType<dialogueManager>().commenceDialogue(mauvaisDia);
                //faire que choixRate est vrai
                choixRate = true;
            }

        }
        //si le array de suiteChoix correspond au array de bonChoix
        if (suiteChoix.SequenceEqual(bonChoix))
        {
            //si le choix est �gale au chiffre � la place du array correspondant � la position de incrementChoix et que exectuee1Fois est vrai
            if (choix == bonChoix[incrementChoix] && executer1Fois)
            {
                //si le incrementChoix est plus petit ou �gale � 3
              if(incrementChoix <= 3)  {
                    //incr�menter incrementChoix
                    incrementChoix++;
                   //incr�menter incrementBon
                    incrementBon++;
                    // faire que exectuer1Fois est faux pour emp�cher la condition de looper
                    executer1Fois = false;
                }
              //si incrementChoix est �gal � 4
              else if(incrementChoix == 4)
              { 
                   //incr�menter incrementBon
                    incrementBon++;
                    // faire que exectuer1Fois est faux pour emp�cher la condition de looper
                    executer1Fois = false; 
                
                }
                //switch pour la valeur de incrementbon
                switch (incrementBon)
                {
                    //si la valeur de incrementBon est 1
                    case 1:
                        Debug.Log("etape 1");
                        //commencer le bon dialogue correspondant � sa valeur
                        FindObjectOfType<dialogueManager>().commenceDialogue(bondialogue);
                        break;
                    //si la valeur de incrementBon est 2
                    case 2:
                        Debug.Log("etape 2");
                        //commencer le bon dialogue correspondant � sa valeur
                        FindObjectOfType<dialogueManager>().commenceDialogue(bondialogue2);
                        break;
                    //si la valeur de incrementBon est 3
                    case 3:
                        Debug.Log("etape 3");
                        //commencer le bon dialogue correspondant � sa valeur
                        FindObjectOfType<dialogueManager>().commenceDialogue(bondialogue3);
                        break;
                    //si la valeur de incrementBon est 4
                    case 4:
                        Debug.Log("etape 4");
                        //commencer le bon dialogue correspondant � sa valeur
                        FindObjectOfType<dialogueManager>().commenceDialogue(bondialogue4);
                        break;
                    //si la valeur de incrementBon est 5
                    case 5:
                        Debug.Log("fin");
                        //d�finir que le dialogue est fini
                        finDialogue = true;
                        //commencer le bon dialogue correspondant � sa valeur
                        FindObjectOfType<dialogueManager>().commenceDialogue(bondialogue5);
                        break;
                }
            }
        }

    }

    // fonction pour d�finir de quel cot� le bon et le mauvais dialogue seront
    public void choixTxtDialogue()
    {
        //si le chiffre � la place du array correspondant � la position de incrementChoix est �gal � 1
        if (bonChoix[incrementChoix] == 1)
        {

            //switch pour la valeur de incrementBon

            /*
             *  faire que le bon choix soit � droit et que le mauvais choix soit � gauche au fur et a mesure que l'�change de dialogue avance
             *
             */
            switch (incrementBon)
            {
                //si la valeur de incrementBon est 0
                case 0:
                    choixDroittxt.text = choixBon;
                    choixGauchetxt.text = choixMauvais;
                    break;
                //si la valeur de incrementBon est 1
                case 1:
                    choixDroittxt.text = choixBon2;
                    choixGauchetxt.text = choixMauvais2;
                    break;
                //si la valeur de incrementBon est 2
                case 2:
                    choixDroittxt.text = choixBon3;
                    choixGauchetxt.text = choixMauvais3;
                    break;
                //si la valeur de incrementBon est 3
                case 3:
                    choixDroittxt.text = choixBon4;
                    choixGauchetxt.text = choixMauvais4;
                    break;
                //si la valeur de incrementBon est 4
                case 4:
                    choixDroittxt.text = choixBon5;
                    choixGauchetxt.text = choixMauvais5;
                    break;
            }
        }
        //si le chiffre � la place du array correspondant � la position de incrementChoix est �gal � 0

        /*
            *  faire que le bon choix soit � gauche et que le mauvais choix soit � droit au fur et a mesure que l'�change de dialogue avance
            *
            */
        else if (bonChoix[incrementChoix] == 0)
        {
            //switch pour la valeur de incrementBon
            switch (incrementBon)
            {
                //si la valeur de incrementBon est 0
                case 0:
                    choixDroittxt.text = choixMauvais;
                    choixGauchetxt.text = choixBon;
                    break;
                //si la valeur de incrementBon est 1
                case 1:
                    choixDroittxt.text = choixMauvais2;
                    choixGauchetxt.text = choixBon2;
                    break;
                //si la valeur de incrementBon est 2
                case 2:
                    choixDroittxt.text = choixMauvais3;
                    choixGauchetxt.text = choixBon3;
                    break;
                //si la valeur de incrementBon est 3
                case 3:
                    choixDroittxt.text = choixMauvais4;
                    choixGauchetxt.text = choixBon4;
                    break;
                //si la valeur de incrementBon est 4
                case 4:
                    choixDroittxt.text = choixMauvais5;
                    choixGauchetxt.text = choixBon5;
                    break;
            }
        }
    }
    
}
