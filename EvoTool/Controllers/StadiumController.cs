﻿using EvoTool.Models;
using EvoTool.ZlibUnzlib;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Controllers
{
    public class StadiumController
    {
        private static readonly string FILE_NAME = "/Stadium.bin";
        private static readonly int BLOCK = 1096;

        public StadiumController()
        {
            StadiumTable = new DataTable();
            StadiumTable.Columns.Add("Index", typeof(int));
            StadiumTable.Columns.Add("Name", typeof(string));
        }

        private MemoryStream MemoryStadium { get; set; }
        private BinaryReader ReadStadium { get; set; }
        private BinaryWriter WriteStadium { get; set; }
        public DataTable StadiumTable { get; set; }

        private MemoryStream UnzlibFile(string patch)
        {
            MemoryStream memoryStadium = null;

            byte[] file = File.ReadAllBytes(patch + FILE_NAME);
            byte[] ss1 = Unzlib.UnZlibFilePC(file);
            memoryStadium = new MemoryStream(ss1);

            return memoryStadium;
        }

        public int Load(string patch)
        {
            MemoryStadium = UnzlibFile(patch);

            int stadiumNumber = (int)MemoryStadium.Length / BLOCK;

            if (stadiumNumber == 0)
                return 0;

            string stadiumName;
            try
            {
                ReadStadium = new BinaryReader(MemoryStadium);
                long START = -364; // stadium name offset

                for (int i = 0; i < stadiumNumber; i++)
                {
                    START += BLOCK;
                    MemoryStadium.Seek(START, SeekOrigin.Begin);
                    stadiumName = Encoding.UTF8.GetString(ReadStadium.ReadBytes(110)).TrimEnd('\0');

                    StadiumTable.Rows.Add(i, stadiumName);
                }
                WriteStadium = new BinaryWriter(MemoryStadium);
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public Stadium LoadStadium(int index)
        {
            Stadium stadium;

            ushort stadiumID;
            string stadiumName;
            string stadiumJapName;
            uint country;
            uint capacity;
            try
            {
                ReadStadium.BaseStream.Position = index * BLOCK;
                uint aux1 = ReadStadium.ReadUInt32();
                //na = valore32 >> 30;
                //licensed = aux1 << 2;
                //licensed = licensed >> 31;
                country = aux1 << 3;
                country = country >> 23;
                capacity = aux1 << 12;
                capacity = capacity >> 12;

                ReadStadium.BaseStream.Position = index * BLOCK + 4;
                stadiumID = ReadStadium.ReadUInt16();

                ReadStadium.BaseStream.Position = index * BLOCK + 189;
                stadiumJapName = Encoding.UTF8.GetString(ReadStadium.ReadBytes(110)).TrimEnd('\0');

                ReadStadium.BaseStream.Position = index * BLOCK + 732;
                stadiumName = Encoding.UTF8.GetString(ReadStadium.ReadBytes(110)).TrimEnd('\0');



                stadium = new Stadium(stadiumID);
                stadium.Name = stadiumName;
                stadium.JapaneseName = stadiumJapName;
                stadium.Country = (ushort)country;
                stadium.Capacity = (ushort)capacity;
            }
            catch (Exception)
            {
                return null;
            }

            return stadium;
        }

        public int LoadStadiumByID(ushort stadiumID)
        {
            int ballNumber = (int)MemoryStadium.Length / BLOCK;

            ReadStadium.BaseStream.Position = 4;
            for (int i = 0; i < ballNumber; i++)
            {
                if (stadiumID == ReadStadium.ReadUInt16())
                    return i;

                ReadStadium.BaseStream.Position += BLOCK - 2;
            }

            return -1;
        }

        public int ApplyStadium(int index, Stadium stadium)
        {
            try
            {
                int offsetBase = BLOCK * index;
                WriteStadium.BaseStream.Position = offsetBase;
                byte zero = 0;

                ReadStadium.BaseStream.Position = index * BLOCK;
                uint aux1 = ReadStadium.ReadUInt32();
                aux1 = aux1 >> 28;
                aux1 = aux1 << 28;
                aux1 = aux1 | (uint) (stadium.Country << 20);
                aux1 = aux1 | stadium.Capacity;
                WriteStadium.BaseStream.Position = offsetBase;
                WriteStadium.Write(aux1);

                WriteStadium.BaseStream.Position = offsetBase + 4;
                WriteStadium.Write(stadium.ID);

                WriteStadium.BaseStream.Position = offsetBase + 189;
                for (int i = 0; i <= 110; i++)
                {
                    WriteStadium.Write(zero);
                }

                WriteStadium.BaseStream.Position = offsetBase + 189;
                WriteStadium.Write(stadium.JapaneseName.ToCharArray());

                WriteStadium.BaseStream.Position = offsetBase + 732;
                for (int i = 0; i <= 110; i++)
                {
                    WriteStadium.Write(zero);
                }

                WriteStadium.BaseStream.Position = offsetBase + 732;
                WriteStadium.Write(stadium.Name.ToCharArray());
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public int Save(string patch)
        {
            try
            {
                byte[] ss13 = Zlib.ZlibFilePC(MemoryStadium.ToArray());
                File.WriteAllBytes(patch + FILE_NAME, ss13);
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public void CloseMemory()
        {
            if (MemoryStadium != null)
            {
                MemoryStadium.Close();
                ReadStadium.Close();
                WriteStadium.Close();
                StadiumTable.Rows.Clear();
            }
        }

    }
}
