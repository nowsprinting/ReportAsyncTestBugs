// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

#pragma warning disable CS1998

namespace Tests
{
    [TestFixture, Description("This test is not terminate when run on WebGL player")]
    public class DelayInAsyncTest
    {
        [Test]
        public async Task DelayInAsyncTest_Success()
        {
            await Task.Delay(1); // To reproduce the problem, argument > 0
        }
    }
}
