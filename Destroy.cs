using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
     private GameObject pullme;

    public int destroyDelay;
   

    // Use this for initialization
    void Start () {
        pullme = GameObject.FindWithTag("pullme");
        //Destroy(gameObject,destroyDelay);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision col)
    {

        if (col.collider.tag == "pullme")
        {
            Destroy(pullme);
        }
    }
}
