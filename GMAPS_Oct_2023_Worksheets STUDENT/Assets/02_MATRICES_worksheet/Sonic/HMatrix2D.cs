using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        setIdentity();
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[y, x] = (x == y) ? 1 : 0;
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        // Second row
        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        // Third row
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = left.Entries[y, x] + right.Entries[y, x];
            }
        }

        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = left.Entries[y, x] - right.Entries[y, x];
            }
        }

        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = left.Entries[y, x] * scalar;
            }
        }

        return result;
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        HVector2D result = new HVector2D();

        for (int row = 0; row < 3; row++)
        {
            float sum = 0;
            for (int col = 0; col < 3; col++)
            {
                sum += left.Entries[row, col] * ((col == 0) ? right.x : (col == 1) ? right.y : right.h);
            }

            if (row == 0)
                result.x = sum;
            else if (row == 1)
                result.y = sum;
            else
                result.h = sum;
        }

        return result;
    }


    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                float sum = 0;
                for (int k = 0; k < 3; k++)
                {
                    sum += left.Entries[row, k] * right.Entries[k, col];
                }
                result.Entries[row, col] = sum;
            }
        }

        return result;
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (left.Entries[y, x] != right.Entries[y, x])
                    return false;
            }
        }
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        return !(left == right);
    }

    /*public override bool Equals(object obj)
    {
        // your code here
    }

    public override int GetHashCode()
    {
        // your code here
    }

    public HMatrix2D transpose()
    {
    return // your code here
    }

    public float getDeterminant()
    {
    return // your code here
    }*/

    public void setIdentity()
    {
        /*for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (x == y)
                {
                    Entries[y, x] = 1;
                }
                else
                {
                    Entries[y, x] = 0;
                }
            }
        }*/

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[y, x] = (x == y) ? 1 : 0;
            }
        }
    }

    public void setTranslationMat(float transX, float transY)
    {
        setIdentity();

        Entries[0, 2] = transX;
        Entries[1, 2] = transY;
    }

    public void setRotationMat(float rotDeg)
    {
        setIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);

        Entries[0, 0] = cos;
        Entries[0, 1] = -sin;
        Entries[1, 0] = sin;
        Entries[1, 1] = cos;
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        setIdentity();

        Entries[0, 0] = scaleX;
        Entries[1, 1] = scaleY;
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}