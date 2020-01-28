using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{

    //Playerのオブジェクト
    private GameObject redNight;

    //Playerとカメラの距離(X座標）
    private float differenceX;

    //Playerとカメラの距離(Y座標）
    private float differenceY;

    //Playerとカメラの距離(Z座標）
    private float differenceZ;

    public CameraController cameraController;

    private float sub_rotate_speed = 2.0f;



    // Start is called before the first frame update
    void Start()
    {
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
    void Update()
    {
        //Playerの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(this.redNight.transform.position.x - differenceX, (this.redNight.transform.position.y - differenceY) + 1f, (this.redNight.transform.position.z - differenceZ) -2f );

        //左スティックでサブカメラの視点変更
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");

        //右スティックでメインカメラの視点変更
        float rsh = Input.GetAxis("R_Stick_H");
        float rsv = Input.GetAxis("R_Stick_V");

        //スティックが倒れていれば移動
        if (rsh != 0 || rsv != 0)
        {
            RotateSubCameraAngle();

            //cameraController.RotateCameraAngle();

            // var direction = new Vector3(rsh, 0f, rsv);

            // this.transform.rotation = transform.rotation = Quaternion.LookRotation((transform.position + (Vector3.right * rsh * 2.0f) + (Vector3.forward * rsv * 2.0f)) - transform.position);
        }
    
    }

    //  サブカメラのアングル変更メソッド
    public void RotateSubCameraAngle()
    {
        //  右スティックの傾け具合に応じて角度を代入
        Vector3 angle = new Vector3(
            Input.GetAxis("R_Stick_H") * sub_rotate_speed,
            Input.GetAxis("R_Stick_V") * sub_rotate_speed,
            0);
        transform.eulerAngles += new Vector3(-1 * angle.y, angle.x);   //  オイラー角変更
    }

}
