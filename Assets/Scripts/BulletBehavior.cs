using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    

    
    
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
    private int bulletDamage = 1;

    [SerializeField]
    public float bulletLifeTime = 60.0f;

    

    Rigidbody2D bullet;




    // Start is called before the first frame update
    void Start()
    {
    
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

    void bulletMove()
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
