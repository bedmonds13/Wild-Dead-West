public class Projectile : PooledlMonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        ReturnToPool();
    }
}
