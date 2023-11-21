using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Com.Mygame;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {
	public IshootArrow actionManager { get; set; }
	public ArrowFactory arrowfactory { get; set; }
	public GameObject Arrow;
	public GameObject Bow;
	public Text ScoreText;
	public int score;

	// the first scripts
	void Awake () {
		SSDirector director = SSDirector.getInstance ();
		director.setFPS (60);
		director.currentSceneController = this;
		director.currentSceneController.LoadResources ();
		actionManager = gameObject.AddComponent<CCActionManager>();
		arrowfactory = gameObject.AddComponent<ArrowFactory>();
	}

	public void hit(Vector3 dir)
	{
		Debug.Log("FirstController's hit");
		Debug.Log(actionManager);
		actionManager.playArrow(Bow.transform.position);
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
		Bow = Instantiate(Resources.Load("Prefabs/Crossbow")) as GameObject;
		Arrow.transform.position = Bow.transform.position;
	}

	public void Pause()
	{

	}

	public void Resume()
	{

	}
}
