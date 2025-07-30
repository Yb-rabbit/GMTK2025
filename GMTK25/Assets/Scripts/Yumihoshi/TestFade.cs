// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/07/30 11:59
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using QFramework;
using UnityEngine;

namespace Yumihoshi
{
    public class TestFade : MonoBehaviour
    {
        private void OnGUI()
        {
            IMGUIHelper.SetDesignResolution(640, 360);

            if (GUILayout.Button("FadeIn"))
            {
                ActionKit.ScreenTransition
                    .FadeIn()
                    .Start(this);
            }

            if (GUILayout.Button("FadeOut"))
            {
                ActionKit.ScreenTransition
                    .FadeOut()
                    .Start(this);
            }

            if (GUILayout.Button("FadeInOut"))
            {
                ActionKit.ScreenTransition
                    .FadeInOut()
                    .OnInFinish(() => { Debug.Log("load scene here"); })
                    .Start(this);
            }

            if (GUILayout.Button("FadeIn White"))
            {
                ActionKit.ScreenTransition
                    .FadeIn()
                    .Color(Color.white)
                    .Start(this);
            }

            if (GUILayout.Button("FadeOut Red"))
            {
                ActionKit.ScreenTransition
                    .FadeOut()
                    .Color(Color.red)
                    .Start(this);
            }

            if (GUILayout.Button("FadeInOut 0.5s in green out blue"))
            {
                ActionKit.ScreenTransition
                    .FadeInOut()
                    .In(fadeIn => fadeIn
                        .Duration(0.5f)
                        .Color(Color.green))
                    .Out(fadeOut => fadeOut.Duration(0.5f)
                        .Color(Color.blue))
                    .Start(this);
            }
        }
    }
}
