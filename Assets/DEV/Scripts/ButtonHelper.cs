using GameEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHelper : MonoBehaviour
{
    [SerializeField] PlayerMovement controller;
    [SerializeField] ParticleHelper particleHelper;
    [SerializeField] Direction dir;
    public void OnButtonClicked()
    {
        //print($"{this.name} clicked");
        controller.SetDirection(dir);
        controller.SetClickBool(true);
        particleHelper.OnClicked(transform);
    }
    public void OnButtonClickEnded()
    {
        //print($"{this.name} click ended");
        controller.Stop();
        controller.SetClickBool(false);

    }
}
