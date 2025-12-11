using UnityEngine;

public class Projetil : MonoBehaviour
{
    //Velocidade do projétil, ajustável no Inspector
    [SerializeField] private float speed = 15f;

    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Launch(Vector2 direction)
    {
        // Aplica a velocidade na direção 2D determinada pelo script do Player
        rb.linearVelocityX = speed;
    }

    void Start()
    {
        Destroy(gameObject, 2f); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       Destroy(gameObject);
    }
}
