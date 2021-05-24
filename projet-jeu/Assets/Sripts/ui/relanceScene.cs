using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Input = UnityEngine.Input;

public class relanceScene : MonoBehaviour
{
    //varible pour prendre le nom de la sc�ne
    public string nomDeScene;
    // Start is called before the first frame update
    void Start()
    {
        //faire que la varible soit �quivalente au nom de la sc�ne active
        nomDeScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        //si la touche r est enfonc�
        if (Input.GetKey(KeyCode.R))
        {
            //charger la sc�ne active et fermer toutes les autres sc�nes actives
            SceneManager.LoadScene(nomDeScene, LoadSceneMode.Single);
        }
    }
}
