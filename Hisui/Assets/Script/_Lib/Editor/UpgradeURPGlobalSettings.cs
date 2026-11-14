//using UnityEditor;
//using UnityEngine;
//using UnityEngine.Rendering;
//using UnityEngine.Rendering.Universal;

//public static class UpgradeURPGlobalSettings
//{
//    [MenuItem("Tools/URP/Upgrade Global Settings")]
//    static void Upgrade()
//    {
//        var settings =
//            GraphicsSettings.GetSettingsForRenderPipeline<
//                UniversalRenderPipeline>() as
//            UniversalRenderPipelineGlobalSettings;

//        if (settings == null)
//        {
//            Debug.LogError("URP Global Settings not found.");
//            return;
//        }

//        UniversalRenderPipelineGlobalSettings.UpgradeAsset(
//            settings.GetEntityId());

//        AssetDatabase.SaveAssetIfDirty(settings);

//        Debug.Log("URP Global Settings upgraded.");
//    }
//}