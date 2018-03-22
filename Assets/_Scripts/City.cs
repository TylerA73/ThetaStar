using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class City : MonoBehaviour {

	public TextAsset xml;
	private string open;
	private string closed;
	private string name;
	private float size;
	private Vector3 start;
	private Vector3 end;


	// Use this for initialization
	void Start () {
		string data = xml.text;
		Parse(data);

		Debug.Log("Name: " + name);
		Debug.Log("Size: " + size);
		Debug.Log("Open: " + open);
		Debug.Log("Closed: " + closed);
	}
	
	void Parse(string data){
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(data);

		foreach(XmlElement element in xmlDoc.SelectNodes("City")){
			name = element.GetAttribute("Name");
			size = float.Parse(element.GetAttribute("Size"));
			open = element.GetAttribute("Open");
			closed = element.GetAttribute("Closed");
		}
	}
}
