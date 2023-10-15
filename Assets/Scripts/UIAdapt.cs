using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAdapt : MonoBehaviour
{
    public RectTransform targetRoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [Range(-2,2)]
    public float minY;
    [Range(-2,2)]
    public float maxY=1;
    public float referenceWidth = 600;
    public float referenceHeight = 800;
    public CanvasScaler canvasScaler;
    // Update is called once per frame
    void Update()
    {
        var screenWidth = UnityEngine.Device.Screen.width;
        var screenHeight = UnityEngine.Device.Screen.height;
        var safeArea = UnityEngine.Device.Screen.safeArea;

        float screenRatio = (float)screenWidth / screenHeight;
        float targetRatio = referenceWidth / referenceHeight;
        if(screenRatio<targetRatio)
        {
            //屏幕比例小于目标比例，以宽度为基准
            canvasScaler.matchWidthOrHeight = 0;
        }
        else
        {
            //屏幕比例大于目标比例，以高度为基准
            canvasScaler.matchWidthOrHeight = 1;
        }
        referenceWidth = canvasScaler.referenceResolution.x;
        referenceHeight = canvasScaler.referenceResolution.y;
        
        targetRoot.anchorMin = new Vector2(0, minY);
        targetRoot.anchorMax = new Vector2(1, maxY);
        var baseRatio =referenceHeight/ referenceWidth;
        var maxHeight = screenWidth * baseRatio;
        var emptyHeight = screenHeight - maxHeight;
        var emptyHeightRatio = emptyHeight / screenHeight*0.5f;
        minY = emptyHeightRatio;
        maxY =1- emptyHeightRatio;
    }
}
