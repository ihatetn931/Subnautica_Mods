using System;
using UnityEngine;

namespace BetterFlashLightBZ
{
    [Serializable]
    public class SerializableColor
    {
        public float r = 0.996f;
        public float g = 0.942f;
        public float b = 0.819f;
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
                return new Color(ConfigMenu.rValue, ConfigMenu.gValue, ConfigMenu.bValue, a);
            }
            else
            {
                return new Color(r, g, b, a);
            }
        }
    }

}
