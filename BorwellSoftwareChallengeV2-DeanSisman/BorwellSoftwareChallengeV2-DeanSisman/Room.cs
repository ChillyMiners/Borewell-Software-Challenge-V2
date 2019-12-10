using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwellSoftwareChallengeV2_DeanSisman
{
    /// <summary>
    /// Represents the room, holds data for the width, length, height, area, volume and paint required
    /// </summary>
    class Room
    {
        private float width;
        private float length;
        private float height;
        private float area;
        private float volume;
        private float paintReq;

        // Constructor, passes values for width, length, height and calls methods to calculate area, 
        // volume, paint required
        public Room(float w, float l, float h)
        {
            width = w;
            length = l;
            height = h;
            area = CalculateArea(w, l);
            volume = CalculateVolume(w, l, h);
            paintReq = CalculatePaintReq(w, l, h);
        }

        // Properties
        public float Area
        {
            get { return area; }
        }
        public float Volume
        {
            get { return volume; }
        }
        public float PaintReq
        {
            get { return paintReq; }
        }

        // Calculates the area, returns as float
        private float CalculateArea(float w, float l)
        {
            float a = w * l;
            return a;
        }

        // Calculates the volume, returns as float
        private float CalculateVolume(float w, float l, float h)
        {
            float v = w * l * h;
            return v;
        }

        // Calculates the paint required, returns as float
        private float CalculatePaintReq(float w, float l, float h)
        {
            float wallArea = (w * h * 2) + (l * h * 2);
            float metresSquaredPerLitre = 10;
            float pr = wallArea / metresSquaredPerLitre;
            return pr;
        }
    }
}


