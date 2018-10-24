﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    public bool scare = false;
    public float MoveSpeed = 5;
    public GameObject door;
    public GameObject mainPoint;
    public bool firstShowoff = true;
    Rigidbody rb;
    private NavMeshAgent agent;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
	

	// Update is called once per frame
	void Update () {
        /*
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Tentacle").Length; i++) {
            if (GameObject.FindGameObjectsWithTag("Tentacle")[i].GetComponent<Tentacle>().alive == true) {
                scare = true;
                break;
            }
        }
        */

        if (firstShowoff) {
            //transform.LookAt(new Vector3(mainPoint.transform.position.x, transform.position.y, mainPoint.transform.position.z));
            // rb.AddForce((transform.forward) * MoveSpeed);
            move(new Vector3(mainPoint.transform.position.x, transform.position.y, mainPoint.transform.position.z));
            if (Mathf.Abs(transform.position.x - mainPoint.transform.position.x) <1 && Mathf.Abs(transform.position.z - mainPoint.transform.position.z) < 1) {
                firstShowoff = false;
            }
        }

        if (scare) {
            //transform.LookAt(new Vector3(door.transform.position.x,transform.position.y, door.transform.position.z));
            //rb.AddForce((transform.forward) *  MoveSpeed);
            move(new Vector3(door.transform.position.x, transform.position.y, door.transform.position.z));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "door" && scare == true) {
            Destroy(gameObject);
        }
    }

    public void move(Vector3 position) {
        agent.SetDestination(position);
    }

}
