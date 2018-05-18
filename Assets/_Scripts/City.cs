using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class City : MonoBehaviour {

	public TextAsset xml;
	private char open;
	private char closed;
	private string name;
	private float size;
	private Vector3 start;
	private Vector3 end;
	private List<Node> points;


	// Use this for initialization
	void Start () {
		string data = xml.text;
		ParseXml(data);
	}
	
	void ParseXml(string data){
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(data);

		foreach(XmlElement element in xmlDoc.SelectNodes("City")){
			name = element.GetAttribute("Name");
			size = float.Parse(element.GetAttribute("Size"));
			open = char.Parse(element.GetAttribute("Open"));
			closed = char.Parse(element.GetAttribute("Closed"));

			string start = element.GetAttribute("Start");
			float sx = float.Parse(start.Split(',')[0]);
			float sz = float.Parse(start.Split(',')[1]);

			this.start = new Vector3(sx, 0f, sz);

			string end = element.GetAttribute("End");
			float ex = float.Parse(end.Split(',')[0]);
			float ez = float.Parse(end.Split(',')[1]);

			this.end = new Vector3(ex, 0f, ez);
		}

		foreach(XmlElement element in xmlDoc.SelectNodes("City/Line")){
			string line = element.InnerXml;
			int z = int.Parse(element.GetAttribute("Id"));
			ParseLine(line, z);
		}
	}

	void ParseLine(string l, int z){
		char[] line = l.ToCharArray();

		for(int x = 0; x<size; x++){
			Vector3 pos = new Vector3(x, 0, z);
			GameObject go;
			
			if(line[x] == this.closed){
				go = GameObject.CreatePrimitive(PrimitiveType.Cube);
				go.transform.position = pos;
				go.GetComponent<Renderer>().material.color = Color.grey;
				go.name = "Closed";
			}else{
				go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				go.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
				go.transform.position = pos;
				go.GetComponent<Renderer>().material.color = Color.red;
				
				go.name = "Open";
			}
		}
	}
}
