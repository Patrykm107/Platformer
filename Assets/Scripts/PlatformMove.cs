using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform[] travelPoints;

    [SerializeField] private float speed = 2f;
    
    private int nextPointId = 0;

    void Start()
    {
        transform.position = travelPoints[0].position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, travelPoints[nextPointId].position, speed * Time.fixedDeltaTime);

        if(Vector2.Distance(transform.position, travelPoints[nextPointId].position) < 0.1f) { 
            changeDirection(); 
        }
    }

    private void changeDirection()
    {
        nextPointId++;
        if(nextPointId >= travelPoints.Length) { 
            nextPointId = 0; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null ;
        }
    }

}
