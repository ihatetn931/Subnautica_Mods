using System;
using UnityEngine;
//Thanks to randyKnapp
namespace BetterSeaglide
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
                return new Color32(Convert.ToByte(Menus.Config.rValue), Convert.ToByte(Menus.Config.gValue), Convert.ToByte(Menus.Config.bValue), 1);
            }
            else
            {
                return new Color(r, g, b, 1.000f);
            }
        }
    }

}
