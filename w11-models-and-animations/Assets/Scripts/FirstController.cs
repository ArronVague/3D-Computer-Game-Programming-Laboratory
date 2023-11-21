using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Com.Mygame;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {
	public IshootArrow actionManager { get; set; }
	public ArrowFactory arrowfactory { get; set; }
	public GameObject Arrow;
	public GameObject CrossBow;
	public Text ScoreText;
	public int score;

	public Transform cameraTransform;

	// the first scripts
	void Awake () {
		SSDirector director = SSDirector.getInstance ();
		director.setFPS (60);
		director.currentSceneController = this;
		cameraTransform = Camera.main.transform;
		director.currentSceneController.LoadResources ();
		actionManager = gameObject.AddComponent<CCActionManager>();
		arrowfactory = gameObject.AddComponent<ArrowFactory>();
	}

	public void hit(Vector3 dir)
	{
		Debug.Log("FirstController's hit");
		Debug.Log(actionManager);
		actionManager.playArrow(CrossBow.transform.position);
	}

    // Update is called once per frame
    void Update()
    {
		//give advice first
/*		ScoreText.text = "Score: " + score.ToString();*/
    }

    public float getWindforce()
    {
        return actionManager.getforce();
    }

    public void StartGame()
	{

	}

	public void ShowDetail()
	{
		GUI.Label(new Rect(220, 50, 350, 250), "you can control the bow and click mouse to emit arrow");
	}

    // loading resources for first scence
    public void LoadResources () {
		Debug.Log("load...\n");

		Instantiate(Resources.Load("Prefabs/Target"));
        CrossBow = Instantiate(Resources.Load("Prefabs/Crossbow")) as GameObject;
		CrossBowFollow bowFollowScript = CrossBow.GetComponent<CrossBowFollow>();
		if (bowFollowScript != null )
		{
			Debug.Log("bow");
			bowFollowScript.cameraTransform = cameraTransform;
			bowFollowScript.offset = new Vector3(0, -1f, 1f);
		}

		Arrow.transform.position = CrossBow.transform.position;
	}

	public void Pause()
	{

	}

	public void Resume()
	{

	}
}
