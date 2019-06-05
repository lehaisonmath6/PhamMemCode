﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfQLSpa
{
    public class DataProvider
    {
        private static DataProvider _instance;
        public static DataProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataProvider();

                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        public QLSpaEntities DB { get; set; }
        public DataProvider()
        {
            DB = new QLSpaEntities();
        }
    }
}
