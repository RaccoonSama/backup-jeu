using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvementPerso : MonoBehaviour
{
    //vitesse du personnage
    public float vitessePerso = 5f;
    //compostante du rigid body
    public Rigidbody2D rb;
    //composante d'anmation pour animer un personnage
    public Animator animateur;
    //vecteur pour le mouvement du personnage
    private Vector2 mouvement;
    //variable pour déterminer si le personnage est dans une cinématique
    public static bool enCine = false;

    

    // Update is called once per frame
    void Update()
    {   
        //si enCine est faux
        if (!enCine)
        {
            //indexer les mouvements dans des variables
            mouvement.x = Input.GetAxisRaw("Horizontal");
            mouvement.y = Input.GetAxisRaw("Vertical");
            //indexer les mouvements dans les variables d'animations
            animateur.SetFloat("horizontal", mouvement.x);
            animateur.SetFloat("vertical", mouvement.y);
            animateur.SetFloat("vitesse", mouvement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        //si enCine est faux
        if (!enCine)
        {
            //indexer les mouvement dans le rigid body
            rb.MovePosition(rb.position + mouvement * vitessePerso * Time.fixedDeltaTime);
        }
    }

}
