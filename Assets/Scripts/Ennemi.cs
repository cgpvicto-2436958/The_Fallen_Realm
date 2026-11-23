using UnityEngine;

public class Ennemi : MonoBehaviour
{

    [SerializeField] private int degats;
    [SerializeField] private float vitesse;
    [SerializeField] private Transform joueur;
    //[SerializeField] private EnnemiAnimatorController controllerAnim;
    private Rigidbody rb;
    private int pv;
    private bool vivant;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vivant = false;
    }

    // Update is called once per frame
    void Update()
    {
        Avancer();
    }

    private void RecevoirDegats(int degatsRecus) 
    {
        if (pv <= 0) 
        {
            //controllerAnim.mourir
            vivant = false;
        }
        pv -= degatsRecus;
    }

    private int InfligerDegats(int vieAutre) 
    {
        return vieAutre -= degats;
    }

    private void Avancer() 
    {
        float xJoueur = joueur.position.x;
        float zJoueur = joueur.position.z;

        float yEnnemi = transform.position.y;

        Vector3 force = new Vector3(xJoueur, 0, zJoueur);
        rb.AddForce(force * vitesse);
    }
}
