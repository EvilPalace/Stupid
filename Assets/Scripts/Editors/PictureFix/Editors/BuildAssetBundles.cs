using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class BuildAssetBundles : EditorWindow {
	public static BuildAssetBundles Instances;
	static Rect size;


	[MenuItem("Evil/Build AssetBundles")]
	static void BuildAssetBundle()
	{
		if (Instances) {
			Instances.Close ();
		}
		size = new Rect (200, 200, 500, 500);
		Instances = EditorWindow.GetWindowWithRect<BuildAssetBundles> (size);


		Instances.Show ();
	}
	void Awake()
	{

	}
	void OnDestroy()
	{
	}
	string subpath = "";
	void OnGUI()
	{
		 
		object[] temp_Selects = Selection.objects;
		GameObject prefab = new GameObject ("Name_Texture_Util");
		Name_Texture_Util util = prefab.AddComponent<Name_Texture_Util> ();
		List<Texture> temp_textures = util.textures;
		List<UIAtlas> temp_atlases = util.atlases;
		int textureID = 0;
		int atlasID = 0;
		for (int i = 0; i < temp_Selects.Length; i++) {
			Texture temp_tex = temp_Selects [i] as Texture;
			UIAtlas temp_atlas = null;
			GameObject ttemp = temp_Selects [i] as GameObject;
			if (ttemp) {
				temp_atlas = ttemp.GetComponent<UIAtlas> ();
			}
			if (temp_tex != null) {
				temp_textures.Add (temp_tex);
				GUILayout.BeginHorizontal ();
				GUILayout.Space (5);
				GUILayout.Label (i + ". " + temp_tex.name + "(Texture)");
				GUILayout.EndHorizontal ();

				Name_Texture_Util.MyData temp_mydata = new Name_Texture_Util.MyData ();
				temp_mydata.name = temp_tex.name;
				temp_mydata.isTexture = true;
				temp_mydata.textureID = textureID;
				textureID++;
				util.datas.Add (temp_tex.name, temp_mydata);
			}
			else if (temp_atlas != null) {
				temp_atlases.Add (temp_atlas);
				GUILayout.BeginHorizontal ();
				GUILayout.Space (5);
				GUILayout.Label (i + ". " + temp_atlas.name + "(Atlas)");
				GUILayout.EndHorizontal ();

				foreach (var item in temp_atlas.spriteList) {
					Name_Texture_Util.MyData temp_mydata = new Name_Texture_Util.MyData ();
					temp_mydata.name = item.name;
					temp_mydata.isTexture = false;
					temp_mydata.atlasID = atlasID;
					util.datas.Add (item.name, temp_mydata);
				}
				atlasID++;
			}
		}

		if (GUILayout.Button(" Build Prefab ")) {
			foreach (var item in util.datas) {
				Debug.Log (item.Key);
			}
			string path = Application.dataPath + "/Resources/" + prefab.name + ".prefab";
			path = path.Substring (path.IndexOf ("Assets"));
			PrefabUtility.CreatePrefab (path, prefab);
			DestroyImmediate (prefab);
		} else {
			DestroyImmediate (prefab);
		}


//		object[] temp_selects = Selection.objects;
//		List<Texture> temp_Sprite = new List<Texture> ();
//		for (int i = 0; i < temp_selects.Length; i++) {
//			Texture tex = temp_selects [i] as Texture;
//			if (tex != null) {
//				GUILayout.BeginHorizontal ();
//				GUILayout.Space (5);
//				GUILayout.Label (i + ". " + tex.name);
//				GUILayout.EndHorizontal ();
//				temp_Sprite.Add (tex);
//			}
//		}
//		GUILayout.Label ("");
//		GUILayout.BeginHorizontal ();
//		GUILayout.Label ("图片名字（带子目录，存放在Resources下）：");
//		subpath = GUILayout.TextField (subpath, GUILayout.Width (size.width / 3));
//		bool isBuild = GUILayout.Button (" Build AssetBundles ",GUILayout.Width(size.width/3));
//		GUILayout.EndHorizontal ();
//		if (isBuild) {
//			string path = Application.dataPath + "/Resources/" + subpath.Substring(0,subpath.LastIndexOf(
//			if (!Directory.Exists(path)) {
//				Directory.CreateDirectory (path);
//			}
//			Debug.Log (path);
//			GameObject temp = new GameObject ("Temp");
//			var picturedata = temp.AddComponent<PictureData> ();
//			picturedata.textures = temp_Sprite;
//			string prefabPath = path.Substring(path.IndexOf("Assets"));
//			PrefabUtility.CreatePrefab (prefabPath  + ".prefab", temp);
//
//			DestroyImmediate (temp);
//		}

//		if (GUILayout.Button("Instance")) { 
//			string path = Application.streamingAssetsPath.Substring (Application.streamingAssetsPath.IndexOf ("Assets"));
//			Debug.Log (path);
//			GameObject temp = Resources.Load<GameObject>("Temp");
//			GameObject.Instantiate (temp);
//		}
	}
}
