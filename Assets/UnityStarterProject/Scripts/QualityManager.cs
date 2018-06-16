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
            if (!PlayerPrefs.HasKey(antiAliasingPref))
            {
                PlayerPrefs.SetInt(antiAliasingPref, (int)antiAliasingQuality);
            }

            if (!PlayerPrefs.HasKey(postProcessPref))
            {
                PlayerPrefs.SetInt(postProcessPref, (int)postProcessingMode);
            }

            postProcessingMode = (PostProcessingQuality)PlayerPrefs.GetInt(postProcessPref);
            antiAliasingQuality = (FxAntiAliasingQuality)PlayerPrefs.GetInt(antiAliasingPref);
        }

        public void ResetSettings()
        {
            SetQuality(3);
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
            QualitySettings.SetQualityLevel(index, true);
            SetVsync(vsync);

            // Set AA and PostProcessing quality
            switch (index)
            {
                case 0:     // very low
                case 1:     // low
                    SetPostProcessingQuality(0);
                    SetAntiAliasing(0);
                    break;
                case 2:     // medium
                    SetPostProcessingQuality(1);
                    SetAntiAliasing(1);
                    break;
                case 3:     // high
                    SetPostProcessingQuality(2);
                    SetAntiAliasing(1);
                    break;
                case 4:     // very high
                    SetPostProcessingQuality(2);
                    SetAntiAliasing(1);
                    break;
                case 5:     // ultra
                    SetPostProcessingQuality(3);
                    SetAntiAliasing(3);
                    break;
            }

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
            if (!PlayerPrefs.HasKey(antiAliasingPref))
            {
                PlayerPrefs.SetInt(antiAliasingPref, (int)antiAliasingQuality);
            }

            return antiAliasingQuality;
        }

        public void SetSoftParticles(bool setting)
        {
            QualitySettings.softParticles = setting;
        }

        public bool GetSoftParticles()
        {
            return QualitySettings.softParticles;
        }

        public void SetRealtimeReflectionProbes(bool setting)
        {
            QualitySettings.realtimeReflectionProbes = setting;
        }

        public void SetShadowMaskMode(int mode)
        {
            QualitySettings.shadowmaskMode = (ShadowmaskMode)mode;
        }

        public int GetShadowMaskMode()
        {
            return (int)QualitySettings.shadowmaskMode;
        }

        public void SetShadowSetting(int mode)
        {
            QualitySettings.shadows = (ShadowQuality)mode;
        }

        public void SetShadowResolution(int mode)
        {
            QualitySettings.shadowResolution = (ShadowResolution)mode;
        }

        public int GetShadowResolution()
        {
            return (int)QualitySettings.shadowResolution;
        }

        public void SetShadowDistance(float distance)
        {
            QualitySettings.shadowDistance = distance;
        }

        public float GetShadowDistance()
        {
            return QualitySettings.shadowDistance;
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
            if (!PlayerPrefs.HasKey(postProcessPref))
            {
                PlayerPrefs.SetInt(postProcessPref, (int)postProcessingMode);
            }

            return postProcessingMode;
        }

        public void SetFxAntiAliasingQuality(int quality)
        {
            antiAliasingQuality = (FxAntiAliasingQuality)quality;
        }
    }
}