﻿/*
 * Copyright 2020 Mikhail Shiryaev
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
 * 
 * 
 * Product  : Rapid SCADA
 * Module   : ScadaData
 * Summary  : Represents an event mask of an input channel
 * 
 * Author   : Mikhail Shiryaev
 * Created  : 2020
 * Modified : 2020
 */

namespace Scada.Data.Models
{
    /// <summary>
    /// Represents an event mask of an input channel.
    /// <para>Представляет маску событий входного канала.</para>
    /// </summary>
    public struct EventMask
    {
        /// <summary>
        /// The bit indicating whether events are enabled for the channel.
        /// </summary>
        public const int EnabledBit = 0;
        /// <summary>
        /// The bit indicating whether a client application should play a beep on event.
        /// </summary>
        public const int BeepBit = 1;
        /// <summary>
        /// The bit indicating whether an event should be raised when channel data changes.
        /// </summary>
        public const int CnlDataChangeBit = 2;
        /// <summary>
        /// The bit indicating whether an event should be raised when channel status changes.
        /// </summary>
        public const int CnlStatusChangeBit = 3;
        /// <summary>
        /// The bit indicating whether an event should be raised when the channel becomes undefined, or vice versa.
        /// </summary>
        public const int CnlUndefinedBit = 4;


        /// <summary>
        /// Initializes a new instance of the structure.
        /// </summary>
        public EventMask(int? mask)
        {
            Mask = mask ?? 0;
        }


        /// <summary>
        /// Gets the mask value.
        /// </summary>
        public int Mask { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether events are enabled for the channel.
        /// </summary>
        public bool Enabled
        {
            get
            {
                return BitIsSet(EnabledBit);
            }
            set
            {
                SetBit(EnabledBit, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a client application should play a beep on event.
        /// </summary>
        public bool Beep
        {
            get
            {
                return BitIsSet(BeepBit);
            }
            set
            {
                SetBit(BeepBit, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether an event should be raised when channel data changes.
        /// </summary>
        public bool CnlDataChange
        {
            get
            {
                return BitIsSet(CnlDataChangeBit);
            }
            set
            {
                SetBit(CnlDataChangeBit, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether an event should be raised when channel status changes.
        /// </summary>
        public bool CnlStatusChange
        {
            get
            {
                return BitIsSet(CnlStatusChangeBit);
            }
            set
            {
                SetBit(CnlStatusChangeBit, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether an event should be raised when the channel becomes undefined, or vice versa.
        /// </summary>
        public bool CnlUndefined
        {
            get
            {
                return BitIsSet(CnlUndefinedBit);
            }
            set
            {
                SetBit(CnlUndefinedBit, value);
            }
        }


        /// <summary>
        /// Checks whether the mask bit is set.
        /// </summary>
        private bool BitIsSet(int bit)
        {
            return ((Mask >> bit) & 0x01) > 0;
        }

        /// <summary>
        /// Sets the specified mask bit.
        /// </summary>
        private void SetBit(int bit, bool value)
        {
            Mask = value ?
                Mask | (1 << bit) :
                Mask & ~(1 << bit);
        }
    }
}
