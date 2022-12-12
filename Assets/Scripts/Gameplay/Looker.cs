using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Looker : MonoBehaviour
{
    public PatrolBehavior guard;
    public TMP_Text alert;
    public static bool inBattle = false;

    public float reset = -2f;
    private bool movingDown;

    // Start is called before the first frame update

    void Start()
    {
        inBattle = false;
        reset = -2f;
    }

    // Update is called once per frame
    void Update()
    {
        reset -= Time.deltaTime;

        if (reset < 0 && reset > -1 && inBattle == false)
        {
            alert.text = "?";
            guard.EnableConfusion(true);
            guard.EnableChase(false);
            GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            alert.text = "!";
            guard.EnableConfusion(true);
            yield return new WaitForSeconds(2f);
            alert.text = "!!!";
            guard.EnableChase(true);
            guard.EnableConfusion(false);
            reset = 3;
        }
    }
}
