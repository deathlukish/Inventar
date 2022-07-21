using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FKCPObj.XmlInterface
{
    internal class XmlQueryBuilder
    {
        private XDocument xmlQuery;
        public XmlQueryBuilder()
        {
            xmlQuery = new XDocument(new XElement("RK7Query"));
        }
        /// <summary>
        /// Добавить команду в файл
        /// </summary>
        /// <param name="cmd">
        /// Команда для сервера
        /// </param>
        /// <param name="refName">
        /// Имя справочников
        /// </param>
        /// <param name="onlyActive">
        /// Запросить только неактивные записи
        /// </param>
        /// <param name="items">
        /// Параметры фильтрации для сервера
        /// </param>
        /// <returns></returns>
        public XmlQueryBuilder AddCommand(Rk7Cmd cmd, RefNames refName,bool onlyActive, params string[] items)
        {
            xmlQuery.Element("RK7Query")?
                .Add(new XElement("RK7Command2",
                    new XAttribute("CMD", cmd.ToString()),
                    new XAttribute("RefName", refName.ToString()))
                   
            );
            if (onlyActive)
            {
                xmlQuery?.Element("RK7Query")?
                    .Elements("RK7Command2")
                    .First(e => e.Attribute("RefName")?.Value == refName.ToString())
                    .Add(new XAttribute("onlyActive", "1"));
            }
            if (items.Length != 0)
            {
                StringBuilder Prop = new StringBuilder();
                Prop.AppendJoin(",", items);
                xmlQuery?.Element("RK7Query")?
                        .Elements("RK7Command2")
                        .First(e => e?.Attribute("RefName")?.Value == refName.ToString())
                        .Add(new XAttribute("PropMask", $"items.({Prop})"));

            }
            return this;
        }
        public override string ToString()
        {
            return xmlQuery.ToString();
        }

    }
}
