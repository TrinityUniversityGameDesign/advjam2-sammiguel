using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeLocation : MonoBehaviour {

    public GameObject[] locations;
    public GameObject cat;
    public GameObject iguana;
    // Use this for initialization

    private void Awake()
    {
        int numLocations = locations.Length;
        System.Random rnd = new System.Random();
        int catLocId = rnd.Next(0, numLocations);
        int igLocId = rnd.Next(0, numLocations);
        while(igLocId == catLocId)
        {
            igLocId = rnd.Next(0, numLocations);
        }
        cat.transform.position = locations[catLocId].transform.position;
        iguana.transform.position = locations[igLocId].transform.position;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
