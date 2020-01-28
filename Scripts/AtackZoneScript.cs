using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackZoneScript : MonoBehaviour
{

    public Collider swordCollider;

    private Enemy EnemyClass;
  

    // Start is called before the first frame update
    void Start()
    {
       

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // IsTrrigerにチェックがついた状態
    {
        if (other.gameObject.tag == "ChildTag" || other.gameObject.tag == "DaikonTag" || other.gameObject.tag == "MushTag" || other.gameObject.tag == "StorneTag")
        {
           // other.GetComponent<Enemy>().TakeDamage(30);
            Debug.Log("30のダメージ");
            Debug.Log("あたっくぞーん");
        }
        
        if (other.gameObject.tag == "Shell")    // もしもぶつかってきた相手のTagが”Shell”であったならば
        {          
            Destroy(other.gameObject);   // ぶつかってきた相手方（敵の砲弾）を破壊する。
            Debug.Log("玉を破壊");
        }
       
    }


    /* private void OnCollisionEnter(Collision other)  //  衝突を検知(IsTrrigerにチェックがついていない状態)
     {
         if (other.gameObject.tag == "ChildTag" || other.gameObject.tag == "DaikonTag" || other.gameObject.tag == "MushTag" || other.gameObject.tag == "StorneTag")
         {
             EnemyClass.GetComponent<Enemy>().TakeDamage(30);
             Debug.Log("30のダメージ");
         }

         if (other.gameObject.tag == "Shell")    // もしもぶつかってきた相手のTagが”Shell”であったならば
         {
             Destroy(other.gameObject);   // ぶつかってきた相手方（敵の砲弾）を破壊する。
             Debug.Log("玉を破壊");
         }
     }*/



}
