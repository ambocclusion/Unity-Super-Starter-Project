using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace UnityStarterProject
{
    public class PostProcessingManager : MonoBehaviour
    {
        // Assumes low to high
        public List<PostProcessVolume> Profiles = new List<PostProcessVolume>();

        private QualityManager.PostProcessingQuality lastQuality = QualityManager.PostProcessingQuality.OFF;
        private QualityManager.FxAntiAliasingQuality lastAaQuality;
        private PostProcessLayer postProcessingLayer;

        private void Awake()
        {
            postProcessingLayer = GetComponent<PostProcessLayer>();
        }

        private void Update()
        {
            QualityManager.PostProcessingQuality mode = QualityManager.Instance.postProcessingMode;
            QualityManager.FxAntiAliasingQuality aa = QualityManager.Instance.antiAliasingQuality;

            if (mode != lastQuality && (int)mode - 1 >= 0)
            {
                foreach(PostProcessVolume profile in Profiles)
                {
                    profile.enabled = false;
                }

                Profiles[(int)mode - 1].enabled = true;
            }
            else if (mode != lastQuality && (int)mode - 1 < 0)
            {
                foreach (PostProcessVolume profile in Profiles)
                {
                    profile.enabled = false;
                }

                GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.None;
            }

            if (aa != lastAaQuality)
            {
                switch (aa)
                {
                    case QualityManager.FxAntiAliasingQuality.NONE:
                        postProcessingLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
                        break;
                    case QualityManager.FxAntiAliasingQuality.FXAA:
                        postProcessingLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
                        break;
                    case QualityManager.FxAntiAliasingQuality.SMAA:
                        postProcessingLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
                        break;
                    case QualityManager.FxAntiAliasingQuality.TXAA:
                        postProcessingLayer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
                        break;
                }
            }

            lastQuality = mode;
            lastAaQuality = aa;
        }
    }
}