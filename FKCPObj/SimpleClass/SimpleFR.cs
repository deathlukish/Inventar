﻿using FKCPObj.SimpleClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKCPObj.SimpleClass
{
    public class SimpleFR
    {
        private readonly uint _NumFR;
        private readonly string? _ProduceName;
        private readonly string? _Model;
        private List<SimpleFN>? _FNList;
        private TypeConnect _connectType;
        private bool _isConnected;
        private bool _isWorking;

    }
}
