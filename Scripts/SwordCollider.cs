using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ChildTag" || other.gameObject.tag == "DaikonTag" || other.gameObject.tag == "MushTag" || other.gameObject.tag == "StorneTag")
        {
            other.GetComponent<Enemy>().TakeDamage(30);
            Debug.Log("f");          

        }



      // もしもぶつかってきた相手のTagが”Shell”であったならば（条件）
        if (other.gameObject.tag == "Shell")
        {
            // ぶつかってきた相手方（敵の砲弾）を破壊する。
            Destroy(other.gameObject);

            Debug.Log("z");

        }
        
    }
}
