using UnityEngine;

public class MiniPorteAnimatorController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Animator animator;

    [SerializeField] private ControllerInterface controllerInterface;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Joueur"))
        {
            controllerInterface.PorteTipsTexte();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Joueur")) 
        { 
            controllerInterface.ResetTipsTexte();
        }
    }

    private void Ouvrir() 
    {
        animator.SetBool("ouvert", true);
    }

    private void Fermer() 
    {
        animator.SetBool("ouvert", false);
    }
}
