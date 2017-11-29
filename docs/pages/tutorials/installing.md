---
permalink: installing
---

**Dapper Plus** can be installed through NuGet.

This library is **NOT FREE**

The latest version always contains a trial that expires at the end of the month. You can extend your trial for several months by downloading the latest version at the start of every month.

## Step 1 - NuGet Download


<div class="row">
	<div class="col-lg-6">
		<div class="card card-layout-z2 wow slideInLeft">
			<div class="card-header wow slideInDown">
				<h3>Dapper Plus</h3>
			</div>
			<div class="card-body wow slideInUp">
				<a class="btn btn-lg btn-z" role="button" href="https://www.nuget.org/packages/Z.Dapper.Plus/" onclick="ga('send', 'event', { eventAction: 'download'});" style="visibility: visible; animation-name: pulse;">
					<i class="fa fa-cloud-download" aria-hidden="true"></i>
					NuGet Download
				</a>
				<div>Download Count:</div>
				<div class="download-count2"><img src="https://zzzprojects.github.io/images/nuget/dapper-plus-big-d.svg"></div>
			</div>
		</div>
	</div>
	
</div>
<br /><br /><br />

## Step 2 - Done

**Dapper Plus** doesn't require any configuration by default.

All bulk actions extension methods are automatically added to your IDbConnection interface:
- BulkInsert
- BulkUpdate
- BulkDelete
- BulkMerge
- Bulk Action Async
- Bulk Also Actions
- Bulk Then Actions
- Bulk Include Actions
