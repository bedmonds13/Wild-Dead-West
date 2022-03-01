using UnityEngine;
using UnityEngine.AI;

public class ZombieNavigation : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshPath path;
    private GameObject cube;

    private void Awake()
    {
        GetComponent<Health>().OnDied += ZombieNavigation_OnDied;
    }

    private void ZombieNavigation_OnDied()
    {
        cube.SetActive(false);
        this.enabled = false;

    }

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        path = new NavMeshPath();
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Collider>().enabled = false;
    }

    private void Update()
    {
        var targetPosition = playerTransform.position;
        bool foundPath = NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
        if(foundPath)
        {
            Vector3 nextDestination = path.corners[1];
            //cube.transform.position = nextDestination;

            Vector3 directionToTarget = nextDestination - transform.position;
            Vector3 flatDirection = new Vector3(directionToTarget.x, 0, directionToTarget.z);
            directionToTarget = Vector3.Normalize(flatDirection);

            var desiredRotation = Quaternion.LookRotation(directionToTarget);
            var finalRotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime );

            transform.rotation = desiredRotation;
        }
    }
}
