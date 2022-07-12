﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FKCPObj.SimpleClass
{
    internal class XmlQueryCreater
    {
        private XDocument xmlQuery;
        public XmlQueryCreater()
        {
            xmlQuery = new XDocument(new XElement("RK7Query"));
        }

        public XmlQueryCreater AddCommand(Rk7Cmd cmd, RefNames refName, params string[] items)
        {
            xmlQuery.Element("RK7Query")?
                .Add(new XElement("RK7Command2",
                    new XAttribute("CMD", cmd.ToString()),
                    new XAttribute("RefName", refName.ToString()))

            );
            if (items.Length != 0)
            {
                StringBuilder Prop = new StringBuilder();
                Prop.AppendJoin(",", items);
                xmlQuery.Element("RK7Query")?
                        .Element("RK7Command2")?
                        .Add(new XAttribute("PropMask", $"items.({Prop})"));

            }
            return this;
        }
        public override string ToString()
        {
            return this.xmlQuery.ToString();
        }

    }
}
