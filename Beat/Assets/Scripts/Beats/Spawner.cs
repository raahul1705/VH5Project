using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public NotePool notePool;
    [SerializeField] Lane lane;
    [SerializeField] float dropVelocity = 200f;
    [SerializeField] float gravityConst = 5f;

	// Use this for initialization
	void Start () {
        lane = GetComponent<Lane>();
	}
	
	// Update is called once per frame
	void Update () {
        Spawn();
	}

    void Spawn()
    {

    }

    public GameObject SpawnNote()
    {
        GameObject obj = notePool.GetPooledObject();
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        //obj.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, dropVelocity), ForceMode.VelocityChange);
        obj.GetComponent<Rigidbody>().velocity = new Vector3(0,-gravityConst, -dropVelocity);
        obj.SetActive(true);
        return obj;
    }
}
