using UnityEngine;
using UnityEngine.Playables;

public class DirectorEnableOnEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            GetComponentInParent<PlayableDirector>().Play();
        }
    }
}
