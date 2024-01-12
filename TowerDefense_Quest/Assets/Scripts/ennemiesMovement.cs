using UnityEngine;

public class ennemiesMovement : MonoBehaviour
{
    public float speed = 5f;
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private ennemiesSpawner spawner;

    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("ennemiesSpawner").GetComponent<ennemiesSpawner>();
        waypoints = spawner.waypoints;
    }

    void Update()
    {
        if (waypoints.Length >= currentWaypointIndex)
        {
            MoveToWaypoint();
        }
    }

    public void ResetWaypoints()
    {
        currentWaypointIndex = 0;
    }

    void MoveToWaypoint()
    {
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        targetPosition.y = 3;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            NextWaypoint();
        }
    }

    void NextWaypoint()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            GameObject baseObject = GameObject.FindGameObjectWithTag("Base");
            baseObject.GetComponent<Base>().takeDMG(1);
            ReturnToPool();
        }
    }

    void ReturnToPool()
    {
        spawner.returnToPool(gameObject);
    }
}
