using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour {

    public Camera mainCamera;

    public Camera subCamera;

    private bool mainCameraON = true;

    public CameraController cameraController;
    public SubCameraController subCameraController;

    //視点変更ボタンを押したときの判定
    private bool isCameraChangeButtonDown = false;

	// Use this for initialization
	void Start () {

        mainCamera.enabled = true;

        subCamera.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		
        //Cボタンを押した時、かつmainCameraONのステータスがtrueのとき
        if(Input.GetKeyDown(KeyCode.C) && mainCameraON == true)
        {
            mainCamera.enabled = false;

            subCamera.enabled = true;


            mainCameraON = false;
        }
        //Cボタンを押した時、かつmainCameraONのステータスがfalseのとき
        else if(Input.GetKeyDown(KeyCode.C) && mainCameraON == false)
        {
            mainCamera.enabled = true;

            subCamera.enabled = false;


            mainCameraON = true;
        }

        //joyコンRBボタンを押したとき、かつmainCameraONのステータスがtrueのとき
        if(Input.GetKeyDown("joystick button 5") && mainCameraON == true)
        {
            mainCamera.enabled = false;

            subCamera.enabled = true;

            mainCameraON = false;

            //  メインカメラのオイラー角を初期化
            cameraController.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            //  サブカメラのオイラー角を初期化
            subCameraController.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        //joyコンRBボタンを押したとき、かつmainCameraONのステータスがfalseのとき
        else if(Input.GetKeyDown("joystick button 5") && mainCameraON ==false)
        {
            mainCamera.enabled = true;

            subCamera.enabled = false;

            mainCameraON = true;

            //  メインカメラのオイラー角を初期化
            cameraController.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            //  サブカメラのオイラー角を初期化
            subCameraController.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

    }

    //視点移動ボタンを押したときの処理
    public void OnClick()
    
    {
        this.isCameraChangeButtonDown = true;

        if (this.isCameraChangeButtonDown && mainCameraON == true)
        {
            mainCamera.enabled = false;

            subCamera.enabled = true;


            mainCameraON = false;
        }
        //Cボタンを押した時、かつmainCameraONのステータスがfalseのとき
        else if (this.isCameraChangeButtonDown && mainCameraON == false)
        {
            mainCamera.enabled = true;

            subCamera.enabled = false;


            mainCameraON = true;
        }
    }
}
