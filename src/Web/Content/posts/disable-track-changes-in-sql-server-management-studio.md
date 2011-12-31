For whatever reason, I get very little use out of the "track changes" feature in
both Visual Studio and SQL Server Management Studio, which is designed to
highlight lines that changed since the last save:

![Management Studio with Track Changes 'enabled'][a]

Visual Studio has an option to disable it entirely (`Tools > Options > Text
Editor > Track changes`), but Management Studio lacks this feature. As a
workaround, you can set the "Item background" color for these two items to
"Automatic" (available via `Tools > Options > Environment > Fonts and Colors`):

* Track Changes after save
* Track Changes before save

Changing these settings results in a pleasant absence of the "track changes" bar:

![Management Studio with Track Changes 'disabled'][b]

It's worth noting that Visual Studio's behavior is slightly different. Setting the
colors of these two options to "Automatic" maintains the original green and yellow
colors instead of making them mimic the background color, as in Management Studio.

[a]: Content/posts/img/disable-track-changes-in-sql-server-management-studio_01.png
[b]: Content/posts/img/disable-track-changes-in-sql-server-management-studio_02.png