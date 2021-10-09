﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoTool.Models;
using EvoTool.ZlibUnzlib;
using System.IO;
using System.Data;

namespace EvoTool.Controllers
{
    class GloveController
    {
        private static readonly string FILE_NAME = "/Glove.bin";
        private static readonly int BLOCK = 204;

        public GloveController()
        {
            GloveTable = new DataTable();
            GloveTable.Columns.Add("Index", typeof(int));
            GloveTable.Columns.Add("Name", typeof(string));
        }

        public MemoryStream MemoryGlove { get; set; }
        public BinaryReader ReadGlove { get; set; }
        public BinaryWriter WriteGlove { get; set; }
        public DataTable GloveTable { get; set; }

        private MemoryStream UnzlibFile(string patch, int bitRecognized)
        {
            MemoryStream memoryGlove = null;

            if (bitRecognized == 0)
            {
                byte[] file = File.ReadAllBytes(patch + FILE_NAME);
                byte[] ss1 = Unzlib.UnZlibFilePC(file);
                memoryGlove = new MemoryStream(ss1);
            }
            //else if (bitRecognized == 1 || bitRecognized == 2)
            //{
            //    // console file
            //}

            return memoryGlove;
        }

        public int Load(string patch, int bitRecognized)
        {
            MemoryGlove = UnzlibFile(patch, bitRecognized);

            int gloveNumber = (int)MemoryGlove.Length / BLOCK;

            if (gloveNumber == 0)
                return 0;

            string gloveName;
            try
            {
                ReadGlove = new BinaryReader(MemoryGlove);
                long START = 104; // ball name offset

                for (int i = 0; i < gloveNumber; i++)
                {
                    MemoryGlove.Seek(START, SeekOrigin.Begin);
                    gloveName = Encoding.UTF8.GetString(ReadGlove.ReadBytes(100)).TrimEnd('\0');

                    GloveTable.Rows.Add(i, gloveName);

                    START += BLOCK;
                }
                WriteGlove = new BinaryWriter(MemoryGlove);
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public Glove LoadGlove(int index)
        {
            Glove glove;

            UInt16 gloveId;
            byte order;
            string gloveName;
            try
            {
                ReadGlove.BaseStream.Position = index * BLOCK + 104;
                gloveName = Encoding.UTF8.GetString(ReadGlove.ReadBytes(100)).TrimEnd('\0');

                ReadGlove.BaseStream.Position = index * BLOCK;
                gloveId = ReadGlove.ReadUInt16();

                ReadGlove.BaseStream.Position = index * BLOCK + 2;
                order = ReadGlove.ReadByte();

                glove = new Glove(gloveId);
                glove.Name = gloveName;
                glove.Order = order;
            }
            catch (Exception)
            {
                return null;
            }

            return glove;
        }

        public int LoadGloveById(UInt16 gloveId)
        {
            int gloveNumber = (int)MemoryGlove.Length / BLOCK;

            ReadGlove.BaseStream.Position = 0;
            for (int i = 0; i < gloveNumber; i++)
            {
                if (gloveId == ReadGlove.ReadUInt16())
                    return 1;

                ReadGlove.BaseStream.Position += BLOCK - 2;
            }

            return 0;
        }

        public int ApplyGlove(int index, Glove glove)
        {
            try
            {
                int offsetBase = BLOCK * index;
                WriteGlove.BaseStream.Position = offsetBase;
                byte zero = 0;

                UInt16 id = glove.Id;
                byte order = glove.Order;
                string gloveName = glove.Name;
                WriteGlove.Write(id);
                WriteGlove.Write(order);
                for (int i = 0; i <= 100; i++)
                {
                    WriteGlove.Write(zero);
                }

                WriteGlove.BaseStream.Position = offsetBase + 104;
                WriteGlove.Write(gloveName.ToCharArray());
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public int Save(string patch, int bitRecognized)
        {
            try
            {
                if (bitRecognized == 0)
                {
                    byte[] ss13 = Zlib.ZlibFilePC(MemoryGlove.ToArray());
                    File.WriteAllBytes(patch + FILE_NAME, ss13);
                }
                //else if (bitRecognized == 1)
                //{
                //    // xbox?
                //}
                //else if (bitRecognized == 2)
                //{
                //    // ps3?
                //}
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public void CloseMemory()
        {
            if (MemoryGlove != null)
            {
                MemoryGlove.Close();
                ReadGlove.Close();
                WriteGlove.Close();
            }
        }

    }
}
