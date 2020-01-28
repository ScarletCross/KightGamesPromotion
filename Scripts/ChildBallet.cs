using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBallet : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(10);
            Debug.Log("");
        }



   



    }

}
