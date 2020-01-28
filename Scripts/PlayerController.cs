using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public static int Max_HP = 500;
    public static int hp = Max_HP;

    public static int damage;
    public HP_Circle_Controller HP_Circle;
    public GameObject HP_Circle_UI;


    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;

    //Playerを移動させるコンポーネントをいれる
    private Rigidbody myRigidbody;

    //前後に進むための力
    private float forwardForce = 500.0f;

    //左右に移動するための力
    private float turnForce = 500.0f;

    //ジャンプするための力
    private float upForce = 700.0f;

    public float inputVertical;
    public float inputHorizontal;

    //移動するための力
    private float addForce = 500.0f;

    //プレイヤーの動くスピード
    public float speed;


    //攻撃する力
    private float atkForce = 500.0f;

    private GameObject hpLabel;

 
    NavMeshAgent agent;

    private float Atack_Collider_Timer = 0;

    private bool isAtack_Collider_Timer = false;


    
    int count;  //  無敵時間のカウンター

    bool isHit = false; //  ヒットしたかのフラグ（モンスターと当たったらtrueになる
    private bool isATKButtonDown = false;   //  攻撃ボタンを押したときの判定
    private bool isJumpButtonDown = false;   // ジャンプボタンを押したときの判定
    private bool isSkillButtonDown = false; //  スキルボタンを押したときの判定


    public Collider swordCollider, atackCollider;
    

    // Use this for initialization
    void Start()
    {

        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();



        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();


        this.hpLabel = GameObject.Find("HPLabel");

        agent = GetComponent<NavMeshAgent>();

       
       // this.HP_Circle_UI = GameObject.Find("HP_Circle");
        

    }

    // Update is called once per frame
    void Update()
    {
        if (isAtack_Collider_Timer)
        {
            this.Atack_Collider_Timer -= Time.deltaTime;

            if (Atack_Collider_Timer <= 0)
            {


                StopCollider(); //  非攻撃時はソードコライダーをOFF
                this.isAtack_Collider_Timer = false;
            }
        }

        

       

        if (Input.GetKey(KeyCode.UpArrow))  //  Playerを矢印キーに応じて前後に移動させる
        {
            //前に移動
            this.myRigidbody.AddForce(0, 0, this.forwardForce);

            // this.myAnimator.SetFloat("Speed", 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            
            this.myRigidbody.AddForce(0, 0, -forwardForce); //  後ろに移動

            // this.myAnimator.SetFloat("Speed", 1);
        }
       
        if (Input.GetKey(KeyCode.LeftArrow))    //  Playerを矢印キーまたはボタンに応じて左右に移動させる
        {
            
            this.myRigidbody.AddForce(-this.turnForce, 0, 0);   //  左に移動

            // this.myAnimator.SetFloat("Speed", 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            
            this.myRigidbody.AddForce(this.turnForce, 0, 0);    //  右に移動
            //this.myAnimator.SetFloat("Speed", 1);
        }
    
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("ATK0"))  //  ATK0ステートの場合はATK0にfalseをセットする
        {
            this.myAnimator.SetBool("ATK0", false);
        }        
        if (Input.GetKeyDown(KeyCode.LeftShift))   //   左シフトキーを押すと攻撃
        {
            this.myAnimator.SetBool("ATK0", true);
            this.myRigidbody.AddForce(this.transform.forward * this.atkForce);  //  モンスターに攻撃をする
        }




        //joyコンでの操作

        //左スティックで移動
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");

        
        if((lsh != 0 || lsv != 0))  //  スティックが倒れていれば移動
        {
            var direction = new Vector3(lsh, 0f, lsv);
            this.myRigidbody.AddForce(lsh * speed, 0f, lsv * speed);
            this.transform.rotation = transform.rotation = Quaternion.LookRotation((transform.position + (Vector3.right * lsh) + (Vector3.forward * lsv)) - transform.position);
            this.myAnimator.SetFloat("Speed", 1);
        }
        
        if (Input.GetKeyDown("joystick button 0"))  //  Aボタンを押したら攻撃
        {
            ActiveCollider();   //  ソードコライダーをON



            this.myAnimator.SetBool("ATK0", true);

           // UnityEditor.EditorApplication.isPaused = true;

            if (Input.GetKeyDown("joystick button 0"))
            {
              //  ActiveCollider();   //  ソードコライダーをON
                this.myAnimator.SetBool("ATK0", true);

                if (Input.GetKeyDown("joystick button 0"))
                {
                   // ActiveCollider();   //  ソードコライダーをON
                    this.myAnimator.SetBool("ATK1", true);

                    if (Input.GetKeyDown("joystick button 0"))
                    {
                     //   ActiveCollider();   //  ソードコライダーをON
                        this.myAnimator.SetBool("ATK2", true);

                        if (Input.GetKeyDown("joystick button 0"))
                        {
                          //  ActiveCollider();   //  ソードコライダーをON
                            this.myAnimator.SetBool("ATK3", true);

                            if (Input.GetKeyDown("joystick button 0"))
                            {
                             //   ActiveCollider();   //  ソードコライダーをON
                                this.myAnimator.SetBool("ATK4", true);

                            }

                        }



                    }

                }

            }   

           
           // this.myRigidbody.AddForce(this.transform.forward * this.atkForce);   // モンスターに攻撃をする
        }


       
    


        //ゲームオーバー
        if (hp <= 0)
        {
            //  Destroy(this.gameObject);
            //死亡アニメーション
            this.myAnimator.SetTrigger("DieTrriger");
            //プレイヤーを破壊せずに画面から見えないようにする(破壊してしまうと、その時点でメモリー上から消えるため、以降のコードが実行されなくなる)
            //this.gameObject.SetActive(false);

            //3.0秒後にGoToGameOver()関数を実行する。
            Invoke("GoToGameOver", 3.0f);

        }




        inputVertical = Input.GetAxisRaw("Vertical");
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        myAnimator.SetFloat("Speed", Mathf.Abs(inputHorizontal) + Mathf.Abs(inputVertical));
        Vector3 force = new Vector3(inputHorizontal, 0f, inputVertical);
        myRigidbody.velocity = force + new Vector3(0, myRigidbody.velocity.y, 0);

       
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))   // Jumpステートの場合はJumpにfalseをセットする
        {
            this.myAnimator.SetBool("Jump", false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)  && this.transform.position.y < 20f)    //  ジャンプしていないときにスペースキーが押された場合ジャンプする
        {
            agent.enabled = false;

           
            this.myRigidbody.AddForce(this.transform.up * this.upForce);     // Playerに上方向の力を加える
            this.myAnimator.SetBool("Jump", true);  //  ジャンプアニメを再生

            //一回ジャンプしたらジャンプしないようにする
        }

       
        if (Input.GetKeyDown("joystick button 2") && this.transform.position.y < 20f)   // Xボタンを押したらジャンプ
        {
            agent.enabled = false;
       
            this.myRigidbody.AddForce(this.transform.up * this.upForce);     // Playerに上方向の力を加える
            this.myAnimator.SetBool("Jump", true);  //  ジャンプアニメを再生

            //一回ジャンプしたらジャンプしないようにする
        }


    }



    public void ActiveCollider()     // ソードコライダーをオンにする関数
    {
        this.Atack_Collider_Timer = 1f;
        
        swordCollider.enabled = true;
        atackCollider.enabled = true;
        Debug.Log("a");
        this.isAtack_Collider_Timer = true;

        
    }
    
    public void StopCollider()  // ソードコライダーをオフにする関数
    {
        swordCollider.enabled = false;
        atackCollider.enabled = false;
        Debug.Log("b");
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;



        if (hp <= 0)
        {
            hp = 0;
        }
        else if (hp > 0)
        {
            this.myAnimator.SetTrigger("DamageTrriger");
        }
        Debug.Log(hp);

        this.hpLabel.GetComponent<Text>().text = "HP" + hp;

       

       

        float wariaiHP = (float)hp / Max_HP;

        HP_Circle.DamageTrriger(wariaiHP);

       // HP_Circle.fillAmount = hp / Max_HP;




        if (isHit && count == 0)
        {
            //当たった時の処理
            count = 5;
        }

        if (count > 0)
        {
            --count;
            if (count <= 0)
            {
                //無敵時間終了
                count = 0;
                Debug.Log("end");
                isHit = false;
            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    //Jumpボタンを押したときの処理
    public void GetMyJumpButtonDown()
    {
        this.isJumpButtonDown = true;

        agent.enabled = false;

        if (this.isJumpButtonDown && this.transform.position.y < 20f)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }




    }

    //攻撃ボタンを押した時の処理
    public void GetMyATKButtonDown()
    {
        this.isATKButtonDown = true;

       if(this.isATKButtonDown)
        {

            this.myAnimator.SetBool("ATK0", true);

            if (this.isATKButtonDown)
            {

                this.myAnimator.SetBool("ATK0", true);

                if (this.isATKButtonDown)
                {

                    this.myAnimator.SetBool("ATK1", true);

                    if (this.isATKButtonDown)
                    {

                        this.myAnimator.SetBool("ATK2", true);

                        if (this.isATKButtonDown)
                        {

                            this.myAnimator.SetBool("ATK3", true);

                            if (this.isATKButtonDown)
                            {

                                this.myAnimator.SetBool("ATK4", true);

                            }

                        }



                    }

                }

            }



        }


       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shell")
        {
            TakeDamage(10);
            Debug.Log("弾の攻撃をうけたよ");
        }
    }

}

