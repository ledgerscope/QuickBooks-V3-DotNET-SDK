﻿////********************************************************************
// <copyright file="CDCCallCompletedEventArgs.cs" company="Intuit">
/*******************************************************************************
 * Copyright 2016 Intuit
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *******************************************************************************/
// <summary>This file contains SdkException.</summary>
// <summary>This file contains logic for REST request handler.</summary>
////********************************************************************

namespace Intuit.Ipp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Intuit.Ipp.Data;
    using Intuit.Ipp.Exception;

    /// <summary>
    /// Event argument is class used to communicate after FindAll operation completed.
    /// </summary>
    public partial class CDCCallCompletedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the FindAllCallCompletedEventArgs class.
        /// </summary>
        public CDCCallCompletedEventArgs()
        {
            this.Entities = new Dictionary<string, List<IEntity>>();
        }

        /// <summary>
        /// Gets or sets Entities from the result.
        /// </summary>
        public Dictionary<string, List<IEntity>> Entities
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Ids Exception.
        /// </summary>
        public IdsException Error
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the List of entity value with particular key
        /// </summary>
        /// <param name="key">key.</param>
        public List<IEntity> getEntity(string key)
        {
            return this.Entities.FirstOrDefault(x => x.Key == key).Value;
        }
    }
}
