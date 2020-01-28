using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour {


    //ChildPrefabを入れる
    public GameObject ChildPrefab;

    //DaikonPrefabを入れる
    public GameObject DaikonPrefab;

    //MushPrefabを入れる
    public GameObject MushPrefab;

    //StornePrefabを入れる
    public GameObject StornePrefab;

    //モンスターを出現させるX方向の範囲
  //  private float posRangeX = 44.0f;

    int count = 0;

    int max = 300;

	// Use this for initialization
	void Start () {

        InvokeRepeating("Generate", 1, 5);
	}
	
    void Generate()
        {
        if (count == max)
        {
            return;
        }

        float x = Random.Range(-35f, 35f);

        float y = 16f;

        float z = Random.Range(20f, 80f);

        Vector3 position = new Vector3(x, y, z);

        //どのモンスターを出すかのランダム決定
        int num = Random.Range(1, 12);

        if (num <= 3)
        {
            Instantiate(ChildPrefab, position, Quaternion.identity);
        }
        else if (4 <= num && num <= 6)
        {
            Instantiate(DaikonPrefab, position, Quaternion.identity);
        }
        else if (7 <= num && num <= 9)
        {
            Instantiate(MushPrefab, position, Quaternion.identity);
        }
        else if(10 <= num && num <= 12)
        {
            Instantiate(StornePrefab, position, Quaternion.identity);
        }
                
                



        count++;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
