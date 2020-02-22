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
        }


        public static implicit operator SerializableColor(Color c)
        {
            return new SerializableColor(c);
        }

        public Color LightToColor(bool value)
        {
            if(value)
            {
                return new Color32(Convert.ToByte(Config.rValue),Convert.ToByte(Config.gValue), Convert.ToByte(Config.bValue),1);
            }
            else
            {
                return new Color(r, g, b, 1.0f);
            }
        }
        public Color MapToColor(bool value)
        {
            if (value)
            {
                return new Color32(Convert.ToByte(Config.maprValue), Convert.ToByte(Config.mapgValue), Convert.ToByte(Config.mapbValue), Convert.ToByte(Config.mapAlpha));
            }
            else
            {
                return new Color(mapr, mapg, mapb, 1.0f);
            }
        }
    }

}
