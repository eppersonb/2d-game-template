using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    

    
    public PlayerBehavior player;

    public EnemyBehavior enemy;

    private float damage = 10;

    [SerializeField]
    private bool isShot = false;
    [SerializeField]
    private float speed = 20.0f;

    private float currentBulletDirection;

    [SerializeField]
    private bool isBulletRight;

    [SerializeField]
    private bool isBulletLeft;
    private float projectileLifeTime = 3;

    [SerializeField]
    private int bulletDamage = 10;

    [SerializeField]
    public float bulletLifeTime = 120f;

    

    // Rigidbody2D bullet;

    GameObject bulletObject;

    Rigidbody2D bullet;



    // Start is called before the first frame update
    void Start()
    {
        
        bulletObject = GetComponent<GameObject>();
        bullet = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        bulletMove();
        bulletLife();
    }

    public IEnumerator projectileLife() //this sets the projectile life time
    {
        
        yield return new WaitForSeconds(projectileLifeTime);
        Destroy(gameObject);
    }

    void bulletLife() //this function controls projectile life
    {
        if(isShot == true)
        {
            
            Debug.Log("Projectile fired");
            StartCoroutine((projectileLife()));
            Debug.Log("Projectile Destroyed");

        }
    }

    void bulletMove() //this function makes the bullet move.
    {
        if(isBulletLeft && isShot == true)
        {
            bullet.AddForce(Vector2.left * 60);
        }

        else if(isBulletRight && isShot == true)
        {
            bullet.AddForce(Vector2.right * 60);
        }
    }


    void OnCollisionEnter2D(Collision2D col) //this function handles bullet collision with either the player, enemey, or the game world and will act accordingly.
    {
        if(col.gameObject.tag == "enemy")
        {
            Debug.Log("Enemy Collision Detected!");

            col.gameObject.GetComponent<EnemyBehavior>().takeDamage(bulletDamage); //this calls the enemy damage function to do damage to the enemy.

            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Player") //this condintional is called when the bullet object collides with the player
        {
            Debug.Log("Player Collision Detected");
            col.gameObject.GetComponent<PlayerBehavior>().takeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Wall" || col.gameObject.tag == "Ground") //this condintional is called when the bullet object collides with the wall or ground
        {
            Debug.Log("Wall or ground detected!");
            Destroy(gameObject);
        }
        
    }

    /*
        Setters and Getters
    */

    public void setShot(bool isShot)
    {
        this.isShot = isShot;
    }

    public bool getShot()
    {
        return isShot;
    }

    public void setBulletDamage(int bulletDamage)
    {
        this.bulletDamage = bulletDamage;
    }
    public int getBulletDamage()
    {
        return bulletDamage;
    }

    public void setBulletDirection(float currentBulletDirection)
    {
        this.currentBulletDirection = currentBulletDirection;
    }

    public float getBulletDirection()
    {
        return currentBulletDirection;
    }

    public void setBulletDirLeft(bool isBulletLeft)
    {
        this.isBulletLeft = isBulletLeft;
    }

    public bool getBulletDirLeft()
    {
        return isBulletLeft;
    }
    public void setBulletDirRight(bool isBulletRight)
    {
        this.isBulletRight = isBulletRight;
    }

    public bool getBulletDirRight()
    {
        return isBulletRight;
    }
    public float getBulletSpeed()
    {
        return speed;
    }
    public void setBulletSpeed(float bulletSpeed)
    {
        this.speed = bulletSpeed;
    }

}
