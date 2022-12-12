using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public LayerMask solidObjectLayer;
    public GameObject pauseMenu;

    public event Action OnEncountered;

    private bool moving;
    private Vector2 userInput;

    private Animator anim;

    public GameObject battleSystem;

    public Monster collidedMonster;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);       
        }

        if (!moving)
        {
            userInput.x = Input.GetAxisRaw("Horizontal");
            userInput.y = Input.GetAxisRaw("Vertical");

            if (userInput.x != 0) 
                userInput.y = 0;

            if(userInput != Vector2.zero)
            {
                anim.SetFloat("moveX", userInput.x);
                anim.SetFloat("moveY", userInput.y);
                var targetPos = transform.position;
                targetPos.x += userInput.x;
                targetPos.y += userInput.y;

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
                    
            }
        }

        anim.SetBool("moving", moving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        moving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        moving = false;
    }

    bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectLayer) != null)
        {
            return false;
        }
        else
        {
            return true;
        }           
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Monster")
        {
            anim.SetBool("moving", false);
            collidedMonster = col.gameObject.GetComponent<WildMonsters>().GetWildMonster();
            OnEncountered();
            Destroy(col.gameObject);
        }
    }
}
