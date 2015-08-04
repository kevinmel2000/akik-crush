using UnityEngine;
using System.Collections;

public class ControllingAspectResolution : MonoBehaviour {

	void Start () {
        //set desired(diinginkan) aspect ratio.
        //hard-coded for 16.0f/9.0f
        float targetAspect = 600.0f / 1024.0f;

        //determine(menentukan) or get the game window's current aspect ratio
        float windowAspect = (float)Screen.width / (float)Screen.height;

        //catch ratio between windowAspect and targetAspect
        float scaleRatio = windowAspect / targetAspect;

        Camera camera = GetComponent<Camera>();

        if (scaleRatio < 1.0f)
        {
            //if scaled height is less than current height, add letterbox
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleRatio;
            rect.x = 0;
            rect.y = (1.0f - scaleRatio) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            //add pillarbox
            float scaleWidth = 1.0f / scaleRatio;

            Rect rect = camera.rect;

            rect.width = scaleRatio;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleRatio) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }

    // logic code from : http://gamedesigntheory.blogspot.ie/2010/09/controlling-aspect-ratio-in-unity.html
    // re-typewritter : Hisbullah_JarukStudio 
}