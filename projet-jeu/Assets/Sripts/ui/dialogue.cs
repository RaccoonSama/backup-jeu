using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class dialogue
{
    //variables pour le nom des personnages
    public string nom;
    public string nom2;

    //donner une zone de texte dans l'inspecteur
    [TextArea(3,10)]
    //définir le contenu du texte area avec la variable phrases
    public string[] phrases;
}
