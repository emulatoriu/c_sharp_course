﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SrcChess2.FICSInterface {

    /// <summary>
    /// FICS Connection setting
    /// </summary>
    public class FICSConnectionSetting {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="hostName"> Host name</param>
        /// <param name="hostPort"> Host port</param>
        /// <param name="userName"> User name</param>
        public FICSConnectionSetting(string hostName, int hostPort, string userName) {
            HostName    = hostName;
            HostPort    = hostPort;
            UserName    = userName;
        }

        /// <summary>FICS Server Host Name</summary>
        public string   HostName { get; set; }
        /// <summary>FICS Server Host port</summary>
        public int      HostPort { get; set; }
        /// <summary>true for anonymous, false for rated</summary>
        public bool     Anonymous { get; set; }
        /// <summary>User name</summary>
        public string   UserName { get; set; }
    }
}
