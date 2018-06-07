using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace UnityStarterProject
{
    [ExecuteInEditMode]
    public class PostProcessingManager : MonoBehaviour
    {
        // Assumes low to high
        public List<PostProcessVolume> Profiles = new List<PostProcessVolume>();

        private QualityManager.PostProcessingQuality lastQuality;
        private QualityManager.FxAntiAliasingQuality lastAaQuality;
        private PostProcessLayer postProcessingLayer;

        private void Awake()
        {
            postProcessingLayer = GetComponent<PostProcessLayer>();
        }

        private void Start()
        {
            UpdateQualities();
        }

        private void Update()
        {
            QualityManager.PostProcessingQuality mode = QualityManager.Instance.postProcessingMode;
            QualityManager.FxAntiAliasingQuality aa = QualityManager.Instance.antiAliasingQuality;

            if (mode != lastQuality)
            {
                UpdateQuality(mode);
            }

            if (aa != lastAaQuality)
            {
                UpdateAa(aa);
            }

            lastQuality = mode;
            lastAaQuality = aa;
        }

        private void UpdateAa(QualityManager.FxAntiAliasingQuality aa)
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

        private void UpdateQuality(QualityManager.PostProcessingQuality mode)
        {
            if ((int)mode - 1 >= 0)
            {
                foreach (PostProcessVolume profile in Profiles)
                {
                    profile.enabled = false;
                }

                Profiles[(int)mode - 1].enabled = true;
            }
            else if ((int)mode - 1 < 0)
            {
                foreach (PostProcessVolume profile in Profiles)
                {
                    profile.enabled = false;
                }

                GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.None;
            }
        }

        public void UpdateQualities()
        {
            QualityManager.PostProcessingQuality mode = QualityManager.Instance.postProcessingMode;
            QualityManager.FxAntiAliasingQuality aa = QualityManager.Instance.antiAliasingQuality;
            UpdateAa(aa);
            UpdateQuality(mode);
        }
    }
}