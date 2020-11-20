using System;
using UnityEngine;
//Thanks to randyKnapp
namespace BetterSeaglideBZ
{
    [Serializable]
    public class SerializableColor
    {
        public float r = 0.016f;
        public float g = 1.000f;
        public float b = 1.000f;
        public float a = 1;

        public float sgR = 0.016f;
        public float sgG = 1.000f;
        public float sgB = 1.000f;
        public float sgA = 1.000f;

        public float mapr = 0.226f;
        public float mapg = 0.567f;
        public float mapb = 0.853f;
        public float mapa = 1.0f;

        public SerializableColor(Color c)
        {
            r = c.r;
            g = c.g;
            b = c.b;
            a = c.a;
            mapr = c.r;
            mapg = c.g;
            mapb = c.b;
            mapa = c.a;
            sgR = c.a;
            sgG = c.g;
            sgB = c.b;
            sgA = c.a;
        }


        public static implicit operator SerializableColor(Color c)
        {
            return new SerializableColor(c);
        }

        public Color LightToColor(bool value)
        {
            if(value)
            {
                return new Color(MainPatch.rValue, MainPatch.gValue, MainPatch.bValue,1);
            }
            else
            {
                return new Color(r, g, b, 1);
            }
        }
        public Color ColorToColor(bool value)
        {
            if (value)
            {
                return new Color(MainPatch.seagliderValue, MainPatch.seaglidegValue, MainPatch.seaglidebValue, 1);
            }
            else
            {
                return new Color(sgR, sgG, sgB, sgA);
            }
        }
    }

}
