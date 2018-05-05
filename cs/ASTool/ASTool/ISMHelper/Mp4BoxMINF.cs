﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ASTool.ISMHelper
{
    class Mp4BoxMINF : Mp4Box
    {
        static public Mp4BoxMINF CreateMINFBox(List<Mp4Box> listChild)
        {
           
            Mp4BoxMINF box = new Mp4BoxMINF();
            if (box != null)
            {
                int ChildLen = 0;
                if(listChild!=null)
                {
                    foreach (var c in listChild)
                        ChildLen += c.GetBoxLength();
                }
                box.Length = 8 + ChildLen ;
                box.Type = "minf";
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
