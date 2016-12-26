using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	private Animator m_Ani;
	public GameObject m_Ball;
	private Animator m_BAni;
	// Use this for initialization
	void Start () {
		m_Ani = GetComponent<Animator>();
		m_BAni=m_Ball.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.R)) {
			m_Ani.SetTrigger("rainbow");
			m_BAni.SetTrigger("rainbow");
			
			
		}
	
		if (Input.GetKey (KeyCode.F)) {
			m_Ani.SetTrigger("fish");
			m_BAni.SetTrigger("fish");
		}


	}


}