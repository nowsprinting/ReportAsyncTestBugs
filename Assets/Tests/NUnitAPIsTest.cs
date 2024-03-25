// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

#pragma warning disable CS1998

namespace Tests
{
    [UnityPlatform(exclude = new[] { RuntimePlatform.WebGLPlayer })]
    [TestFixture]
    public class NUnitAPIsTest
    {
        [Test]
        [MaxTime(500)]
        public async Task MaxTimeAttribute_WithAsyncTest_TestIsNotTerminate()
        {
            await Task.Delay(1000);
        }
        // NotImplementedException: Use ExecuteEnumerable
        // UnityEngine.TestTools.BeforeAfterTestCommandBase`1[T].Execute (NUnit.Framework.Internal.ITestExecutionContext context) (at Library/PackageCache/com.unity.test-framework@1.3.2/UnityEngine.TestRunner/NUnitExtensions/Commands/BeforeAfterTestCommandBase.cs:275)
        // NUnit.Framework.Internal.Commands.MaxTimeCommand.Execute (NUnit.Framework.Internal.ITestExecutionContext context) (at <956b82cfdef641c6bc6a0e5b19798f05>:0)
        // (snip)

        private int _repeatCount;

        [Test]
        [Repeat(2)]
        public async Task RepeatAttribute_WithAsyncTest_TestIsNotTerminate()
        {
            Debug.Log($"Run {++_repeatCount} time(s)");
        }
        // NotImplementedException: Use ExecuteEnumerable
        // UnityEngine.TestTools.BeforeAfterTestCommandBase`1[T].Execute (NUnit.Framework.Internal.ITestExecutionContext context) (at Library/PackageCache/com.unity.test-framework@1.3.2/UnityEngine.TestRunner/NUnitExtensions/Commands/BeforeAfterTestCommandBase.cs:275)
        // NUnit.Framework.RepeatAttribute+RepeatedTestCommand.Execute (NUnit.Framework.Internal.ITestExecutionContext context) (at <956b82cfdef641c6bc6a0e5b19798f05>:0)
        // (snip)

        private int _retryCount;

        [Test]
        [Retry(2)]
        public async Task RetryAttribute_WithAsyncTest_TestIsNotTerminate()
        {
            Assert.That(++_retryCount, Is.EqualTo(2));
        }
        // NotImplementedException: Use ExecuteEnumerable
        // UnityEngine.TestTools.BeforeAfterTestCommandBase`1[T].Execute (NUnit.Framework.Internal.ITestExecutionContext context) (at Library/PackageCache/com.unity.test-framework@1.3.2/UnityEngine.TestRunner/NUnitExtensions/Commands/BeforeAfterTestCommandBase.cs:275)
        // NUnit.Framework.RetryAttribute+RetryCommand.Execute (NUnit.Framework.Internal.ITestExecutionContext context) (at <956b82cfdef641c6bc6a0e5b19798f05>:0)
        // (snip)

        private static async Task ThrowNewException()
        {
            await Task.Delay(100);
            throw new ArgumentException("message!");
        }

        [Test]
        public async Task ThrowsConstraint_WithAsyncTest_TestIsNotTerminate()
        {
            Assert.That(async () => await ThrowNewException(),
                Throws.TypeOf<ArgumentException>().And.Message.EqualTo("message!"));
        }
        // NullReferenceException: Object reference not set to an instance of an object
        // UnityEditor.TestTools.TestRunner.PlaymodeLauncher+BackgroundWatcher.OnPlayModeStateChanged (UnityEditor.PlayModeStateChange state) (at Library/PackageCache/com.unity.test-framework@1.3.2/UnityEditor.TestRunner/TestLaunchers/PlaymodeLauncher.cs:124)
        // UnityEditor.EditorApplication.Internal_PlayModeStateChanged (UnityEditor.PlayModeStateChange state) (at /Users/bokken/buildslave/unity/build/Editor/Mono/EditorApplication.cs:438)
        // UnityEngine.SetupCoroutine:InvokeMoveNext(IEnumerator, IntPtr) (at /Users/bokken/buildslave/unity/build/Runtime/Export/Scripting/Coroutines.cs:17)
        // (snip)

        [Test, Ignore("Fixed in Unity Test Framework v1.3.4")]
        [Timeout(500)]
        public async Task TimeoutAttribute_WithAsyncTest_NotWorkTimeoutSoSuccess()
        {
            await Task.Delay(2000);
        }
    }
}
