using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PicturesData : MonoBehaviour {

	private Dictionary<string, PictureData> datas = new Dictionary<string, PictureData>();

	public GameObject GetTexture(string name)
	{
		// package the big texture from many small picture
		GameObject temp = new GameObject(name);
		return temp;
	}

}
