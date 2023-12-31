using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material[] skyboxes;
    private int currentSkyboxIndex;
    public bool runningSkybox = false;
    public bool staticSkybox = false;
    public bool showObstacle = false;
    public LayerMask interactionLayerMask;
    public GameObject target;
    public GameObject runningTarget;
    public GameObject target_1;
    public GameObject runningTarget_1;
    public GameObject obstacle;

    // 其他脚本逻辑...

    void Start()
    {
        currentSkyboxIndex = 0;
        target = GameObject.Find("Target");
        runningTarget = GameObject.Find("RunningTarget");
        target_1 = GameObject.Find("Target_1");
        runningTarget_1 = GameObject.Find("RunningTarget_1");
        obstacle = GameObject.Find("Obstacle");

        ShowTarget();
    }

    private void ShowTarget()
    {
        RenderSettings.skybox = skyboxes[currentSkyboxIndex];
        target.SetActive(staticSkybox);
        runningTarget.SetActive(runningSkybox);
        target_1.SetActive(staticSkybox);
        runningTarget_1.SetActive(runningSkybox);

        obstacle.SetActive(showObstacle);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 在按下"E"键时进行射线投射
            Ray ray = new(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactionLayerMask))
            {
                // 如果射线击中了"E"对象，执行切换天空盒的逻辑
                if (hit.collider.CompareTag("PressErunning"))
                {
                    if (!runningSkybox)
                    {
                        runningSkybox = true;
                        staticSkybox = false;
                        currentSkyboxIndex = 1;
                        
                    }
                    else
                    {
                        runningSkybox = false;
                        currentSkyboxIndex = 0;
                    }
                    
                }
                else if (hit.collider.CompareTag("PressE")) {
                    if (!staticSkybox)
                    {
                        staticSkybox = true;
                        runningSkybox = false;
                        currentSkyboxIndex = 2;

                    }
                    else
                    {
                        staticSkybox = false;
                        currentSkyboxIndex = 0;
                    }
                }

                showObstacle = runningSkybox || staticSkybox;
                ShowTarget();
            }
        }
    }
}