using UnityEngine;
using System.Collections;
using DragonBones;

public class Test1 : MonoBehaviour {
	UnityArmatureComponent amatureComponent;
	// Use this for initialization
	void Start () {
//		DragonBonesData boneData = UnityFactory.factory.LoadDragonBonesData ("BirdAndCentaur/skeleton");
//		UnityTextureAtlasData texture = UnityFactory.factory.LoadTextureAtlasData ("BirdAndCentaur/texture");
//
//		amatureComponent = UnityFactory.factory.BuildArmatureComponent ("centaur/charactor");
//		amatureComponent.animation.Play ("run", 0);
//		//amatureComponent.animation.
//
//		//amatureComponent.


		Name_Texture_Util.GetPicture ("Image 45");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
