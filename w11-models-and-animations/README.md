# lab11-模型与动画2

第一人称射箭游戏

- [ ] 基础分：有博客；
- [ ] 1-3分钟视频：视频呈现游戏主要游玩过程；
- [x] 地形：使用地形组件，上面有草、树；
- [x] 天空盒：使用天空盒，天空可随玩家位置 或 时间变化 或 按特定按键切换天空盒；
- [x] 固定靶：有一个以上固定的靶标；
- [x] 运动靶：有一个以上运动靶标，运动轨迹，速度使用动画控制；
- [x] 射击位：地图上应标记若干射击位，仅在射击位附近可以拉弓射击，每个位置有 n 次机会；
- [x] 驽弓动画：支持蓄力半拉弓，然后 hold，择机 shoot；
- [x] 游走：玩家的驽弓可在地图上游走，不能碰上树和靶标等障碍；
- [x]  碰撞与计分：在射击位，射中靶标的相应分数，规则自定。

地形

使用地形组件，纹理使用Standard Assets -> Environment -> TerrainAssets -> SurfaceTextures -> GrassHillAIbedo，树使用Standard Assets -> Environment -> SpeedTree里面三种树。

![terrain](pic/terrain.png)

天空盒

使用天空盒，按特定按键切换天空盒。

使用Material[]数组存放天空盒，需要在Inspector页面手动存放三个天空盒。

- 游戏默认渲染索引为0的天空盒；
- 进入射击运动靶标场景时，渲染索引为1的天空盒；
- 进入射击固定靶标场景时，渲染索引为2的天空盒。

```csharp
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material[] skyboxes;
    private int currentSkyboxIndex;
	...

    // 其他脚本逻辑...

    void Start()
    {
        currentSkyboxIndex = 0;
		...
        ShowTarget();
    }

    private void ShowTarget()
    {
        RenderSettings.skybox = skyboxes[currentSkyboxIndex];
		...
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
                        ...
                        currentSkyboxIndex = 1;
                        
                    }
                    else
                    {
                        ...
                        currentSkyboxIndex = 0;
                    }
                    
                }
                else if (hit.collider.CompareTag("PressE")) {
                    if (!staticSkybox)
                    {
                        ...
                        currentSkyboxIndex = 2;

                    }
                    else
                    {
                        ...
                        currentSkyboxIndex = 0;
                    }
                }
                ShowTarget();
            }
        }
    }
}
```

效果

索引0

![index_0](pic/index_0.png)

索引1

![index_1](pic/index_1.png)

索引2

![index_2](pic/index_2.png)

固定靶

有一个以上固定的靶标。固定靶标制作成红色的圆柱体预制件。

![target](pic/target.png)

场景里的两个红色靶标

![index_2](pic/index_2.png)

运动靶

有一个以上运动靶标，运动轨迹，速度使用动画控制。运动靶标制作成蓝色的圆柱体预制件，并且由不同的动画控制器控制不同的动画。

![running_target](pic/running_target.png)

RunningTarget的动画

RunningTarget_1的动画

射击位

地图上用“Press 'E' to play game”标记了两个射击位，仅对准标记按下“E”箭后可以拉弓射击，每个位置有无限次机会。

驽弓动画

支持蓄力半拉弓，然后 hold，择机 shoot。

点击左键后开始蓄力拉弓（注意是点击，无需持续按压），然后点击右键hold（无论是否蓄满都需要），最后点击左键发射。箭发射的力度也会随着蓄力程度变化。

游走

玩家的驽弓可在地图上游走，不能碰上树和靶标等障碍。

使用了Standard Assets -> Characters -> FirstPersonCahracter -> Prefabs -> FPSController.prefab。游戏开始时动态加载弩弓，由于没有设置弩弓的碰撞器，仅使用了第一人称自带的碰撞器，因此会出现弩弓穿模的现象，不过问题不大。

碰撞与计分

射中靶标获得一分。



参考文献

射箭打靶

[【Unity3D】射箭打靶游戏（简单工厂+物理引擎编程）](https://www.cnblogs.com/xieyuanzhen-Feather/p/6666586.html)（主要参考）

[Unity3D学习之射箭小游戏](https://blog.csdn.net/Kiloveyousmile/article/details/69491549)