using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material[] skyboxes;
    private int currentSkyboxIndex;
    public bool runningSkybox = false;
    public bool staticSkybox = false;
    public LayerMask interactionLayerMask;

    // 其他脚本逻辑...

    private void Start()
    {
        currentSkyboxIndex = 0;
        RenderSettings.skybox = skyboxes[currentSkyboxIndex];
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
                        currentSkyboxIndex = 2;

                    }
                    else
                    {
                        staticSkybox = false;
                        currentSkyboxIndex = 0;
                    }
                }
                RenderSettings.skybox = skyboxes[currentSkyboxIndex];
            }
        }
    }
}