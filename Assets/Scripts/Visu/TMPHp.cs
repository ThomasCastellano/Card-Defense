using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPHp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextElement;


    private void Start()
    {
        HPText();
    }
    public void HPText()
    {
        myTextElement.text = "10"; // insérer ici la variable hp 
    }
}
