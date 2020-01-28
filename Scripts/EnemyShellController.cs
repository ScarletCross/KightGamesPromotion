using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShellController : MonoBehaviour {

    public GameObject enemyShellPrefab;

    public float shotSpeed;

    //効果音を入れる
    //public AudioClip shotSound;

    private float shotIntarval;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        shotIntarval += 1;

        if (shotIntarval % 120 == 0)
        {
            GameObject enemyShell = (GameObject)Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            // forwardはZ軸方向（青軸方向）、この方向に力を加える。
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            //効果音を鳴らす
            // AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Destroy(enemyShell, 2.0f);
        }
    }
}
