---
layout: default
permalink: index
---

<!-- hero !-->
<div class="layout-angle">
	<div class="top-triangle wow slideInRight" data-wow-duration="1.5s"></div>
	<div class="layout-angle-inner">
<div class="hero">
	<div class="container">
		<div class="row">
		
			<div class="col-lg-5 hero-header">
			
				<h1>
					<div class="display-4">Dapper Plus</div>
				</h1>
				
				<div class="wow zoomIn">
					<a class="btn btn-xl btn-z" href="{{ site.github.url }}/download"
							onclick="ga('send', 'event', { eventAction: 'download'});">
						<i class="fa fa-cloud-download" aria-hidden="true"></i>
						NuGet Download
						<i class="fa fa-angle-right"></i>
					</a>
				</div>
				
				<div class="download-count">
					<div class="item-text">Download Count:</div>
					<div class="item-image wow lightSpeedIn"><img src="https://zzzprojects.github.io/images/nuget/dapper-plus-big-d.svg" /></div>
				</div>

				
			</div>
			
			<div class="col-lg-7 hero-examples">
			
				<div class="row hero-examples-1">
				
				
					<div class="col-lg-3 wow slideInUp"> 
						<h5 class="wow rollIn">EASY TO<br />USE</h5>
						<div class="hero-arrow hero-arrow-ltr">
							<img src="images/arrow-down1.png">
						</div>
					</div>

					<div class="col-lg-9 wow slideInRight">
						<div class="card card-code card-code-dark-inverse">
							<div class="card-header">Extend Dapper with IDbConnection</div>
							<div class="card-body">
{% highlight csharp %}
// CONFIGURE & MAP entity
DapperPlusManager.Entity<Order>()
                 .Table("Orders")
                 .Identity(x => x.ID);

// CHAIN & SAVE entity
connection.BulkInsert(orders)
    .AlsoInsert(order => order.Items);
    .Include(x => x.ThenMerge(order => order.Invoice)
        .AsloMerge(invoice => invoice.Items))
    .AlsoMerge(x => x.ShippingAddress);   
{% endhighlight %}
							</div>
						</div>
					</div>
				</div>
				
				<div class="row hero-examples-2">
				
					<div class="col-lg-3 order-lg-2 wow slideInDown">
						<h5 class="wow rollIn">EASY TO<br />CUSTOMIZE</h5>
						<div class="hero-arrow hero-arrow-rtl">
							<img src="images/arrow-down1.png">
						</div>
					</div>
					
					<div class="col-lg-9 order-lg-1 wow slideInLeft">
						<div class="card card-code card-code-dark-inverse">
							<div class="card-header">Flexible and feature-rich API</div>
							<div class="card-body">
{% highlight csharp %}
// Bulk Insert with "One to One" Relation
connection.BulkInsert(orders, order => order.Invoice);

// Bulk Insert with "One to Many" Relation
connection.BulkInsert(orders, order => order.Items);

//Bulk Insert with "Mixed" Relation
connection.BulkInsert(orders, order => order.Items, 
    order => order.Invoice);

{% endhighlight %}
							</div>
						</div>
					</div>						
				</div>
				
			</div>
			
		</div>
	</div>	
</div>
	</div>
	<div class="bottom-triangle-outer">
		<div class="bottom-triangle wow slideInLeft" data-wow-duration="1.5s"></div>
	</div>
</div>
<style>
.hero {
	background: transparent;
}
</style>

<!-- featured !-->
<div class="featured">
	<div class="container">
	
		<!-- Improve Performance !-->
		<h2 class="wow slideInUp">High <span class="text-z">Performance</span> Operations</h2>
		<div class="row">
			<div class="col-lg-5 left wow slideInLeft">
				<p>
                    Use <span class="text-z">scalable</span> bulk operations (Bulk Insert, Update, Delete and Merge) and always get the best <span class="text-z">performance</span> available for your database provider.
				</p>
				<p>
					Support all major providers:
				</p>
				
				<ul class="featured-list-sm">
					<li><i class="fa fa-check-square-o"></i>&nbsp;SQL Server 2008+</li>
					<li><i class="fa fa-check-square-o"></i>&nbsp;SQL Azure</li>
					<li><i class="fa fa-check-square-o"></i>&nbsp;SQL Compact</li>
					<li><i class="fa fa-check-square-o"></i>&nbsp;MySQL</li>					
					<li><i class="fa fa-check-square-o"></i>&nbsp;Oracle</li>
					<li><i class="fa fa-check-square-o"></i>&nbsp;PostgreSQL</li>
					<li><i class="fa fa-check-square-o"></i>&nbsp;SQLite</li>					
				</ul>	
			</div>
			<div class="col-lg-7 right wow slideInRight">
				<table>
					<thead>
						<tr>
							<th>Operations</th>
							<th>1,000 Rows</th>
							<th>10,000 Rows</th>
							<th>100,000 Rows</th>
                            <th>1,000,000 Rows</th>
						</tr>
					</thead>
					<tbody>
						<tr>
							<th>Insert</th>
							<td>6 ms</td>
							<td>25 ms</td>
							<td>200 ms</td>
                            <td>2,000 ms</td>
						</tr>
						<tr>
							<th>Update</th>
							<td>50 ms</td>
							<td>80 ms</td>
							<td>575 ms</td>
                            <td>6,500 ms</td>
						</tr>
						<tr>
							<th>Delete</th>
							<td>45 ms</td>
							<td>70 ms</td>
							<td>625 ms</td>
							<td>6,800 ms</td>
						</tr>
						<tr>
							<th>Merge</th>
							<td>65 ms</td>
							<td>160 ms</td>
							<td>1,200 ms</td>
							<td>12,000 ms</td>
						</tr>
					</tbody>
				</table>

				<p class="text-muted">* Benchmark for SQL Server</p>
			</div>
		</div>
	</div>
</div>

<div class="testimonials">
{% include layout-angle-begin.html %}
	<div class="container">
		<h2>Amazing <span class="text-z">performance</span>, outstanding <span class="text-z">support</span>!</h2>
		
		<blockquote class="blockquote text-center wow slideInLeft">
			<p class="mb-0">We were very, very pleased with the customer support. There was no question, problem or wish that was not answered AND solved within days! We think that’s very unique!</p>
			<footer class="blockquote-footer">Klemens Stelzmüller, <a href="http://www.beka-software.at/" target="_blank">Beka-software</a></footer>
		</blockquote>
		<blockquote class="blockquote text-center wow slideInRight">
			<p class="mb-0">I’d definitely recommend it as it is a great product with a great performance and reliability.</p>
			<footer class="blockquote-footer">Eric Rey, <a href="http://www.transturcarrental.com/" target="_blank">Transtur</a></footer>
		</blockquote>
		<blockquote class="blockquote text-center wow slideInLeft">
			<p class="mb-0">It’s great. It took me 5 minutes to implement it and makes my application 100x more responsive for certain database operations.</p>
			<footer class="blockquote-footer">Dave Weisberg</footer>
		</blockquote>

		<div class="more">
			<a href="http://www.zzzprojects.com/testimonials/" target="_blank" class="btn btn-lg btn-z" role="button"
					onclick="ga('send', 'event', { eventAction: 'testimonials'});">
				<i class="fa fa-comments"></i>&nbsp;
				Read More Testimonials
			</a>
		</div>
	</div>
{% include layout-angle-end.html %}
</div>


<!-- features !-->
<div class="features">

	<div class="container">
		
		<!-- Mapper !-->
		<h2 class="wow slideInUp">Mapper</h2>
		<div class="row">
			<div class="col-lg-5 wow slideInLeft">
				<p class="feature-tagline">Dapper Plus Mapper allow to map the conceptual model (Entity) with the storage model (Database) and configure options to perform Bulk Actions.</p>
				<div class="more-info">
					<a href="{{ site.github.url }}/dapper-plus-mapper" class="btn btn-lg btn-z" role="button">
						<i class="fa fa-book"></i>&nbsp;
						Read More
					</a>
				</div>	
			</div>
			<div class="col-lg-7 wow slideInRight">
				<div class="card card-code card-code-light">
					<div class="card-header">Mapper Examples</div>
					<div class="card-body">
{% highlight csharp %}
// Easy to use
DapperPlusManager.Entity<Order>().Table("Orders")
                                 .Identity(x => x.ID)
                                 .BatchSize(200);
{% endhighlight %}
					</div>
				</div>
			</div>
		</div>

		<hr class="m-y-md" />
		
		<!-- Bulk Actions !-->
		<h2 class="wow slideInUp">Bulk Actions</h2>
		<div class="row">
			<div class="col-lg-5 wow slideInLeft">
				<p class="feature-tagline">Bulk Actions allow to perform a bulk insert, update, delete or merge and include related child items.</p>
				<ul>
					<li>Bulk Insert</li>
					<li>Bulk Update</li>
					<li>Bulk Delete</li>
					<li>Bulk Merge</li>
				</ul>
				<div class="more-info">
					<a href="{{ site.github.url }}/dapper-plus-actions" class="btn btn-lg btn-z" role="button">
						<i class="fa fa-book"></i>&nbsp;
						Read More
					</a>
				</div>	
			</div>
			<div class="col-lg-7 wow slideInRight">
				<div class="card card-code card-code-light">
					<div class="card-header">Bulk Actions Examples</div>
					<div class="card-body">
{% highlight csharp %}

connection.BulkInsert(orders, order => order.Items)
          .BulkInsert(invoices, invoice => invoice.Items)
          .BulkMerge(shippingAddresses);

{% endhighlight %}	
					</div>
				</div>
			</div>
		</div>
		
		<hr class="m-y-md" />
		
		<!-- Also Bulk Actions !-->
		<h2 class="wow slideInUp">Also Bulk Actions</h2>
		<div class="row">
			<div class="col-lg-5 wow slideInLeft">
				<p class="feature-tagline">Also Bulk Actions allow to perform bulk action with a lambda expression using entities from the last Bulk[Action] or ThenBulk[Action] used.</p>
				<div class="more-info">
					<a href="{{ site.github.url }}/dapper-plus-actions#also-bulk-actions" class="btn btn-lg btn-z" role="button">
						<i class="fa fa-book"></i>&nbsp;
						Read More
					</a>
				</div>	
			</div>
			<div class="col-lg-7 wow slideInRight">
				<div class="card card-code card-code-light">
					<div class="card-header">Also Bulk Actions Examples</div>
					<div class="card-body">
{% highlight csharp %}
connection.BulkInsert(orders)
          .AlsoInsert(order => order.Items)
          .AlsoInsert(order => order.Invoice)
          .AlsoInsert(order => order.Invoice.Items);
{% endhighlight %}	
					</div>
				</div>
			</div>
		</div>

        <hr class="m-y-md" />
		
        <!-- Then Bulk Actions !-->
		<h2 class="wow slideInUp">Then Bulk Actions</h2>
		<div class="row">
			<div class="col-lg-5 wow slideInLeft">
				<p class="feature-tagline">Then Bulk Actions is similar to Also Bulk Actions but modify entities used for the next bulk action using a lambda expression.</p>
				<div class="more-info">
					<a href="{{ site.github.url }}/dapper-plus-actions#then-bulk-actions" class="btn btn-lg btn-z" role="button">
						<i class="fa fa-book"></i>&nbsp;
						Read More
					</a>
				</div>	
			</div>
			<div class="col-lg-7 wow slideInRight">
				<div class="card card-code card-code-light">
					<div class="card-header">Then Bulk Actions Examples</div>
					<div class="card-body">
{% highlight csharp %}
connection.BulkInsert(orders)
          .AlsoInsert(order => order.Items)
          .ThenInsert(order => order.Invoice)
          .ThenInsert(invoice => invoice.Items);
{% endhighlight %}	
					</div>
				</div>
			</div>
		</div>

        <hr class="m-y-md" />

        <!-- Include Actions !-->
		<h2 class="wow slideInUp">Include Actions</h2>
		<div class="row">
			<div class="col-lg-5 wow slideInLeft">
				<p class="feature-tagline">The Dapper Plus Include method allow resolving issues with multiple "ThenBulk[Action]" method.</p>
				<div class="more-info">
					<a href="{{ site.github.url }}/dapper-plus-actions#include-actions" class="btn btn-lg btn-z" role="button">
						<i class="fa fa-book"></i>&nbsp;
						Read More
					</a>
				</div>	
			</div>
			<div class="col-lg-7 wow slideInRight">
				<div class="card card-code card-code-light">
					<div class="card-header">Include Actions Examples</div>
					<div class="card-body">
{% highlight csharp %}
connection.BulkInsert(orders)
          .Include(x => x.ThenInsert(order => order.Items)
                         .ThenInsert(orderItem => orderItem.Metas))
          .Include(x => x.ThenInsert(order => order.Invoice)
                         .ThenInsert(Invoice => invoice.Items)); 
{% endhighlight %}	
					</div>
				</div>
			</div>
		</div>

		<!-- more-feature !-->
		<div class="more">
			<a href="{{ site.github.url }}/tutorials" class="btn btn-z btn-xl" role="button">
				<i class="fa fa-book"></i>&nbsp;Read Tutorials
			</a>
		</div>
		
	</div>
</div>