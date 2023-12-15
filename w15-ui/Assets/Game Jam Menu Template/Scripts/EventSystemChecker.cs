using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventSystemChecker : MonoBehaviour
{
    private void OnEnable()
    {
        // 订阅sceneLoaded事件
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // 在禁用时取消订阅sceneLoaded事件，以避免内存泄漏
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 在新场景加载完成后执行的逻辑

        // 如果没有EventSystem（用于UI交互）
        if (!FindObjectOfType<EventSystem>())
        {
            // 创建一个新的GameObject并命名为"EventSystem"
            GameObject obj = new GameObject("EventSystem");

            // 添加所需的组件
            obj.AddComponent<EventSystem>();
            // 注意：以下是一种新的设置激活状态的方式，具体取决于你使用的 Unity 版本和输入系统
            StandaloneInputModule inputModule = obj.AddComponent<StandaloneInputModule>();

            // 设置模块的激活状态
            inputModule.enabled = true; // 或者根据你的需求设置其他值
        }
    }
}
