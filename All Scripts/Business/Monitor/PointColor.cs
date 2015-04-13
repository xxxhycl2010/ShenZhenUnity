using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ShenZhen.Monitor
{
    
    public class PointColor 
    {

        public Color color { set; get; }

        public PointColor()
        {
            this.color = Color.white;
        }

        public static Color GetCorrespondColor(int index)
        {
            switch (index)
            { 
                case 0:
                    return Color.red;
                case 1:
                    return Color.green;
                case 2:
                    return Color.blue;
                case 3:
                    return Color.black;
                case 4:
                    return Color.cyan;
                case 5:
                    return Color.gray;
                case 6:
                    return Color.white;
                case 7:
                    return Color.yellow;
                default:
                    return Color.white;
            }
            
        }
    }
}


