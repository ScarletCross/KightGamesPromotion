using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.AI;


public class MoveMobile : MonoBehaviour {

 //   NavMeshAgent agent = null;

    Transform cameraTransform;

    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;

    //Playerを移動させるコンポーネントをいれる
    private Rigidbody myRigidbody;

    //プレイヤーの動くスピード
    public float speed;

   

    //移動するための力
    private float addForce = 500.0f;

    //プレイヤーのポジション
    private Vector3 player_pos;

    

    //x方向のインプット値
    private float x;

    //z方向のインプット値
    private float z;

	// Use this for initialization
	void Start () {

   //     agent = GetComponent<NavMeshAgent>();

        cameraTransform = Camera.main.transform;

        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //最初の時点でのプレイヤーのポジションを取得
        player_pos = GetComponent<Transform>().position;

        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        // 入力を取得
        var v1 = CrossPlatformInputManager.GetAxis("Vertical1");
        var h1 = CrossPlatformInputManager.GetAxis("Horizontal1");

        /*   var v2 = CrossPlatformInputManager.GetAxis("Vertical2");
           var h2 = CrossPlatformInputManager.GetAxis("Horizontal2");
           */

        //x方向のInputの値を取得
        x = Input.GetAxis("Horizontal");

        //z方向のInputの値を取得
        z = Input.GetAxis("Vertical");

        //プレイヤーのRigidbodyに対してInputにspeedを掛けた値で更新し移動
    //   myRigidbody.velocity = new Vector3(x * speed, 0, z * speed); 

        var cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;

        //プレイヤーがどの方向に進んでいるかがわかるように、初期位置と現在地の座標差分を取得
        Vector3 diff = transform.position - player_pos;

    //    diff.y = 0;

        //ベクトルの長さが0.01fより大きい場合にプレイヤーの向きを変える処理を入れる(0では入れないので）
  /*    if(diff.magnitude > 0.01f)
        {
            //ベクトルの情報をQuaternion.LookRotationに引き渡し回転量を取得しプレイヤーを回転させる
         transform.rotation = Quaternion.LookRotation(diff);
        }
*/
        //プレイヤーの位置を更新
        player_pos = transform.position;


            // スティックが倒れていれば、移動
            if (h1 != 0 || v1 != 0)
        {
            var direction = new Vector3(h1, 0f, v1);

   //         agent.Move(15 * direction * Time.deltaTime);

          this.myRigidbody.AddForce(h1 * speed, 0f, v1 * speed);

           this.transform.rotation = transform.rotation = Quaternion.LookRotation((transform.position + (Vector3.right * h1) + (Vector3.forward * v1)) - transform.position);

            this.myAnimator.SetFloat("Speed", 1);


        }


        // スティックが倒れていれば、倒れている方向を向く
     /*   if (h2 != 0 || v2 != 0)
        {
            var direction = new Vector3(h2, 0, v2);
            transform.localRotation = Quaternion.LookRotation(direction);
        }

    */
    }
}
