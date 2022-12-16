using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float speed;

    private float lastposition;

    private float velocity;

    private Transform target;

    private List<Vector3> positions = new List<Vector3>();

    private int index;

    void Start()
    {
        positions.Add(GetComponent<BoxCollider2D>().bounds.min);
        positions.Add(GetComponent<BoxCollider2D>().bounds.max);
        lastposition = enemyPrefab.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
    }

    public void Move()
    {
        if (target == null)
        {
            enemyPrefab.transform.position = Vector2.MoveTowards(enemyPrefab.transform.position, positions[index], Time.deltaTime * speed);

            if (Mathf.Abs(enemyPrefab.transform.position.x - positions[index].x) <= 0.1f)
            {
                if (index == positions.Count - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }

        }

        else
        {
            enemyPrefab.transform.position = Vector2.MoveTowards(enemyPrefab.transform.position, target.position, Time.deltaTime * speed);
        }
        
        var currentposition = enemyPrefab.transform.position.x;
        enemyPrefab.GetComponent<Animator>().SetBool("Walking", true);
        velocity = (currentposition - lastposition) / Time.deltaTime;
        lastposition = currentposition;
    }

    public void Flip()
    {
        if (velocity < 0f)
        {
            enemyPrefab.transform.localScale = new Vector3(-0.3f, 0.3f, 1);
        }
        else if(velocity > 0f)
        {
            enemyPrefab.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }
        else
        {
            enemyPrefab.GetComponent<Animator>().SetBool("Walking", false);
        }

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && target == null)
        {
            target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            target = null;
        }
    }
}
