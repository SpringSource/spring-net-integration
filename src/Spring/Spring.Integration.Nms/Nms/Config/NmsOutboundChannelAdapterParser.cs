#region License

/*
 * Copyright 2002-2010 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using System.Xml;
using Spring.Integration.Config.Xml;
using Spring.Objects.Factory;
using Spring.Objects.Factory.Support;
using Spring.Objects.Factory.Xml;
using Spring.Util;

namespace Spring.Integration.Nms.Config
{
    /// <summary>
    ///  
    /// </summary>
    /// <author>Mark Pollack</author>
    public class NmsOutboundChannelAdapterParser : AbstractOutboundChannelAdapterParser
    {
        #region Overrides of AbstractOutboundChannelAdapterParser

        protected override AbstractObjectDefinition ParseConsumer(XmlElement element, ParserContext parserContext)
        {
            ObjectDefinitionBuilder builder = ObjectDefinitionBuilder.GenericObjectDefinition(typeof(NmsSendingMessageHandler));
            string nmsTemplate = element.GetAttribute(NmsAdapterParserUtils.NMS_TEMPLATE_ATTRIBUTE);
            string destination = element.GetAttribute(NmsAdapterParserUtils.DESTINATION_ATTRIBUTE);
            string destinationName = element.GetAttribute(NmsAdapterParserUtils.DESTINATION_NAME_ATTRIBUTE);
            string headerMapper = element.GetAttribute(NmsAdapterParserUtils.HEADER_MAPPER_ATTRIBUTE);
            if (StringUtils.HasText(nmsTemplate))
            {
                if (element.HasAttribute(NmsAdapterParserUtils.CONNECTION_FACTORY_ATTRIBUTE) ||
                        element.HasAttribute(NmsAdapterParserUtils.DESTINATION_NAME_ATTRIBUTE) ||
                        element.HasAttribute(NmsAdapterParserUtils.DESTINATION_ATTRIBUTE))
                {
                    throw new ObjectCreationException(
                            "When providing '" + NmsAdapterParserUtils.NMS_TEMPLATE_ATTRIBUTE +
                            "', none of '" + NmsAdapterParserUtils.CONNECTION_FACTORY_ATTRIBUTE +
                            "', '" + NmsAdapterParserUtils.DESTINATION_ATTRIBUTE + "', or '" +
                            NmsAdapterParserUtils.DESTINATION_NAME_ATTRIBUTE + "' should be provided.");
                }
                builder.AddPropertyReference(NmsAdapterParserUtils.NMS_TEMPLATE_PROPERTY, nmsTemplate);
            }
            else if (StringUtils.HasText(destination) ^ StringUtils.HasText(destinationName))
            {
                builder.AddPropertyReference(NmsAdapterParserUtils.CONNECTION_FACTORY_PROPERTY,
                        NmsAdapterParserUtils.DetermineConnectionFactoryBeanName(element, parserContext));
                if (StringUtils.HasText(destination))
                {
                    builder.AddPropertyReference(NmsAdapterParserUtils.DESTINATION_PROPERTY, destination);
                }
                else
                {
                    builder.AddPropertyValue(NmsAdapterParserUtils.DESTINATION_NAME_PROPERTY, destinationName);
                }
            }
            else
            {
                throw new ObjectCreationException("either a '" + NmsAdapterParserUtils.NMS_TEMPLATE_ATTRIBUTE + "' or one of '" +
                        NmsAdapterParserUtils.DESTINATION_ATTRIBUTE + "' or '" + NmsAdapterParserUtils.DESTINATION_NAME_ATTRIBUTE +
                        "' attributes must be provided");
            }
            if (StringUtils.HasText(headerMapper))
            {
                builder.AddPropertyReference(NmsAdapterParserUtils.HEADER_MAPPER_PROPERTY, headerMapper);
            }
            IntegrationNamespaceUtils.SetValueIfAttributeDefined(builder, element, "extract-payload");
            return builder.ObjectDefinition;           
        }

        #endregion
    }

}