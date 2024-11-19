using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Momos.Tools.DebugLog
{
    internal class DebugerConfigWindow : EditorWindow
    {
        [MenuItem("Tools/DebugerConfig")]
        private static void ShowWindow()
        {
            DebugerConfigWindow win = EditorWindow.GetWindow<DebugerConfigWindow>();
            win.titleContent = new GUIContent("DebugConfig");
            win.position = new Rect(200, 200, 800, 200);
            win.Show();
        }

        // 任何情况调用Loader属性而非本变量
        private DebugerConfigLoader loader;
        private DebugerConfigAsset config;
        private Dictionary<E_LogMaskShiftAmount, LogMaskBody> maskDic;

        private Vector2 sv;

        internal DebugerConfigLoader Loader 
        {
            get
            { 
                if(loader == null)
                    loader = new DebugerConfigLoader();
                return loader;
            }
        }
        private DebugerConfigAsset Config
        {
            get 
            {
                return config;
            }
        }
        private Dictionary<E_LogMaskShiftAmount, LogMaskBody> MaskDic
        {
            get
            {
                if (maskDic == null)
                    Config.GetMaskDic(out maskDic);
                return maskDic;
            }
        }

        private void SaveConfig()
        {
            Config.RefrushMaskFlag();
            EditorUtility.SetDirty(Config);
            AssetDatabase.SaveAssets();
            Config.GetMaskDic(out maskDic);
        }

        private void OnEnable()
        {
            Loader.TryLoad(ref config);
        }

        private void OnGUI()
        {
            if (config == null)
            {
                OnNotConfigGUI();
            }
            else
            {
                OnDrawConfigGUI();
            }
        }

        #region OnNotConfigGUI

        private void OnNotConfigGUI()
        { 
            GUILayout.Label($"未加载到一个{nameof(DebugerConfigAsset)}");

            GUILayout.BeginHorizontal();
            GUILayout.Label("检查任一Resources目录下是否存在");
            GUILayout.TextField(Loader.resourcePath + ".asset");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("或");
            if (GUILayout.Button("创建"))
            {
                string path = EditorUtility.SaveFilePanelInProject(
                    "创建DebugerConfigAsset",
                    "DebugerConfig",
                    "asset",
                    "1111");
                if (!string.IsNullOrEmpty(path))
                {
                    if (Loader.IsUsablePath(path) || 
                        EditorUtility.DisplayDialog("警告",
                            $"当前保存路径:{path} 没有指向{Loader.LocalFullPath} 不能被读取。 \n是否继续创建?",
                            "是","否")
                        )
                    {
                        DebugerConfigAsset asset = ScriptableObject.CreateInstance<DebugerConfigAsset>();
                        asset.Init();
                        // 通过编辑器API 根据数据创建一个数据资源文件
                        AssetDatabase.CreateAsset(asset, path);
                        // 保存创建的资源
                        AssetDatabase.SaveAssets();
                        // 刷新界面
                        AssetDatabase.Refresh();
                        // 保存到对应位置后 尝试加载
                        Loader.TryLoad(ref config);
                        EditorUtility.SetDirty(Config);
                        AssetDatabase.SaveAssets();
                    }
                }
            }
            GUILayout.EndHorizontal();
        }
        #endregion OnNotConfigGUI

        private void OnDrawConfigGUI()
        {
            DrawGUI_MaskFlagRow();
            DrawGUI_ContentMain();
        }

        // 第一行: 显示遮罩值
        private void DrawGUI_MaskFlagRow()
        {
            GUILayout.BeginHorizontal();

            GUILayout.Label("遮罩:");
            GUILayout.TextField($"{Config.maskFlag}");
            GUILayout.TextField($"{Convert.ToString(Config.maskFlag, 2).PadLeft(32, '0')}");
            if (GUILayout.Button("计算遮罩并保存"))
            {
                SaveConfig();
            }

            GUILayout.EndHorizontal();
        }

        // 第二行: 绘制主要内容
        private void DrawGUI_ContentMain()
        {
            GUI.Box(new Rect(4, 24, position.width - 8, 160), GUIContent.none);
            
            GUILayout.BeginArea(new Rect(8, 24, position.width - 16, 160)); // 1
            GUILayout.BeginHorizontal();    // 1.1

            GUILayout.BeginVertical();  // 1.1.1
            GUILayout.Label("左移枚举");
            GUILayout.Label("左移值");
            GUILayout.Label("启用");
            GUILayout.Label("前缀");
            GUILayout.Label("展示时间");
            GUILayout.Label("展示线程");
            GUILayout.Label("颜色");
            GUILayout.EndVertical();    // 1.1.1

            sv = GUILayout.BeginScrollView(sv); // 1.1.2
            GUILayout.BeginHorizontal();    // 1.1.2.1
            foreach (var kv in MaskDic)
            {
                GUILayout.BeginVertical();  // 1.1.2.1.n
                // 枚举名
                GUILayout.TextField(kv.Key.ToString());
                // 枚举值
                GUILayout.TextField(((int)kv.Key).ToString());
                if (kv.Value == null)
                {
                    if (GUILayout.Button("创建"))
                    {
                        Config.AddNewMask(kv.Key);
                        SaveConfig();
                    }
                }
                else
                {
                    kv.Value.isOpen = EditorGUILayout.Toggle(string.Empty, kv.Value.isOpen);
                    kv.Value.prefix = EditorGUILayout.TextField(kv.Value.prefix);
                    kv.Value.showTime = EditorGUILayout.Toggle(string.Empty, kv.Value.showTime);
                    kv.Value.showThreadID = EditorGUILayout.Toggle(string.Empty, kv.Value.showThreadID);
                    kv.Value.color = EditorGUILayout.ColorField(kv.Value.color);
                }
                GUILayout.EndVertical();    // 1.1.2.1.n
            }
            GUILayout.EndHorizontal();  // 1.1.2.1
            GUILayout.EndScrollView();  // 1.1.2

            GUILayout.EndHorizontal(); // 1.1
            GUILayout.EndArea(); // 1
        }
    }
}