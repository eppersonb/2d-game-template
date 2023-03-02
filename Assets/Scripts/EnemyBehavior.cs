using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    private float health = 100;



    GameObject enemy;
    void Start()
    {
        enemy = GetComponent<GameObject>();
        setHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        enemyStatus();
        Debug.Log(health);
    }

    public void takeDamage(float damage)
    {
       float damageCalc = health - damage; 
       setHealth(damageCalc);
    Debug.Log("enemy damage recieved!");

    }

    void enemyStatus()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void enemyDie()
    {

        Debug.Log("enemy dead!");

    }

    public void setHealth(float health)
    {
        this.health = health;
    }
    public float getHealth()
    {
        return health;
    }
}
