﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epi.Web.MVC.Models
    {
    public class TestModel
        {
        private string _DataBaseTestStatus;
        public string DBTestStatus 
            {
            get { return _DataBaseTestStatus; }
            set { _DataBaseTestStatus = value; }
            }

        private string _ServiceTestStatus;
        public string STestStatus
            {
            get { return _ServiceTestStatus; }
            set { _ServiceTestStatus = value; }
            }
        private string _EFTestStatus;
        public string EFTestStatus
            {
            get { return _EFTestStatus; }
            set { _EFTestStatus = value; }
            }
        }
    }