using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    public Transform[] patrol;
    public float speed;
    public int currentWP = 0;
    public int counter = 0;

    public Transform player;
    public bool chase = false;
    public bool confused = false;
    public GameObject lookerCollider;

    void Awake()
    {
        confused = false;
        chase = false;
        currentWP = 0;
    }

    void Update()
    {
        if (!confused)
        {
            if (chase)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                if (Vector2.Distance(this.transform.position, patrol[currentWP].position) > 0.2f)
                {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, patrol[currentWP].position, speed * Time.deltaTime);
                }
                else
                {
                    currentWP++;
                    if (currentWP >= patrol.Length)
                    {
                        currentWP = 0;
                    }
                }
            } 
        }
        else
        {
            this.transform.position = this.transform.position;
            StartCoroutine(Confused());
        }
    }

    public IEnumerator Confused()
    {
        yield return new WaitForSeconds(2f);
        confused = false;
    }

    public void EnableConfusion(bool enabled)
    {
        confused = enabled;
    }
    
    public void EnableChase(bool enabled)
    {
        chase = enabled;
    }
}
