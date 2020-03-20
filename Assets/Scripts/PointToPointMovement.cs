using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PointToPointMovement : MonoBehaviour
{
    public Transform[] travelPoints;

    [SerializeField] private float speed = 2f;
    
    private int nextPointId = 0;

    void Start()
    {
        assertAllPointsExist();
        transform.position = travelPoints[0].position;
    }

    private void assertAllPointsExist()
    {
        for(int i = 0; i < travelPoints.Length; i++)
        {
            Assert.IsNotNull(travelPoints[i], $"Travel points {i} is null");
        }
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
}
