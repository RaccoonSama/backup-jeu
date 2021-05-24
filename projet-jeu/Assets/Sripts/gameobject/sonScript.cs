using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sonScript : MonoBehaviour
{
    //son que l'on veut jouer juste une fois
    public AudioClip sonOs;
    //son d'ambiance qui jouera en boucle
    public AudioClip sonAmbiance2;
    //variable de composante pour determiner la scene
    private Scene scene;
    //variable de composante pour l'audio source
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //indexer la scene active
        scene = SceneManager.GetActiveScene();
        //définir la composante d'audioSource
        audioSource = GetComponent<AudioSource>();
        //si le nom de la scène n'est pas intro
        if (scene.name != "intro")
        {
            //jouer le sonOS
            audioSource.PlayOneShot(sonOs);
        }
        //appeler son ambiance après 1.2s
        Invoke("sonAmbiance", 1.2f);
    }

    void sonAmbiance()
    {
        //faire jouer la musique d'ambiance
        audioSource.clip = sonAmbiance2;
        audioSource.Play();
    }
}
