using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //敵のMaxHP
    [SerializeField]
    private int maxHp = 100;

    //敵のHP
    int hp;

    //敵のHPバー処理スクリプト
    private HPStatusUI hPStatusUI;

    private Enemy enemy;

    // これが敵を倒すと得られる点数になる
    public int scoreValue; 
    private ScoreManager sm;



    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;


    //DamageUIプレハブ
    [SerializeField]
    private GameObject damegeUI;


    // Use this for initialization
    void Start () {

        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        enemy = GetComponent<Enemy>();

        hp = maxHp;

        hPStatusUI = GetComponentInChildren<HPStatusUI>();

        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

    }
	
	// Update is called once per frame
	void Update () {
		if(hp <= 0)
        {
            sm.AddScore(scoreValue);

            Destroy(this.gameObject);

            //破壊演出(パーティクルの再生)
           // GetComponent<ParticleSystem>().Play();
        }
        
	}
    public void TakeDamage(int damage)
    {
        hp -= damage;

        this.myAnimator.SetTrigger("DamageTrriger2");

        Debug.Log(hp);

        this.hPStatusUI.UpdateHPValue();

    }

    public void Damage(Collider col)
    {
        //DamageUIをインスタンス化。登場位置は接触したコライダの中心からカメラの方向に少し寄せた位置
        var obj = GameObject.Instantiate(damegeUI, col.bounds.center - Camera.main.transform.forward * 0.2f, col.transform.rotation) as GameObject;

        Debug.Log("通った");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SwordTag"  || other.gameObject.tag == "AtackColliderTag") //  ソードコライダーが触れたら敵はダメージを受ける
        {
            TakeDamage(10);
        }


    }

    public void SetHP(int hp)
    {
        this.hp = hp;

        //HP表示用UIのアップデート
        hPStatusUI.SetDisable();


        //HP表示ようUIを非表示にする
        if(hp <= 0)
        {
            hPStatusUI.SetDisable();

        }
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }



}
