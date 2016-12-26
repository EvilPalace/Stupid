using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Name_Texture_Util : MonoBehaviour {
	public class MyData
	{
		public string name;
		public bool isTexture;
		public int textureID;
		public int atlasID;
	}
	public Dictionary<string,MyData> datas = new Dictionary<string, MyData>();
	public List<Texture> textures = new List<Texture> ();
	public List<UIAtlas> atlases = new List<UIAtlas>();

	private static Name_Texture_Util util;
	public static GameObject GetPicture(string name)
	{
		if (util == null) {
			util = Resources.Load<GameObject>("Name_Texture_Util").GetComponent<Name_Texture_Util>();
		}
		return util._GetPicture (name);
	}
	private void InitDatas()
	{
		datas.Clear ();
		int index = 0;
		while (index < textures.Count) {
			MyData temp = new MyData ();
			temp.name = textures [index].name;
			temp.isTexture = true;
			temp.textureID = index;
			if (!datas.ContainsKey(temp.name)) {
				datas.Add (temp.name, temp);
			}
			++index;
		}
		index = 0;
		while (index < atlases.Count) {
			foreach (var item in atlases[index].spriteList) {
				MyData temp = new MyData ();
				temp.name = item.name;
				temp.isTexture = false;
				temp.atlasID = index;
				if (!datas.ContainsKey(temp.name)) {
					datas.Add (temp.name, temp);
				}
			}
			++index;
		}
	}

	public GameObject _GetPicture(string name)
	{
		if (isNeedInitDatas) {
			InitDatas ();
		}
		if (!datas.ContainsKey(name)) {
			return null;
		}
		MyData tempData = datas [name];
		GameObject ret = new GameObject (name);
		if (tempData.isTexture) {
			UITexture tempTex = ret.AddComponent<UITexture> ();
			tempTex.mainTexture = textures [tempData.textureID];
			tempTex.MakePixelPerfect ();
		} else {
			UISprite tempSpr = ret.AddComponent<UISprite> ();
			tempSpr.atlas = atlases [tempData.atlasID];
			tempSpr.spriteName = name;
			tempSpr.MakePixelPerfect ();
		}
		return ret;
	}

	private bool isNeedInitDatas
	{
		get{
			int count = 0;
			count += textures.Count;
			foreach (var item in atlases) {
				count += item.spriteList.Count;
			}
			return datas.Count != count;
		}
	}
}
