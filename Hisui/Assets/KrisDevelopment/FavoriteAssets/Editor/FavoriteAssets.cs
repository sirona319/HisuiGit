using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace KrisDevelopment.KrisFavoriteAssets
{
    public class FavoriteAssets : EditorWindow
    {
        [System.Serializable]
        public class DataWrapper
        {
            public List<AssetData> assets = new List<AssetData>();
        }

        [System.Serializable]
        public class AssetData
        {
            public string guid;
            public string path;
            public string name;
            public string type;
        }

        private static string GetPrefix() { return Application.productName + "_KFA_"; }
        
		[SerializeField]
        DataWrapper _assetsData = null;
       DataWrapper assetsData
        {
            get
            {
                if(_assetsData == null){
                    LoadData();
                }
                
                return _assetsData;
            }
        }

		private Vector2 scrollView = Vector2.zero;

        [MenuItem("Window/Kris Development/Favorite Assets")]
        public static void ShowWindow ()
        {
            GetWindow<FavoriteAssets>("★ Fav. Assets");
        }

        public void OnGUI () 
        {
            GUILayout.BeginVertical(EditorStyles.helpBox);
            if(GUILayout.Button("Pin Selected Assets", EditorStyles.miniButton)){
                foreach(string assetGUID in Selection.assetGUIDs){
                    AssetData assetData = new AssetData();
                    assetData.guid  = assetGUID;
                    assetData.path = AssetDatabase.GUIDToAssetPath(assetGUID);
                    Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetData.path);
                    assetData.name = asset.name;
                    assetData.type = asset.GetType().ToString();
                    _assetsData.assets.Add(assetData);
                }
                SaveData();
            }
            GUILayout.EndVertical();

            GUILayout.BeginHorizontal(EditorStyles.toolbar);
            {
                GUILayout.Label("Pinned Assets:");
                if(GUILayout.Button("▼ Sort Assets", EditorStyles.toolbarButton)){
                    _assetsData.assets.Sort(AssetDataComparer);
                }
            }
			GUILayout.EndHorizontal();

            scrollView = GUILayout.BeginScrollView(scrollView);
            foreach(AssetData assetData in assetsData.assets) {
                GUILayout.BeginHorizontal();

                if(GUILayout.Button(new GUIContent("Open", "Open file with default app"), GUILayout.ExpandWidth(false))){
                    if(!Path.GetExtension(assetData.path).Equals(".unity")){
                        EditorUtility.OpenWithDefaultApp(assetData.path);
                    }else{
                        UnityEditor.SceneManagement.EditorSceneManager.OpenScene(assetData.path, UnityEditor.SceneManagement.OpenSceneMode.Single);
                    }
                }

                if(GUILayout.Button(new GUIContent("Ping", "Highlight asset on Project panel"), GUILayout.ExpandWidth(false))){
                    EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<Object>(assetData.path));
                }

                if(GUILayout.Button(new GUIContent(" " + assetData.name, AssetDatabase.GetCachedIcon(assetData.path)), GUILayout.Height(18))){
			        var asset = AssetDatabase.LoadAssetAtPath<Object>(assetData.path);
                    EditorGUIUtility.PingObject(asset);
                    Selection.activeObject = asset;
                }

                if(GUILayout.Button(new GUIContent("X", "Un-pin"), GUILayout.ExpandWidth(false))){
                    RemovePin(assetData);
                    break;
                }

                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
        }

        private void SaveData ()
        {
            string key = GetPrefix() + "pinned";
            string json = JsonUtility.ToJson(assetsData);
            EditorPrefs.SetString(key, json);
        }

        private void LoadData ()
        {
            _assetsData = new DataWrapper();

            string key = GetPrefix() + "pinned";
            if(EditorPrefs.HasKey(key)){
                string json = EditorPrefs.GetString(key);
                _assetsData = JsonUtility.FromJson<DataWrapper>(json);
            }
        }

        private void RemovePin (AssetData assetData)
        {
            _assetsData.assets.Remove(assetData);
            SaveData();
        }

        private int AssetDataComparer (AssetData left, AssetData right)
        {
            return left.type.CompareTo(right.type);
        }
    }
}
