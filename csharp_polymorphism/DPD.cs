using System;

public class DPD : AbstractClass
{
    public DPD() : base(){}
    public override uint Val
    {
        get
        {
            uint tmp = 0, x = 0, b1 = 0, b2 = 0, b3 = 0;
            string t = "";
            for(int i = 0; i < 3; i++)
            {
                x = (mRaw >> (i * 10)) & (uint)0x3ff;
                tmp = (x >> 3) & 1;
                if(tmp == 1) //not first case
                {
                    tmp = (x >> 1) & 3;
                    if( tmp == 3)//not cases 2,3, or 4
                    {
                        tmp = (x >> 5) & 3;
                        if( tmp == 0 )//case 5
                        {
                            //100c 100f 0ghi | gh c00f 111i
                            //      i           gh
                            b1 = (1 & x) | ((x >> 7) & 6); //0ghi
                            //      1           f
                            b2 = (1 << 7) | ((1<<4) & x); //100f
                            //      1           c
                            b3 = (1 << 11) | (((1 << 7) & x) << 1); //100c
                        }
                        else if (tmp == 1) // case 6
                        {
                            //100c 0def 100i | de c01f 111i
                            //      100i
                            b1 = (9 & x); //100i
                            //      f                   de
                            b2 = ((8<<1) & x) | ((x >> 3) & (6 << 4)); //0def
                            //          c                   //1
                            b3 = (8<<8) | ((x << 1) & (1 << 8)); //100c
                        }
                        else if (tmp == 2)// case 7
                        {
                            //0abc 100f 100i | ab c10f 111i
                            //      i           1
                            b1 = (1 & x) | ( 1 << 3);//100i
                            //      1           f
                            b2 = (1 << 7) | ( x & ( 1 << 4));//100f
                            //          abc
                            b3 = ((7 << 7) & x) << 1;//0abc
                        }
                        else // case 8
                        {
                            //100c 100f 100i | 00 c11f 111i
                            //      1           i
                            b1 = (1 << 3) | (1 & x); //100i
                            //      f               1  
                            b2 = ((1 << 4) & x) | (1 << 7); //100f
                            //          c                   1
                            b3 = (((1 << 7) & x) << 1) | ( 1 << 11); //100c
                        }
                    }
                    else //cases 2,3, or 4
                    {
                        if(tmp == 0)//case 2
                        {
                            //0abc 0def 100i | ab cdef 100i
                            //      100i
                            b1 = x & 9; // 100i
                            //      def
                            b2 = x & ( 7 << 4); //0def
                            //     abc 
                            b3 = (x << 1) & ( 7 << 8); //0abc
                        }
                        else if(tmp == 1) //case 3
                        {
                            //0abc 100f 0ghi | ab cghf 101i
                            //      i           gh
                            b1 = (1 & x) | ((x >> 4) & 6); //0ghi
                            //      1           f
                            b2 = (1 << 7) | ((1 << 4) & x); //100f
                            //      abc
                            b3 = (x & (7 << 7)) << 1; //0abc
                        }
                        else // case 4
                        {
                            //100c 0def 0ghi | gh cdef 110i
                            //      i            gh
                            b1 = (1 & x) | ((x >> 7) & 6); //0ghi
                            //      def
                            b2 = (7 << 4) & x; //0def
                            //      c                       1
                            b3 = ((x << 1) & (1 <<8)) | (1 << 11); //100c
                        }
                    }
                }
                else //first case
                {
                    //0abc 0def 0ghi | ab cdef 0ghi
                    //      ghi
                    b1 = 7 & x; //0ghi
                    //      def
                    b2 = (7 << 4) & x; //0def
                    //      abc 
                    b3 = (x & (7 << 7) << 1) ; //0abc
                }
                b2 = b2 >> 4;
                b3 = b3 >> 8;
                t = b3.ToString() + b2.ToString() + b1.ToString() +  t;
            }
            return Convert.ToUInt32(t);
        }
    }
}
