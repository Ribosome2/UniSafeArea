using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Update is called once per frame
    void Update()
    {
        var screenWidth = UnityEngine.Device.Screen.width;
        var screenHeight = UnityEngine.Device.Screen.height;
        var safeArea = UnityEngine.Device.Screen.safeArea;

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
