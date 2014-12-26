// Copyright 2007-2014 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Builders
{
    using System;
    using System.Net.Mime;
    using Serialization;
    using Transports;


    /// <summary>
    /// Used to build and configure a service bus instance as it is created
    /// </summary>
    public interface IServiceBusBuilder
    {
        /// <summary>
        /// The default message deserializer
        /// </summary>
        IMessageDeserializer MessageDeserializer { get; }

        /// <summary>
        /// The default message serializer
        /// </summary>
        IMessageSerializer MessageSerializer { get; }

        /// <summary>
        /// Adds a receive endpoint to the bus
        /// </summary>
        /// <param name="receiveEndpoint"></param>
        void AddReceiveEndpoint(IReceiveEndpoint receiveEndpoint);

        /// <summary>
        /// Sets the outbound message serializer
        /// </summary>
        /// <param name="serializerFactory">The factory to create the message serializer</param>
        void SetMessageSerializer(Func<IMessageSerializer> serializerFactory);

        /// <summary>
        /// Adds an inbound message deserializer to the available deserializers
        /// </summary>
        /// <param name="contentType">The content type of the deserializer</param>
        /// <param name="deserializerFactory">The factory to create the deserializer</param>
        void AddMessageDeserializer(ContentType contentType,
            Func<ISendEndpointProvider, IPublishEndpoint, IMessageDeserializer> deserializerFactory);
    }
}