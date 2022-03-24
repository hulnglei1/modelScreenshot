using UnityEditor;

using UnityEngine;

 

///


/// 相机截图 编辑器

/// ZhangYu 2018-07-06

///


[CanEditMultipleObjects]

[CustomEditor(typeof(CameraCapture))]

public class CameraCaptureEditor : Editor {

 

    public override void OnInspectorGUI() {

        // 属性

        CameraCapture script = (CameraCapture)target;

        int selected = (int)script.captureSize;

 

        // 重绘GUI

        EditorGUI.BeginChangeCheck();
		drawProperty("allModel", "目标物体");
		
	    drawProperty("targetCameraList", "目标像机");


        string[] options = new string[] { "像机尺寸", "屏幕尺寸", "固定尺寸"};

        selected = EditorGUILayout.Popup("截图尺寸", selected, options, GUILayout.ExpandWidth(true));

        script.captureSize = (CameraCapture.CaptureSize)selected;

        if (script.captureSize == CameraCapture.CaptureSize.FixedSize) {

            drawProperty("pixelSize", "像素尺寸");

            EditorGUILayout.HelpBox("请保持正确的宽高比！\n否则截图区域可能出现错误。", MessageType.Info);

        }

        drawProperty("savePath", "保存路径");

		// for(int i = 0; i < 5; i++){
	    drawProperty("fileNameList", "文件名称");
		// }

        // drawProperty("fileName1", "文件名称");
		// drawProperty("fileName2", "文件名称");
		// drawProperty("fileName3", "文件名称");
		// drawProperty("fileName4", "文件名称");
		// drawProperty("fileName5", "文件名称");

 

        // 保存截图按钮

        bool isPress = GUILayout.Button("保存截图", GUILayout.ExpandWidth(true));

        if (isPress) script.saveCapture();

        if (EditorGUI.EndChangeCheck()) serializedObject.ApplyModifiedProperties();

    }

 

    private void drawProperty(string property, string label) {

        EditorGUILayout.PropertyField(serializedObject.FindProperty(property), new GUIContent(label), true);

    }

 

}