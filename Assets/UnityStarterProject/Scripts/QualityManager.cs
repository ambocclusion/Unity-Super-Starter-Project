using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

namespace UnityStarterProject
{
    public class QualityManager : Singleton<QualityManager>
    {
        public const string postProcessPref = "postProcessingMode";
        public const string antiAliasingPref = "antiAliasingQuality";

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

        private void Start()
        {
            postProcessingMode = (PostProcessingQuality)PlayerPrefs.GetInt(postProcessPref);
            antiAliasingQuality = (FxAntiAliasingQuality)PlayerPrefs.GetInt(antiAliasingPref);
        }

        public void SetResolution(Resolution resolutionToSet)
        {
            Screen.SetResolution(resolutionToSet.width, resolutionToSet.height, Screen.fullScreenMode, resolutionToSet.refreshRate);
        }

        public Resolution GetCurrentResolution()
        {
            Resolution resolution = new Resolution
            {
                width = Screen.width,
                height = Screen.height,
                refreshRate = Screen.currentResolution.refreshRate
            };

            return resolution;
        }

        public void SetFullscreen(FullScreenMode mode)
        {
            Resolution resolution = GetCurrentResolution();
            Screen.SetResolution(resolution.width, resolution.height, mode, resolution.refreshRate);
        }

        public FullScreenMode GetCurrentFullscreen()
        {
            return Screen.fullScreenMode;
        }

        public void SetQuality(int index)
        {
            int vsync = GetVsync();
            QualitySettings.SetQualityLevel(index);
            SetVsync(vsync);
        }

        public int GetQuality()
        {
            return QualitySettings.GetQualityLevel();
        }

        public void SetPixelLightCount(int count)
        {
            QualitySettings.pixelLightCount = count;
        }

        public int GetPixelLightCount()
        {
            return QualitySettings.pixelLightCount;
        }

        public void SetTextureQuality(int index)
        {
            QualitySettings.masterTextureLimit = index;
        }

        public int GetTextureQuality()
        {
            return QualitySettings.masterTextureLimit;
        }

        public void SetAnisotropicTextures(int index)
        {
            QualitySettings.anisotropicFiltering = (AnisotropicFiltering)index;
        }

        public int GetAnisotropicFiltering()
        {
            return (int)QualitySettings.anisotropicFiltering;
        }

        public void SetAntiAliasing(int level)
        {
            antiAliasingQuality = (FxAntiAliasingQuality)level;
            PlayerPrefs.SetInt(antiAliasingPref, level);
        }

        public FxAntiAliasingQuality GetAntiAliasing()
        {
            return antiAliasingQuality;
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

        public int GetVsync()
        {
            return QualitySettings.vSyncCount;
        }

        public void SetPostProcessingQuality(int quality)
        {
            postProcessingMode = (PostProcessingQuality)quality;
            PlayerPrefs.SetInt(postProcessPref, quality);
        }

        public PostProcessingQuality GetPostProcessingQuality()
        {
            return postProcessingMode;
        }

        public void SetFxAntiAliasingQuality(int quality)
        {
            antiAliasingQuality = (FxAntiAliasingQuality)quality;
        }
    }
}