﻿namespace IBatisNet.DataMapper.Configuration.Serializers
{
    using IBatisNet.Common.Xml;
    using IBatisNet.DataMapper.Configuration.Sql.Dynamic.Elements;
    using IBatisNet.DataMapper.Scope;
    using System;
    using System.Collections.Specialized;
    using System.Xml;

    public sealed class IsLessThanDeSerializer : IDeSerializer
    {
        private ConfigurationScope _configScope;

        public IsLessThanDeSerializer(ConfigurationScope configScope)
        {
            this._configScope = configScope;
        }

        public SqlTag Deserialize(XmlNode node)
        {
            IsLessThan than = new IsLessThan(this._configScope.DataExchangeFactory.AccessorFactory);
            NameValueCollection attributes = NodeUtils.ParseAttributes(node, this._configScope.Properties);
            than.Prepend = NodeUtils.GetStringAttribute(attributes, "prepend");
            than.Property = NodeUtils.GetStringAttribute(attributes, "property");
            than.CompareProperty = NodeUtils.GetStringAttribute(attributes, "compareProperty");
            than.CompareValue = NodeUtils.GetStringAttribute(attributes, "compareValue");
            return than;
        }
    }
}

