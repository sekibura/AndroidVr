using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenTargetScript : MonoBehaviour
{


    [Header("Images Hand etc")]
    [SerializeField]
    private GameObject _handImage;
    [SerializeField]
    private GameObject _handImageVR;
    [SerializeField]
    private GameObject _rectangle;
    [SerializeField]
    private GameObject _rectangleVR;

    private void Start()
    {
        if (SetupInitialization.instance.IsVR)
        {
            _rectangleVR.SetActive(true);
            _handImageVR.SetActive(false);

            _rectangle.SetActive(false);
            _handImage.SetActive(false);
        }
        else
        {
            _rectangleVR.SetActive(false);
            _handImageVR.SetActive(false);

            _rectangle.SetActive(true);
            _handImage.SetActive(false);
        }
    }

    // меняет состояние прицела
    public void ShowHand(bool state)
    {

        if (SetupInitialization.instance.IsVR)
        {
            _rectangleVR.SetActive(!state);
            _handImageVR.SetActive(state);


        }
        else
        {
            _rectangle.SetActive(!state);
            _handImage.SetActive(state);
        }

    }

}
