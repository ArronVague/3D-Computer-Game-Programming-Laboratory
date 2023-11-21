using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class CCActionManager : SSActionManager, ISSActionCallback, IshootArrow {
	
	public FirstController sceneController;
	public ArrowFactory arrowFactory;
	public play EmitArrow;
	public GameObject Arrow;
	public float force = 0f;
	int count = 0;

	protected new void Start() {
		sceneController = (FirstController)SSDirector.getInstance ().currentSceneController;
		sceneController.actionManager = this;
		arrowFactory = sceneController.arrowfactory;
	}

	// Update is called once per frame
	protected new void Update ()
	{
		base.Update ();
	}
		
	public float getforce()
	{
		return force;
	}

	public void playArrow(Vector3 dir)
	{
		Debug.Log("CCActionManager's playArrow");
		force = Random.Range(-50, 50);
		EmitArrow = play.GetSSAction();
		Debug.Log(EmitArrow);
		Arrow = arrowFactory.GetArrow1();
		Debug.Log(Arrow);
		Arrow.transform.position = dir;
		Arrow.GetComponent<Rigidbody>().AddForce(new Vector3(force, 0.3f, 2), ForceMode.Impulse);
		Debug.Log("this?");
		this.RunAction(Arrow, EmitArrow, this);
		Debug.Log("or this?");
		Arrow.GetComponent<Data>().hit = false;
		Debug.Log("why not");
	}

	public void SSActionEvent (SSAction source, SSActionEventType events = SSActionEventType.Competeted, int intParam = 0, string strParam = null, Object objectParam = null)
	{
		arrowFactory.FreeArrow1(source.gameobject);
		Debug.Log("free");
		source.gameobject.GetComponent<Data>().hit = false;
	}
}

