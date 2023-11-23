using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material[] skyboxes;
    private int currentSkyboxIndex;
    public bool runningSkybox = false;
    public bool staticSkybox = false;
    public LayerMask interactionLayerMask;
    public GameObject target;
    public GameObject runningTarget;

    // �����ű��߼�...

    void Start()
    {
        currentSkyboxIndex = 0;
        target = GameObject.Find("Target");
        runningTarget = GameObject.Find("RunningTarget");
        ShowTarget();

    }

    private void ShowTarget()
    {
        RenderSettings.skybox = skyboxes[currentSkyboxIndex];
        target.SetActive(staticSkybox);
        runningTarget.SetActive(runningSkybox);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �ڰ���"E"��ʱ��������Ͷ��
            Ray ray = new(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactionLayerMask))
            {
                // ������߻�����"E"����ִ���л���պе��߼�
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
                ShowTarget();
            }
        }
    }
}