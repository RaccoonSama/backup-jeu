using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    //variables de texte du nom des personnages
    public Text nomPersotext;
    //variable de texte pour mettre les phrases
    public Text textePhrase;
    //chaine de charactère pour le nom du premier personnage
    public string diaNom;
    //chaine de charactère pour le nom du deuxième personnage
    public string diaNom2;

    //variables pour savoir si le personnage affiché est celui qui parle
    public bool persoOui = true;

    public bool persoNon = false;

    //compteur pour savoir combien de choix on été fais dans la suite de dialogues
    public int compteurChoix = 0;

    //game object pour les objets relatifs au dialogues
    public GameObject fenetreText;// la fenêtre de texte

    public GameObject canvasConvo;// le canvas pour le texte de la conversation et autres

    public GameObject imagePerso1; // l'image du premier perso

    public GameObject imagePerso2;// l'image du deuxième perso

    //game object pour appeler un script qui lui est attribuer
    public GameObject appelerScriptDunPerso;

    //variable de mise en attente des phrases
    private Queue<string> phrases;
    //variable pour controller le sprite des dialogues
    public Sprite porte, perso, persoB, tel;



   



    // Start is called before the first frame update
    void Start()
    {
        //indexer les phrases de la queue dans la variable phrases
        phrases = new Queue<string>();
       
    }

    public void commenceDialogue(dialogue dialogues)
    {
      
     
        //afficher les noms
        diaNom = dialogues.nom;
        diaNom2 = dialogues.nom2;
        //activerles images et les composantes de dialogues
        imagePerso1.SetActive(true);
        fenetreText.SetActive(true);
        canvasConvo.SetActive(true);
        //appeler la fonction pour voir qui parle
        voirQuiParle();
        //indexer la la personne qui parle dans la balise de nom
        nomPersotext.text = dialogues.nom;

        
        //éffaces les données présente dans phrases
        phrases.Clear();
        //indexer toutes phrases des dialogues
        foreach (string phrase in dialogues.phrases)
        {
            phrases.Enqueue(phrase);
        }
        //aller à la prochaine phrase
        prochainePhrase();
    }


    public void prochainePhrase()
    {
       
        //si le choix est raté, remettre le compteur à 0
        if (choiixDialogue.choixRate)
        {
            compteurChoix = 0;
            
        }
        
        //si il n'y a plus de phrases dans le dialogue
        if (phrases.Count == 0 && !choiixDialogue.enChoix)
        {
            //si le perso qui parle est 2perso
            if (interacPerso.quiParle == "2perso")
            {
                //finir invoquer convoFini()
                convoFini();
                //si le perso extra est la mere et que faire une est vrai
                if (interacPerso.xtraInfoPerso == "mere" && controlCine.faireUne) 
                {
                    //appeler l'animation
                    appelerScriptDunPerso.GetComponent<controlCine>().ctrlAnim();
                }
                // si le personnage est le boss et que la variable fin de dialogue est vrai
                if (interacPerso.xtraInfoPerso == "boss"  && choiixDialogue.finDialogue)
                {
                    //appeler la fonction pour fermer le monde de rêve
                    FindObjectOfType<mondeReve>().fermeeMondeReve();
                }
            }
           
            //finir les dialogues
            dialogueFin();
            return;
        }
        //si il reste 2 phrases dans le dialogues et que le perso extra est la mere et que tutofini2 est faux
        if (phrases.Count == 2 && interacPerso.xtraInfoPerso == "mere" && !interacPerso.tutoFini2)
        {
            //changer le nom pour telephone
            nomPersotext.text = "Téléphone";
            //changer le sprite pour le telephone
            imagePerso2.GetComponent<SpriteRenderer>().sprite = tel;
        }
        //si il reste une phrase dans la file et que le personnage extra est anxiété, dépression ou fâché
       if (phrases.Count == 1 && (interacPerso.xtraInfoPerso == "anxiete" || interacPerso.xtraInfoPerso == "depression" || interacPerso.xtraInfoPerso == "fache"))
       {
            // appeler la fonction pour activer le monde de rêve
            FindObjectOfType<mondeReve>().activeMondeReve();
           
        }
       //si il reste une phrase dans la file et que le personnage extra est boss et que le personnage n'est pas en choix et que le compteur de choix est en dessous de 5 et que le personnage n'a pas raté son choix
       if (phrases.Count == 1 && interacPerso.xtraInfoPerso == "boss" && !choiixDialogue.enChoix && compteurChoix < 5 && !choiixDialogue.choixRate)
       {
           //incrémenter le compteur de choix
           compteurChoix++;
           //appeler la fonction pour mettre le personnage en choix
           FindObjectOfType<choiixDialogue>().avoirChoix();
       }


        // si il reste des phrases
        else if (phrases.Count != 0)
        {
            //si le quiparle n'est pas la porte
            if (interacPerso.quiParle != "porte")
            {
                //appeler alternerImage();
                alternerImage();
                persoOui = !persoOui;
                persoNon = !persoNon;
            }
          
         
        }
       





        //decomposer le nombres de phrases dans le dialogue et commencer ecrirePhrases()
        string phrase = phrases.Dequeue();
        textePhrase.text = phrase;
        StopAllCoroutines();
        StartCoroutine(ecrirePhrase(phrase));
    }
    //faire apparaitre les lettres une par une
    IEnumerator ecrirePhrase(string phrase)
    {
        //mettre la phrase vide
        textePhrase.text = "";
        //aller chercher toutes les lettre dans la phrases
        foreach (char letter in phrase.ToCharArray())
        {
            //mettre la lettre dans le texte
            textePhrase.text += letter;
            //attendre 0.05f et recommencer
            yield return new WaitForSeconds(0.05f);
        }
    }

    //tout désactiver à la fin de la convo
    void dialogueFin()
    {

        //désactiver les composantes d'affichage de la boite de dialogue
        fenetreText.SetActive(false);
        canvasConvo.SetActive(false);
        imagePerso1.SetActive(false);
        imagePerso2.SetActive(false);
    }


    //changer les sprites en fonction de la personne qui parle
    public void voirQuiParle()
    {
      
        // si qui parle est une porte
        if (interacPerso.quiParle == "porte")
        {   
            //changer le sprite pour la porte
            imagePerso1.GetComponent<SpriteRenderer>().sprite = porte;

        }
        //si qui parler est 2perso
        else if (interacPerso.quiParle == "2perso")
        {
            //mettre les images pour les perso a et b
            imagePerso1.GetComponent<SpriteRenderer>().sprite = perso;
            imagePerso2.GetComponent<SpriteRenderer>().sprite = persoB;
        }
       



    }

    public void alternerImage()
    {
       
        //si perso oui est vrai
        if (persoOui)
        {
            //changer le nomm du perso a nom1
            nomPersotext.text = diaNom;
        }
        //si perso oui est faux
        else if (!persoOui)
        {   
            //changer le nomm du perso a nom2
            nomPersotext.text = diaNom2;
        }




        //activer les images
        imagePerso1.SetActive(persoOui);
        imagePerso2.SetActive(persoNon);
    }
    //remmettre à normal après la cinématique
    public void convoFini()
    {
        //faire que le personnage n'est plus en cinématique
        mouvementPerso.enCine = false;

    }

    

}
