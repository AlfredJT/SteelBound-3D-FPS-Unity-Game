using UnityEngine;

public class EnemyDeathEffect : MonoBehaviour
{
    public GameObject deathEffect1; // Assign the effect prefab in the Inspector
    public GameObject deathEffect2;
    public GameObject deathEffect3;


    public void PlayDeathEffect()
    {
        if (deathEffect1 && deathEffect2 && deathEffect3 != null)
        {
            Instantiate(deathEffect1, transform.position, Quaternion.identity);
            Instantiate(deathEffect2, transform.position, Quaternion.identity);
            Instantiate(deathEffect3, transform.position, Quaternion.identity);


        }
    }
}