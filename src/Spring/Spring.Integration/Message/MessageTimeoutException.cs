#region License

/*
 * Copyright 2002-2009 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF Any KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using Spring.Integration.Core;

namespace Spring.Integration.Message {
    /// <summary>
    /// Strategy interface for mapping from a <see cref="IMessage"/> to an <see cref="object"/>.
    /// </summary>
    /// <author>Mark Fisher</author>
    /// <author>Andreas D�hring (.NET)</author>
    public class MessageTimeoutException : MessageHandlingException {

        /// <summary>
        /// create a new <see cref="MessageTimeoutException"/> with the <paramref name="failedMessage"/>,
        /// <paramref name="description"/> and <paramref name="innerException"/>
        /// </summary>
        /// <param name="failedMessage">the message which could not be delivered</param>
        /// <param name="description">a description</param>
        /// <param name="innerException">the inner exception</param>
        public MessageTimeoutException(IMessage failedMessage, string description, Exception innerException)
            : base(failedMessage, description, innerException) {
        }

        /// <summary>
        /// create a new <see cref="MessageTimeoutException"/> with the <paramref name="failedMessage"/>,
        /// and <paramref name="description"/>
        /// </summary>
        /// <param name="failedMessage">the message which could not be delivered</param>
        /// <param name="description">a description</param>
        public MessageTimeoutException(IMessage failedMessage, string description)
            : base(failedMessage, description) {
        }

        /// <summary>
        /// create a new <see cref="MessageTimeoutException"/> with the <paramref name="failedMessage"/>,
        /// and <paramref name="innerException"/>
        /// </summary>
        /// <param name="failedMessage">the message which could not be delivered</param>
        /// <param name="innerException">the inner exception</param>
        public MessageTimeoutException(IMessage failedMessage, Exception innerException)
            : base(failedMessage, innerException) {
        }

        /// <summary>
        /// create a new <see cref="MessageTimeoutException"/> with the <paramref name="failedMessage"/>,
        /// </summary>
        /// <param name="failedMessage">the message which could not be delivered</param>
        public MessageTimeoutException(IMessage failedMessage)
            : base(failedMessage) {
        }
    }
}
