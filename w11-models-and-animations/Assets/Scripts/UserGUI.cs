using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserGUI : MonoBehaviour
{

    private IUserAction action;     // �û������ӿ�
    private ISceneController queryInt;   // �����ӿ�
    public bool isButtonDown = false;
    public Camera camera;

    public Text WindForce;
    public Text WindDirection;
    void Start()
    {
        // ʵ��������
        action = SSDirector.getInstance().currentSceneController as IUserAction;
        queryInt = SSDirector.getInstance().currentSceneController as ISceneController;
    }
    void Update()
    {
        float force = queryInt.getWindforce();
        if (force < 0)
        {
            WindDirection.text = "Wind Direction : Left";
        }
        else if (force > 0)
        {
            WindDirection.text = "Wind Direction : Right";
        }
        else
        {
            WindDirection.text = "Wind Direction : No Wind";
        }
        WindForce.text = "Wind Force : " + queryInt.getWindforce(); //��ʾ����
    }
    void OnGUI()
    {
        GUIStyle fontstyle1 = new GUIStyle();
        fontstyle1.fontSize = 50;
        fontstyle1.normal.textColor = new Color(255, 255, 255);
        if (GUI.RepeatButton(new Rect(0, 0, 120, 40), "Rule"))
        {
            action.ShowDetail();
        }
        if (GUI.Button(new Rect(0, 60, 120, 40), "Start"))
        {
            action.StartGame();
        }
        if (Input.GetMouseButtonDown(0) && !isButtonDown)
        {
            Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);
            Debug.Log("RayDir = " + mouseRay.direction);
            action.hit(mouseRay.direction);
            isButtonDown = true;
        }
        else if (Input.GetMouseButtonDown(0) && isButtonDown)
        {
            isButtonDown = false;
        }
    }
}