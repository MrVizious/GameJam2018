using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
    public bool IsDead;

    // Use this for initialization
    void Start () {
        IsDead = false;
    }
	
	

    public void Die()
    {
        IsDead = true;
        
        //Invoke("Respawn", 1f);
    }

    private void Respawn()
    {
        //GameManagerScript.GetGameManager().Respawn();
    }
}
