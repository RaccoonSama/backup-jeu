using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Input = UnityEngine.Input;

public class relanceScene : MonoBehaviour
{
    //varible pour prendre le nom de la scène
    public string nomDeScene;
    // Start is called before the first frame update
    void Start()
    {
        //faire que la varible soit équivalente au nom de la scène active
        nomDeScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        //si la touche r est enfoncé
        if (Input.GetKey(KeyCode.R))
        {
            //charger la scène active et fermer toutes les autres scènes actives
            SceneManager.LoadScene(nomDeScene, LoadSceneMode.Single);
        }
    }
}
