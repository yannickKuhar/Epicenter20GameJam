using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class flocking : MonoBehaviour
{
    public float enemySpeed;
    public int enemyHealth;
    //public GameObject explosion;

    private int enemyCurrentHealth;
    private float minDist = 1.0f; // The minumum distance between each flock
    private Rigidbody2D enemy;
    private Transform target;
    private GameObject[] flockers;
    //private bool wall_hit;
    private Vector3 current_dir;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        enemyCurrentHealth = enemyHealth;
        flockers = GameObject.FindGameObjectsWithTag("Flocker");
        //wall_hit = false;
        current_dir = target.position - transform.position;
    }

    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            Destroy(enemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Die");
        if (collision.CompareTag("Wall"))
        {
            Debug.Log("should die");
            Destroy(gameObject);
        }
    }

   
     //bool check_front(Vector3 direction)
    //{
    //    direction.Normalize();
    //    RaycastHit2D[] res = Physics2D.RaycastAll(transform.position, direction, 2.0f);
    //    Debug.DrawRay(transform.position, direction * 3f, Color.green);
    //    bool wall_hit = false;
    //    foreach (RaycastHit2D ray in res)
    //    {
    //        if (ray.collider.CompareTag("Wall"))
    //        {
    //            wall_hit = false;
    //        }
    //        wall_hit = true;
    //    }

    //    return wall_hit;
    //}

    void FixedUpdate()
    {
        Vector3 closestFriendPos = Vector3.zero;
        float closestDist = minDist;

        // Separation mechanism
        foreach (var flocker in flockers) // Loops through each enemy in the group
        {
            if (flocker != null) // Checks first that we have a flocker
            {
                // Finds distance between a flocker's position and its friend's position
                float curDist = Vector3.Distance(transform.position, flocker.transform.position);

                // Is the flocker getting closer to its friend?
                if (curDist < minDist)
                {
                    closestFriendPos = flocker.transform.position;
                    closestDist = curDist;
                }
            }
        }

        // Chasing mechanism
        if (Vector3.Distance(target.position, transform.position) > 0)
        {
            // Direction vector from enemy to target
            //if (check_front(current_dir))
            //{
            //Debug.Log("WALL MF HIT");
            //transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
            //dir.;
            //Debug.Log(transform.eulerAngles);
            //Debug.Log(transform.rotation);
            //if (closestDist < minDist)
            //{
            //    Vector3 avoidDir = transform.position - closestFriendPos;
            //    avoidDir = avoidDir.normalized * (1 - closestDist / minDist);
            //    current_dir += avoidDir;
            //}
            //enemy.velocity = current_dir * enemySpeed;
            //Debug.DrawRay(transform.position, current_dir * 3f, Color.green);
            //}
            //else
            //{
            Vector3 dir = target.position - transform.position;
            //current_dir = target.position - transform.position;
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            if (closestDist < minDist)
            {
                Vector3 avoidDir = transform.position - closestFriendPos;
                avoidDir = avoidDir.normalized * (1 - closestDist / minDist);
                dir += avoidDir;
            }
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            // Move the enemy into the direction
            if (enemy != null)
            {
                enemy.velocity = dir * enemySpeed;
            }
        }

    }

}