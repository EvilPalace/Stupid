using UnityEngine;
using System.Collections;
using DragonBones;
using System.Collections.Generic;

public class CharactorFactory : MonoBehaviour {
	private static CharactorFactory _instance;
	public static CharactorFactory Instance
	{
		get {
			if (_instance == null) {
				GameObject temp = new GameObject ();
				_instance = temp.AddComponent<CharactorFactory> ();
				temp.hideFlags = HideFlags.HideInHierarchy;
			}
			return _instance;
		}
	}
	public List<UnityArmatureComponent> amatures;
	// Use this for initialization
	void Start () {
		DragonBonesData boneData = UnityFactory.factory.LoadDragonBonesData ("BirdAndCentaur/skeleton");
		UnityTextureAtlasData texture = UnityFactory.factory.LoadTextureAtlasData ("BirdAndCentaur/texture");
		amatures.Add (UnityFactory.factory.BuildArmatureComponent ("centaur/charactor"));


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
