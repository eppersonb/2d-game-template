using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    // Start is called before the first frame update


    public PlayerBehavior player;
    public BulletBehavior bullet;

    private bool isShot = false;

    public bool bulletShot;
    public float bulletSpeed;
    public Transform firingPoint;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bulletGenerate();
    }

    void bulletGenerate() // this generates a bullet!
    {
        
        if (player.getDirRight() && Input.GetButtonDown("Fire1")) // fires bullet on click of mouse1 or soon a button press
        {

            Debug.Log("Bullet Released on the right side!");
            // Instantiate the projectile at the position and rotation of this transform
            
            BulletBehavior newBullet = Instantiate(bullet, firingPoint.position, firingPoint.rotation) as BulletBehavior; //make the newBullet with the properties of bullet behavior.


            newBullet.setBulletDirRight(true);

            newBullet.setShot(true); // call bullet behavior to set the bullet object shot to true
            
            bulletSpeed = newBullet.getBulletSpeed(); // get the bullet speed from BulletBehaviorClass

            

        }

        else if(player.getDirLeft() && Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Bullet Released on the left side!");
            // Instantiate the projectile at the position and rotation of this transform
            
            BulletBehavior newBullet = Instantiate(bullet, firingPoint.position, firingPoint.rotation) as BulletBehavior; //make the newBullet with the properties of bullet behavior.
            newBullet.setBulletDirLeft(true);

            newBullet.setShot(true); // call bullet behavior to set the bullet object shot to true

            

            bulletSpeed = newBullet.getBulletSpeed(); // get the bullet speed from BulletBehaviorClass
        }


           
    }




}
