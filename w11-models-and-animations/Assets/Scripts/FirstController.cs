using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {
	public IshootArrow actionManager { get; set; }
	public ArrowFactory arrowFactory { get; set; }

	public CCActionManager actionManager { get; set;}
	public GameObject move1,move2;

	// the first scripts
	void Awake () {
		SSDirector director = SSDirector.getInstance ();
		director.setFPS (60);
		director.currentSceneController = this;
		director.currentSceneController.LoadResources ();
		Debug.Log ("awake FirstController!");
	}
	 
	// loading resources for first scence
	public void LoadResources () {
		;
	}

	public void Pause ()
	{
		throw new System.NotImplementedException ();
	}

	public void Resume ()
	{
		throw new System.NotImplementedException ();
	}

	#region IUserAction implementation
	public void GameOver ()
	{
		SSDirector.getInstance ().NextScene ();
	}
	#endregion


	// Use this for initialization
	void Start () {
		//give advice first
	}
	
	// Update is called once per frame
	void Update () {
		//give advice first
	}

}
