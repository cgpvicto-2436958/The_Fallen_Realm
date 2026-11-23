using UnityEngine;
using UnityEngine.InputSystem;

public class PersonnageAnimatorController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController personnageController;
    [SerializeField] private StarterAssets.StarterAssetsInputs inputs;

    [Header("Combo")]
    [Tooltip("À partir de quel moment (0 à 1) de l'animation un clic enchaîne sur l'attaque suivante")]
    [SerializeField, Range(0f, 1f)] private float seuilEnchainement = 0.6f;
    [Tooltip("À partir de quel moment (0 à 1) de l'animation le combo se termine si aucun clic")]
    [SerializeField, Range(0f, 1f)] private float seuilFinCombo = 0.95f;


    private bool sautPrecedent;
    private bool auSolPrecedent;

    private int comboActuel;
    private bool clicEnAttente;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vitesse horiontale du personnage
        Vector3 velocite = personnageController.velocity;
        Vector2 velociteHorizontale = new Vector2(velocite.x, velocite.z);

        float vitesse = velociteHorizontale.magnitude;

        // Gestion des paramêtres dans l'animator
        animator.SetFloat("Vitesse", vitesse);
        animator.SetBool("AuSol", personnageController.isGrounded);
        animator.SetBool("Sprint", inputs.sprint && inputs.move != Vector2.zero);
        animator.SetFloat("Y", velocite.y);

        if (inputs.jump && !sautPrecedent && (personnageController.isGrounded || auSolPrecedent))
        {
            animator.SetTrigger("Saut");
        }
        sautPrecedent = inputs.jump;

        auSolPrecedent = personnageController.isGrounded;

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (comboActuel == 0)
            {
                // Début d'un nouveau combo, seulement au sol
                if (personnageController.isGrounded)
                {
                    comboActuel = 1;
                    animator.SetInteger("Combo", comboActuel);
                }
            }
            else if (comboActuel < 3)
            {
                // Une attaque est en cours : on garde le clic pour enchaîner
                clicEnAttente = true;
            }
        }

        AnimatorStateInfo etat = animator.GetCurrentAnimatorStateInfo(0);

        if (comboActuel > 0 && etat.IsTag("Attaque") && !animator.IsInTransition(0))
        {
            if (clicEnAttente && comboActuel < 3 && etat.normalizedTime >= seuilEnchainement)
            {
                // Clic reçu : on passe à l'attaque suivante (1 -> 2 -> 3)
                comboActuel++;
                clicEnAttente = false;
                animator.SetInteger("Combo", comboActuel);
            }
            else if (etat.normalizedTime >= seuilFinCombo)
            {
                // Animation finie sans clic (ou après la 3e attaque) : fin du combo
                comboActuel = 0;
                clicEnAttente = false;
                animator.SetInteger("Combo", 0);
            }
        }
    }
}
