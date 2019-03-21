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

#region

using System;
using System.Collections.Generic;
using Spring.Integration.Aggregator;
using Spring.Integration.Core;

#endregion

namespace Spring.Integration.Tests.Config
{
    /// <author>Marius Bogoevici</author>
    /// <author>Andreas D�hring (.NET)</author>
    public class TestCompletionStrategy : ICompletionStrategy
    {
        public bool IsComplete(IList<IMessage> messages)
        {
            throw new NotSupportedException(
                "This is not intended to be implemented, but to verify injection into an <aggregator>");
        }
    }
}