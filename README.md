# ReportAsyncTestBugs

4つの事象をレポート済み


## IN-28107 - Async test is not terminate

https://unity3d.atlassian.net/servicedesk/customer/portal/2/IN-28107

非同期テストと以下の組み合わせではテストが終了しない

* `MaxTimeAttribute`
* `RepeatAttribute`
* `RetryAttribute`
* `Throws` constraint


## ~~IN-28108 - TimeoutAttribute is not working with async test~~

~~https://unity3d.atlassian.net/servicedesk/customer/portal/2/IN-28108~~

~~非同期テストでは `TimeoutAttribute` が機能しない。
割り込まないし、テストも失敗しない~~

Unity Test Framework v1.3.4で修正された


## IN-28109 - Task.Delay is not terminate in async test run on WebGL player

https://unity3d.atlassian.net/servicedesk/customer/portal/2/IN-28109

WebGL Playerにおけるテスト実行で `Task.Delay` が終了しない。
なお、

* 引数1以上の場合（0は通る）
* SetUp/TearDownでも同様だが、こちらは180secでタイムアウトでテスト失敗になる


## IN-30529 - DelayedConstraint is not work

https://unity3d.atlassian.net/servicedesk/customer/portal/2/IN-30529

DelayedConstraint (After)が動作しない。
