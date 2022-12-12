using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public GameObject player;
    public static bool chase = false;
    public static bool confused = false;

    public int currentWP = 0;
    public int counter = 0;
    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    public GameObject[] waypoints;
    public GameObject lookerCollider;
    float accuracy = 1;

    // Start is called before the first frame update
    void Awake()
    {
        confused = false;
        chase = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (chase)
        {
            target = player.transform;
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
        else
        {
            if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracy)
            {
                counter++;
                currentWP++;
                if (currentWP >= waypoints.Length)
                {
                    currentWP = 0;
                }
            }

            moveDirection = (waypoints[currentWP].transform.position - transform.position).normalized;

            if (currentWP == 0 && counter == waypoints.Length)
            {
                counter = 0;
            }
        }      
    }

    private void FixedUpdate()
    {
        if (target)
        {
            if (!confused)
            {
                rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
            else
            {
                StartCoroutine(Confused());
            }
        }
    }

    public IEnumerator Confused()
    {
        yield return new WaitForSeconds(2f);
        lookerCollider.SetActive(true);
        confused = false;
    }
}
