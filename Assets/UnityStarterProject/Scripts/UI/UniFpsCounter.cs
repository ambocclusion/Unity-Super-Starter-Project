using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ~  Fps counter for unity  ~
/// Brief : Calculate the FPS and display it on the screen 
/// HowTo : Create empty object at initial scene and attach this script!!!
/// </summary>
public class UniFpsCounter : MonoBehaviour
{
    public Text textObject;

    // for fps calculation.
    private int frameCount;
    private float elapsedTime;
    private double frameRate;
    private float deltaTime;
    private float lastTime;

    /// <summary>
    /// Initialization
    /// </summary>
    private void Awake()
    {
        textObject.enabled = false;
    }

    /// <summary>
    /// Monitor changes in resolution and calcurate FPS
    /// </summary>
    private void Update()
    {
        deltaTime = Time.realtimeSinceStartup - lastTime;
        if (Input.GetKeyDown(KeyCode.F9))
        {
            textObject.enabled = !textObject.enabled;
            Input.ResetInputAxes();
        }

        // FPS calculation
        frameCount++;
        elapsedTime += deltaTime;
        if (elapsedTime > 0.5f)
        {
            frameRate = System.Math.Round(frameCount / elapsedTime, 1, System.MidpointRounding.AwayFromZero);
            frameCount = 0;
            elapsedTime = 0;
            textObject.text = frameRate.ToString() + " FPS\n" + (deltaTime * 1000f).ToString("F2") + "ms";
        }

        lastTime = Time.realtimeSinceStartup;
    }

}