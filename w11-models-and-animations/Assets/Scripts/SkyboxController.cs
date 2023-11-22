using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material[] skyboxes;
    private int currentSkyboxIndex = 0;

    // �����ű��߼�...
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentSkyboxIndex = (currentSkyboxIndex - 1 + skyboxes.Length) % skyboxes.Length;
            RenderSettings.skybox = skyboxes[currentSkyboxIndex];
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentSkyboxIndex = (currentSkyboxIndex + 1) % skyboxes.Length;
            RenderSettings.skybox = skyboxes[currentSkyboxIndex];
        }
    }
}