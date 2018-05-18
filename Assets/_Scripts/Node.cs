using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node{
	private float totalCost{ get; set; }
	private float cost { get; set; }
	private Vector3 position;
	public Node from;

	public Node(Vector3 pos){
		totalCost = Mathf.Infinity;
		cost = 1f;
		position = pos;
	}
}
