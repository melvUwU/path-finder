using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointController : MonoBehaviour
{   public List<Transform> wayPoints = new List<Transform>();
    private Transform targetWayPoint;
    private int targetWayPointIndex;
    private float minDixtance = 0.1f;
    private int lastWayPointIndex;
    private float movementSpeed = 5.0f;
    private float rotationSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        lastWayPointIndex = wayPoints.Count -1;
        targetWayPoint = wayPoints[targetWayPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        float movemetStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWayPoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f);
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f);

        float distance = Vector3.Distance(transform.position, targetWayPoint.position);
        CheckDistanceToWayPoint(distance);
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, movemetStep);
    }
    void CheckDistanceToWayPoint(float currentDistance)
    {
        if (currentDistance <= minDixtance)
        {
            targetWayPointIndex++;
            UpdateTargetWayPoint();
        }
    }
    void UpdateTargetWayPoint()
    {
        if(targetWayPointIndex > lastWayPointIndex)
        {
            targetWayPointIndex = 0;
        }
        targetWayPoint = wayPoints[targetWayPointIndex];
    }
}
