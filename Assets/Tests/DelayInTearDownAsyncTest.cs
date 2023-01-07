// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

#pragma warning disable CS1998

namespace Tests
{
    [TestFixture, Description("This test is timeout (180000ms) when run on WebGL player")]
    public class DelayInTearDownAsyncTest
    {
        [TearDown]
        public async Task TearDownAsync()
        {
            await Task.Delay(1); // To reproduce the problem, argument > 0
        }

        [Test]
        public void NormallyTest_Success()
        {
        }
    }
}
