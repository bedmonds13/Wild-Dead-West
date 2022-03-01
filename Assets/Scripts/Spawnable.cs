using UnityEngine;

public class Spawnable : PooledlMonoBehaviour

{
    [SerializeField]
    private float returnToPoolDelay = 10f;
    private void Start()
    {
        if(GetComponent<Health>() != null)
            GetComponent<Health>().OnDied += () => ReturnToPool(returnToPoolDelay);
    }
}
