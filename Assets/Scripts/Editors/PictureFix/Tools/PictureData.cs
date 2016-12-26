using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartPicture
{
	public string name = "";
	public Vector3 size = Vector3.one;
	public Vector3 position = Vector3.zero;
	public float angle = 0;
}
public class PictureData : MonoBehaviour {
	public string Name = "";
	public string backgroundName = "";
	public Vector2 size = Vector2.one;
	private List<PartPicture> parts = new List<PartPicture>();

	public GameObject GetTexture()
	{
		GameObject temp = Name_Texture_Util.GetPicture (backgroundName);
		temp.name = Name;

		foreach (var item in parts) {
			GameObject temp1 = Name_Texture_Util.GetPicture (item.name);
			temp1.transform.localScale = size;
			temp1.transform.RotateAround (temp1.transform.position, transform.forward, item.angle);
			Vector3 temp_value = Vector3.one;

		}
		return temp;
	}
}
