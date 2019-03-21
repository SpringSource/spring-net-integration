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

using Spring.Integration.Core;

namespace Spring.Integration.Channel {
    /// <summary>
    /// Interface for interceptors that are able to view and/or modify the
    /// {@link Message Messages} being sent-to and/or received-from a
    /// {@link MessageChannel}.
    /// </summary>
    /// <author>Mark Fisher</author>
    /// <author>Andreas Doehring (.NET)</author>
    public interface IChannelInterceptor {

        IMessage PreSend(IMessage message, IMessageChannel channel);

        void PostSend(IMessage message, IMessageChannel channel, bool sent);

        bool PreReceive(IMessageChannel channel);

        IMessage PostReceive(IMessage message, IMessageChannel channel);
    }
}
