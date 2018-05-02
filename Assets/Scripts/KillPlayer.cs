using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Character")
        {
            other.GetComponent<playerMovementScript>().Die();
        }
    }
}
