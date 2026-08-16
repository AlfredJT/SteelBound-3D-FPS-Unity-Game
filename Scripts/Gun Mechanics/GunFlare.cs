using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float destroyTime = 4f; // Time after which the object will be destroyed

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}