﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ASTool.ISMHelper
{
    class Mp4BoxMDIA : Mp4Box
    {
        static public Mp4BoxMDIA CreateMDIABox(List<Mp4Box> listChild)
        {
           
            Mp4BoxMDIA box = new Mp4BoxMDIA();
            if (box != null)
            {
                int ChildLen = 0;
                if(listChild!=null)
                {
                    foreach (var c in listChild)
                        ChildLen += c.GetBoxLength();
                }
                box.Length = 8 + ChildLen ;
                box.Type = "mdia";
                byte[] Buffer = new byte[box.Length - 8 ];
                if (Buffer != null)
                {
                    int offset = 0;
                    if (listChild != null)
                    {
                        foreach (var c in listChild)
                        {
                            WriteMp4BoxData(Buffer, offset, c.GetBoxBytes());
                            offset += c.GetBoxLength();
                        }
                    }

                    box.Data = Buffer;
                    return box;
                }
            }
            return null;
        }
    }
}
