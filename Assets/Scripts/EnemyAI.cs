using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    private float speed = .5f;

    [SerializeField]
    private List<Transform> points;

    [SerializeField]
    private int nextPointID = 0;

    [SerializeField]
    private int changeID = 1;

    [SerializeField]
    private GameObject walkPoint;

    [SerializeField]
    private bool canPatrol;
    GameObject enemyObject;

    [SerializeField]
    private Transform lineOfSight;

    public bool playerSpotted;
    void Start()
    {
        enemyObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMove();
        playerSpot();
    }

    void playerSpot()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(lineOfSight.position, lineOfSight.TransformDirection(-Vector2.right),  10.0f, LayerMask.GetMask("Player"));
        if(hit)
        {
            playerSpotted = true;
            Debug.DrawRay(lineOfSight.position, lineOfSight.TransformDirection(-Vector2.right) * 10.0f , Color.green);
            Debug.Log("Player Spotted!");
        }
        else if(!hit)
        {
            playerSpotted = false;
            Debug.DrawRay(lineOfSight.position, lineOfSight.TransformDirection(-Vector2.right) * 10.0f , Color.red);  
        }
        
    }

    void enemyMove()
    {


        if(canPatrol == true)
        {
            Transform patrolPoint = points[nextPointID]; //sets a list of all points in the list!

            if(patrolPoint.position.x >= transform.position.x) // if the next point x value is greater than the x value of current point flip the local scale
            {
                transform.localScale = new Vector3(-1,1,-1);
            }
            else
            {
                transform.localScale = new Vector3(1,1,1);
            }

            Debug.Log(Vector2.Distance(transform.position, patrolPoint.position));
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint.transform.position, speed * Time.deltaTime); //after conditional move towards point

            if(Vector2.Distance(transform.position, patrolPoint.position) < 0.5f) //as the distance closes on the next point change the ID.
            {
                if(nextPointID == points.Count - 1)
                {
                    changeID = -1;
                }
                if(nextPointID == 0)
                {
                    changeID = 1;
                }
        
                nextPointID += changeID;

            }

            
        }
        
    }

}
