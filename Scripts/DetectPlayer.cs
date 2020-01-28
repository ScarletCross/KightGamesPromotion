using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {

    public Transform target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 「OnTriggerStay」はトリガーが他のコライダーに触れている間中実行される関数
    void OnTriggerStay(Collider other)
    {

        // もしも他のオブジェクトに「Player」というTag（タグ）が付いていたならば
        if (other.CompareTag("Player"))
        {

            // 「root」を使うと「親（最上位の親）」の情報を取得することができる（ポイント）
            // LookAt()メソッドは指定した方向にオブジェクトの向きを回転させることができる（ポイント）
            transform.root.LookAt(target);
        }
    }


}
