using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class WebcamEx : MonoBehaviour
{

    WebCamTexture _CamTex;
    private string _SavePath = "C:/WebcamSnaps/";
    int _CaptureCounter = 0;
    public RawImage rawimage;

    void Start()
    {
        
        _CamTex = new WebCamTexture();
        rawimage.texture = _CamTex;
        rawimage.material.mainTexture = _CamTex;
        _CamTex.Play();
        GetComponent<RectTransform>().sizeDelta = new Vector2(_CamTex.width,_CamTex.height);
        
       
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TakeSnapshot();
        }
    }
    void TakeSnapshot()
    {
        Texture2D snap = new Texture2D(_CamTex.width, _CamTex.height);
        snap.SetPixels(_CamTex.GetPixels());
        snap.Apply();

        System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
        ++_CaptureCounter;
    }
}


