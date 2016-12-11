﻿namespace IBatisNet.DataMapper.Configuration.Serializers
{
    using IBatisNet.Common.Xml;
    using IBatisNet.DataMapper.Configuration.Sql.Dynamic.Elements;
    using IBatisNet.DataMapper.Scope;
    using System;
    using System.Collections.Specialized;
    using System.Xml;

    public sealed class IsNotEqualDeSerializer : IDeSerializer
    {
        private ConfigurationScope _configScope;

        public IsNotEqualDeSerializer(ConfigurationScope configScope)
        {
            this._configScope = configScope;
        }

        public SqlTag Deserialize(XmlNode node)
        {
            IsNotEqual equal = new IsNotEqual(this._configScope.DataExchangeFactory.AccessorFactory);
            NameValueCollection attributes = NodeUtils.ParseAttributes(node, this._configScope.Properties);
            equal.Prepend = NodeUtils.GetStringAttribute(attributes, "prepend");
            equal.Property = NodeUtils.GetStringAttribute(attributes, "property");
            equal.CompareProperty = NodeUtils.GetStringAttribute(attributes, "compareProperty");
            equal.CompareValue = NodeUtils.GetStringAttribute(attributes, "compareValue");
            return equal;
        }
    }
}

