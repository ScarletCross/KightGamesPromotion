using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HPStatusUI : MonoBehaviour
{

    //　敵のステータス
    private Enemy enemyStatus;
    //　HP表示用スライダー
    public Slider hpSlider;


    // Use this for initialization
    void Start()
    {

        //　自身のルートに取り付けている敵のステータス取得
        enemyStatus = transform.root.GetComponent<Enemy>();

        //　HP用Sliderを子要素から取得
        hpSlider = transform.Find("HP_Bar").GetComponent<Slider>();

        //　スライダーの値0～1の間になるように比率を計算
        hpSlider.value = (float)enemyStatus.GetMaxHp() / (float)enemyStatus.GetMaxHp();

    }

    // Update is called once per frame
    void Update()
    {


        //　カメラと同じ向きに設定
        transform.rotation = Camera.main.transform.rotation;
        
    }

    //　死んだらHPUIを非表示にする
    public void SetDisable()
    {
        gameObject.SetActive(false);
    }

    public void UpdateHPValue()
    {
        hpSlider.value = (float)enemyStatus.GetHp() / (float)enemyStatus.GetMaxHp();
    }

    //Invoked when a submit button is clicked.
    public void SubmitSliderSetting()
    {
        //Displays the value of the slider in the console.
        Debug.Log(hpSlider.value);
    }
}
