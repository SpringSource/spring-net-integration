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

namespace Spring.Integration.Core {

    /// <summary>
    /// The central interface that any Message type must implement.
    /// </summary>
    /// <author>Mark Fisher</author>
    /// <author>Arjen Poutsma</author>
    /// <author>Andreas D�hring (.NET)</author>
    public interface IMessage {

        /// <summary>
        /// Gets the headers of the message
        /// </summary>
        /// <value>The headers.</value>
        MessageHeaders Headers { get; }

        /// <summary>
        /// Gets the payload, that is the body, of the message
        /// </summary>
        /// <value>The payload.</value>
        object Payload { get; }
    }
}