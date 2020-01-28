using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.AI;

public class Chase : MonoBehaviour {

    private GameObject M05;

    private NavMeshAgent agent;
       


	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();

        M05 = GameObject.Find("M05");

	}
	
	// Update is called once per frame
	void Update () {
        //ターゲットの位置を目的地に設定する
        agent.SetDestination(M05.transform.position);
	}
}
