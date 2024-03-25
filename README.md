# ReportAsyncTestBugs


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


## IN-30529 - DelayedConstraint is not work

https://unity3d.atlassian.net/servicedesk/customer/portal/2/IN-30529

DelayedConstraint（After）が動作しない
