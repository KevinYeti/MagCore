﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MagCore.Model.Exceptions;

namespace MagCore.Model.Map
{
    public class Map : IMap
    {
        public Map(string file)
        {
            MapFile = file;
            Name = Path.GetFileNameWithoutExtension(file);
        }

        public Size Size { get; set; } = new Size();

        public string MapFile { get; set; }

        public List<Row> Rows { get; set; }

        private int _edge = 0;
        public int Edge => _edge;

        private bool _shift = false;
        public bool Shift => _shift;

        private int _direction = 0;
        public int Direction => _direction;

        public string Name { get; set; }

        public void Load()
        {
            if (File.Exists(MapFile))
            {
                var lines = File.ReadAllLines(MapFile);
                if (lines != null && lines.Length > 3)
                {
                    LoadInternal(lines);
                }
            }
            else
                throw new FileNotFoundException("Map file not found.", MapFile);
        }
        private List<string> _data = null;

        private void LoadInternal(string[] lines)
        {
            //read map attribute content
            var sEdge = lines[0].Replace(" ", string.Empty).Replace("E=", string.Empty);
            var sShift = lines[1].Replace(" ", string.Empty).Replace("S=", string.Empty);
            var sDirection = lines[2].Replace(" ", string.Empty).Replace("D=", string.Empty);
            //try parse the data 
            if (Int32.TryParse(sEdge, out _edge)
                && Int32.TryParse(sDirection, out _direction))
            {
                _shift = sShift == "0" ? false : true;
                _data = new List<string>(); //additional use for map API init
                //set map data & size
                int width = 0;
                int height = lines.Length - 3;
                Rows = new List<Row>();
                for (int i = 3; i < lines.Length; i++)
                {
                    Row row = new Row(this, i - 3, lines[i].Trim().Length);
                    var line = lines[i].Trim();
                    _data.Add( "\"" + line + "\"");    //additional use for map API
                    width = width < line.Length ? line.Length : width;
                    for (int j = 0; j < line.Length; j++)
                    {
                        if (Enum.TryParse<CellType>(line[j].ToString(), out var cell))
                        {
                            row.Cells[j].Type = cell;
                        }
                        else
                            throw new WrongFormatException(new Exception("Error map data."));
                    }
                    Rows.Add(row);
                }

                Size.H = height;
                Size.W = width;
            }
            else
                throw new WrongFormatException(new Exception("Error map data."));

        }

        public virtual bool Check()
        {
            return true;
        }

        public virtual Cell Locate(Position pos)
        {
            throw new NotImplementedException();
        }

        public string ToJson()
        {
            string map = "{{\"Edge\":{0}, \"Shift\":{1}, \"Direction\":{2}, \"Rows\":[{3}]}}";
            string rows = string.Join(",", _data);

            map = string.Format(map, Edge, Convert.ToInt32(Shift), Direction, rows);
            return map;
        }



        public virtual IMap Clone()
        {
            IMap copy = (IMap)this.MemberwiseClone();
            copy.Load();
            return copy;
        }

        public string Cells()
        {
            string json = "[{0}]";
            List<string> rows = new List<string>(Rows.Count);
            foreach (Row row in Rows)
            {
                rows.Add(row.ToJson());
            }

            json = string.Format(json, string.Join(",", rows));
            return json;

        }

        public virtual List<Cell> GetSiblings(Cell cell)
        {
            throw new NotImplementedException();
        }
    }
}
