// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class DelayedConstraintTest
    {
        [Test]
        public void DelayedConstraint_IsNotWork()
        {
            var start = Time.time; // The time at the beginning of this frame

            Assert.That(Time.time, Is.GreaterThan(start + 2.0f).After(2500));
            // I want it to be asserted after 2500ms. But `After` is not work.
        }

        [Test]
        public async Task DelayedConstraintInAsyncTest_IsNotWork()
        {
            var start = Time.time; // The time at the beginning of this frame
            await Task.Delay(0);

            Assert.That(Time.time, Is.GreaterThan(start + 2.0f).After(2500));
        }

        [UnityTest]
        public IEnumerator DelayedConstraintInUnityTest_IsNotWork()
        {
            var start = Time.time; // The time at the beginning of this frame
            yield return null;

            Assert.That(Time.time, Is.GreaterThan(start + 2.0f).After(2500));
        }
    }
}
