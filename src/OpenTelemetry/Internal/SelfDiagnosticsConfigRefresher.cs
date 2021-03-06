// <copyright file="SelfDiagnosticsConfigRefresher.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;

namespace OpenTelemetry.Internal
{
    /// <summary>
    /// SelfDiagnosticsConfigRefresher class checks a location for a configuration file
    /// and open a MemoryMappedFile of a configured size at the configured file path.
    /// The class provides a stream object with proper write position if the configuration
    /// file is present and valid. Otherwise, the stream object would be unavailable,
    /// nothing will be logged to any file.
    /// </summary>
    internal class SelfDiagnosticsConfigRefresher : IDisposable
    {
        // Once the configuration file is valid, an eventListener object will be created.
        // Commented out for now to avoid the "field was never used" compiler error.
        // private SelfDiagnosticsEventListener eventListener;

        // TODO
        // public bool TryGetLogStream(int byteCount, out Stream stream, out int availableByteCount)
        // {
        //    stream = null;
        //    availableByteCount = 0;
        //    return false;
        // }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TODO: Dispose the file stream, if one is open.
            }
        }
    }
}
