using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

namespace UnityStarterProject
{
    public class QualityManager : Singleton<QualityManager>
    {
        public enum PostProcessingQuality
        {
            OFF,
            LOW,
            MEDIUM,
            HIGH
        }

        public enum FxAntiAliasingQuality
        {
            NONE,
            FXAA,
            SMAA,
            TXAA
        }

        public PostProcessingQuality postProcessingMode = PostProcessingQuality.HIGH;
        public FxAntiAliasingQuality antiAliasingQuality = FxAntiAliasingQuality.FXAA;

        public void SetQuality(int index)
        {
            QualitySettings.SetQualityLevel(index);
        }

        public void SetPixelLightCount(int count)
        {
            QualitySettings.pixelLightCount = count;
        }

        public void SetTextureQuality(int index)
        {
            QualitySettings.masterTextureLimit = index;
        }

        public void SetAnisotropicTextures(int index)
        {
            QualitySettings.anisotropicFiltering = (AnisotropicFiltering)index;
        }

        public void SetAntiAliasing(int level)
        {
            QualitySettings.antiAliasing = level;
        }

        public void SetSoftParticles(bool setting)
        {
            QualitySettings.softParticles = setting;
        }

        public void SetRealtimeReflectionProbes(bool setting)
        {
            QualitySettings.realtimeReflectionProbes = setting;
        }

        public void SetShadowMaskMode(int mode)
        {
            QualitySettings.shadowmaskMode = (ShadowmaskMode)mode;
        }

        public void SetShadowSetting(int mode)
        {
            QualitySettings.shadows = (ShadowQuality)mode;
        }

        public void SetShadowResolution(int mode)
        {
            QualitySettings.shadowResolution = (ShadowResolution)mode;
        }

        public void SetShadowDistance(float distance)
        {
            QualitySettings.shadowDistance = distance;
        }

        public void SetVsync(int mode)
        {
            QualitySettings.vSyncCount = mode;
        }

        public void SetPostProcessingQuality(int quality)
        {
            postProcessingMode = (PostProcessingQuality)quality;
        }

        public void SetFxAntiAliasingQuality(int quality)
        {
            antiAliasingQuality = (FxAntiAliasingQuality)quality;
        }
    }
}