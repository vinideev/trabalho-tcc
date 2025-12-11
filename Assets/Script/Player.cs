using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;

    private float moveX;
    private float moveY;
    public float moveSpeed;

    //ranged
    public GameObject bullet;
    public Transform aim;
    public float fireForce = 10f;
    private float shootCooldown = 0.2f;
    private float shootTimer = 0.5f;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        shootTimer += Time.deltaTime;
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        Movement();
        AimMouse();

        if (Input.GetMouseButton(0)){
            Shoot();
        }
    }

    private void Movement()
    {
       rig.MovePosition(transform.position + new Vector3 (moveX, moveY, 0) * moveSpeed * Time.deltaTime );    


    }

    private void AimMouse()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - aim.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        aim.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }



    void Shoot()
    {
        if (shootTimer > shootCooldown) { 
            
            shootTimer = 0f; 
            GameObject intBullet = Instantiate(bullet, aim.position, aim.rotation);
            intBullet.GetComponent<Rigidbody2D>().AddForce(aim.up * fireForce, ForceMode2D.Impulse);
            Destroy(intBullet, 2f);
        
        }
    }
}
