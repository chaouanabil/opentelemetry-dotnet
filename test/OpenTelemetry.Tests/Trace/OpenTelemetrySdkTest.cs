// <copyright file="OpenTelemetrySdkTest.cs" company="OpenTelemetry Authors">
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

using System.Diagnostics;
using OpenTelemetry.Resources;
using Xunit;

namespace OpenTelemetry.Trace.Tests
{
    public class OpenTelemetrySdkTest
    {
        [Fact]
        public void ResourceGetsAssociatedWithActivity()
        {
            using var activitySource = new ActivitySource(nameof(this.ResourceGetsAssociatedWithActivity));
            var expectedResource = Resources.Resources.CreateServiceResource("ServiceNameAbc");

            using var openTelemetry = Sdk.CreateTracerProviderBuilder()
                .AddSource(nameof(this.ResourceGetsAssociatedWithActivity))
                .SetResource(expectedResource)
                .Build();

            using (var root = activitySource.StartActivity("root"))
            {
                Assert.Equal(expectedResource, root.GetResource());
            }
        }

        [Fact]
        public void DefaultResourceGetsAssociatedWithActivityIfNoneConfigured()
        {
            using var activitySource = new ActivitySource(nameof(this.ResourceGetsAssociatedWithActivity));
            var expectedResource = Resource.Empty;

            using var openTelemetry = Sdk.CreateTracerProviderBuilder()
                .AddSource(nameof(this.ResourceGetsAssociatedWithActivity))
                .Build();

            using (var root = activitySource.StartActivity("root"))
            {
                Assert.Equal(expectedResource, root.GetResource());
            }
        }
    }
}
