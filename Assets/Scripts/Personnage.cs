using UnityEngine;

public class Personnage : MonoBehaviour
{
    [SerializeField] private int degats;
    [SerializeField] private PersonnageAnimatorController controllerAnim;


    private int pv;
    private bool invulnerabilite;
    private bool vivant;
    void Start()
    {
         controllerAnim = GetComponent<PersonnageAnimatorController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RecevoirDegats(int degatsRecus) 
    {
        if (pv <= 0)
        {
            vivant = false;
            controllerAnim.mourir = true;
        }
        
        else
            pv -= degatsRecus;
    }

    private int InfligerDegats(int vieAutre) 
    {
        return vieAutre -= degats;
    }

    //TODO faire une coroutine pour l'esquive
}
