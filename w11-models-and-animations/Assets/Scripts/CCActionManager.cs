using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class CCActionManager : SSActionManager, ISSActionCallback, IshootArrow {
	
	public FirstController sceneController;
	public ArrowFactory arrowFactory;
	public play EmitArrow;
	public GameObject Arrow;
	public float shootForce;

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

	public void playArrow()
	{
		shootForce = 0.25f;

        Quaternion cameraRotation = Camera.main.transform.rotation;


		EmitArrow = play.GetSSAction();
		Arrow = arrowFactory.GetArrow1();
        // set arrow's initial position
        Arrow.transform.position = sceneController.CrossBow.transform.position;
		Arrow.transform.rotation = cameraRotation;
		Vector3 shootDirection = cameraRotation * Vector3.forward;
		Arrow.GetComponent<Rigidbody>().AddForce(shootDirection * shootForce, ForceMode.Impulse);
		this.RunAction(Arrow, EmitArrow, this);
		Arrow.GetComponent<Data>().hit = false;
	}

	public void SSActionEvent (SSAction source, SSActionEventType events = SSActionEventType.Competeted, int intParam = 0, string strParam = null, Object objectParam = null)
	{
		arrowFactory.FreeArrow1(source.gameobject);
		Debug.Log("free");
		source.gameobject.GetComponent<Data>().hit = false;
	}
}

