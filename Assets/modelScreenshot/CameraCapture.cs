using UnityEngine;

using System.IO;

 

///


/// 相机截图

/// huanglei 2022-03-24

///


public class CameraCapture : MonoBehaviour {

 

    // 截图尺寸

    public enum CaptureSize {

        CameraSize,

        ScreenResolution,

        FixedSize

    }

	//目标物体
	public GameObject allModel;

    // 目标摄像机

    public Camera[] targetCameraList = new Camera[5];


    // 截图尺寸

    public CaptureSize captureSize = CaptureSize.CameraSize;

    // 像素尺寸

    public Vector2 pixelSize;

    // 保存路径

    public string savePath = "StreamingAssets/";

    // 文件名称

    public string[] fileNameList = {"1.jpg", "2.jpg","3.jpg","4.jpg","5.jpg"};

	


 

    #if UNITY_EDITOR

    private void Reset() {
		
		GameObject myModel = GetComponent<GameObject>();
		
		for(int i = 0; i < targetCameraList.Length; i++){
			targetCameraList[i] = GetComponent<Camera>();
		}

        pixelSize = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);

    }

    #endif

 

    ///保存截图


    /// 目标摄像机

    public void saveCapture() {

        Vector2 size = pixelSize;
		
		Directory.CreateDirectory(Application.dataPath + "/" + savePath);			

		
		foreach (Transform child in allModel.transform){
			//激活模型
			GameObject myModel = child.gameObject;
			myModel.SetActive(true);
			string modelName = myModel.name;
			
			for(int i = 0; i < targetCameraList.Length; i++){
				string path = Application.dataPath + "/" + savePath + modelName +"/" + fileNameList[i];	
				Directory.CreateDirectory(Application.dataPath + "/" + savePath + modelName);			
				saveTexture(path, capture(targetCameraList[i], (int)size.x, (int)size.y));
			}

				//禁用模型
			myModel.SetActive(false);			
		}
		


    }

 

    ///相机截图


    /// 目标相机

    public static Texture2D capture(Camera camera) {

        return capture(camera, Screen.width, Screen.height);

    }

 

    ///相机截图


    /// 目标相机

    /// 宽度

    /// 高度

    public static Texture2D capture(Camera camera, int width, int height) {
		

        RenderTexture rt = new RenderTexture(width, height, 0);

        rt.depth = 24;

        rt.antiAliasing = 8;

        camera.targetTexture = rt;

        camera.RenderDontRestore();

        RenderTexture.active = rt;

        Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false, true);

        Rect rect = new Rect(0, 0, width, height);

        texture.ReadPixels(rect, 0, 0);

        texture.filterMode = FilterMode.Point;

        texture.Apply();

        camera.targetTexture = null;

        RenderTexture.active = null;

        DestroyImmediate(rt);
		
		

        return texture;

    }

 

    ///保存贴图


    /// 保存路径

    /// Texture2D

    public static void saveTexture(string path, Texture2D texture) {

        File.WriteAllBytes(path, texture.EncodeToJPG());

        #if UNITY_EDITOR

        // Debug.Log("已保存截图到:" + path);


        #endif

    }




	


 

}