using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //Playerのオブジェクト
    private GameObject redNight;

    //Playerとカメラの距離(X座標）
    private float differenceX;

    //Playerとカメラの距離(Y座標）
    private float differenceY;

    //Playerとカメラの距離(Z座標）
    private float differenceZ;

    private float rotate_speed = 3.0f;





    // Use this for initialization
    void Start () {
        //Playerのオブジェクトを取得
        this.redNight = GameObject.Find("M05");

        //Playerとカメラの位置の差を求める(X座標）
        this.differenceX = redNight.transform.position.x - this.transform.position.x;

        //Playerとカメラの位置の差を求める(Y座標）
        this.differenceY = redNight.transform.position.y - this.transform.position.y;

        //Playerとカメラの位置の差を求める(Z座標）
        this.differenceZ = redNight.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update () {

        //Playerの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(this.redNight.transform.position.x - differenceX, (this.redNight.transform.position.y - differenceY) + 25f, (this.redNight.transform.position.z - differenceZ) + 10f);

        //右スティックでメインカメラの視点変更(右スティックの傾き具合を代入)
        float rsh = Input.GetAxis("R_Stick_H");
        float rsv = Input.GetAxis("R_Stick_V");

        //スティックが倒れていれば移動
        if (rsh != 0 || rsv != 0)
        {
            RotateCameraAngle();

            //var direction = new Vector3(rsh, 0f, rsv);

            //this.transform.rotation = transform.rotation = Quaternion.LookRotation((transform.position + (Vector3.right * rsh * 2.0f) + (Vector3.forward * rsv * 2.0f)) - transform.position);
        }
    }

    //  カメラのアングル変更メソッド
    public void RotateCameraAngle()
    {
        //  右スティックの傾け具合に応じて角度を代入
        Vector3 angle = new Vector3(
            Input.GetAxis("R_Stick_H") * rotate_speed,
            Input.GetAxis("R_Stick_V") * rotate_speed,
            0);
        transform.eulerAngles += new Vector3( -1 * angle.y, angle.x);   //  オイラー角変更
    }
}
