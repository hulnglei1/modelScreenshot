# modelScreenshot
		
多个3D模型多视角自动化截图工具 V0.1
huanglei 2022-03-24
===========================

###########功能描述

将多个模型在指定的Unity场景中截取前后左右顶5个方向的视图。
默认截图长宽高1000*1000*2600cm的位于原点的模型。如果有其他需求可以直接调整相机位置

![image](https://user-images.githubusercontent.com/17068469/159889375-8b649e2d-66a8-4035-9843-87beb0b4c5e1.png)
![image](https://user-images.githubusercontent.com/17068469/159889495-f942da7e-abcc-4587-929f-b690164db9ff.png)


###########环境依赖
无

###########部署步骤
1. 将Unitypackage导入想要截图场景的项目中
2. 将预制体 Camera，all拖入场景中。
3. 将all 拖入 Camera挂的脚本Camera Capture的目标物体
4. 将Camera下面的5个相机拖到Camera挂的脚本CameraCapture的目标相机中。
5. 点击CameraCapture脚本的“保存截图”按钮
6. 检查Project框下的是否新建StreamingAssets目录，里面是否有示例两个模型的前后左右顶5个方向的视图。
7. 将all层级下的2个模型替换成用户自己想要截图的模型。需要确保模型位置都在原点位置。重新截图。
8. 如果相机视角不满意，可以进入场景中调整相机位置和视角。
9. 如果对截图方向数目不满意，请邮箱联系作者升级hulnglei@163.com


###########目录结构描述
├── Readme.md                   // help

├── all.prefab                  // 示范模型

├── Camera.prefab               // 5个视图示范相机及拍摄功能

│   ├── CameraCapture.cs		// 截图脚本

│   ├── CameraCaptureEditor.cs	// Editor UI




###########V0.1.0 版本内容更新
1. 新功能     aaaaaaaaa
2. 新功能     bbbbbbbbb
3. 新功能     ccccccccc
4. 新功能     ddddddddd
