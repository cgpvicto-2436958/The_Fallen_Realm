using UnityEngine;
using TMPro;

public class ControllerInterface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tipsTexte;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PorteTipsTexte() 
    {
        tipsTexte.text = "Appuyer sur e pour ouvrir ou fermer une porte";
    }

    public void ResetTipsTexte()
    {
        tipsTexte.text = "Appuyer sur e pour ouvrir ou fermer une porte";
    }
}
