using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boutonJouer : MonoBehaviour
{
   
    //fonction pour commencer le jeu
    public void btnJouer()
    { 
        //commencer la scene intro
        SceneManager.LoadScene("intro");
    }
}
