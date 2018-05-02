/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
    private bool IsDaying = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (IsDaying)
        {
            return;
        }
    }

    public void Die()
    {
        IsDaying = true;
        myAnim.SetBool("IsDead", IsDaying);
        Invoke("Respawn", 1f);
    }

    private void Respawn()
    {
        GameManagerScript.GetGameManager().Respawn();
    }
}
*/