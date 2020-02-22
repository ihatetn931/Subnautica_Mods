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

        public SerializableColor(Color c)
        {
            r = c.r;
            g = c.g;
            b = c.b;
            a = c.a;
        }

        public static implicit operator SerializableColor(Color c)
        {
            return new SerializableColor(c);
        }

        public Color ToColor(bool value)
        {
            if(value)
            {
                return new Color(Config.rValue, Config.gValue, Config.bValue, a);
            }
            else
            {
                return new Color(r, g, b, a);
            }
        }
    }

}
