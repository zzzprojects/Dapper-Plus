# Purchase

<!-- validation !-->
<div id="error_validation" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="modal_agreement" aria-hidden="true">
	<div class="modal-dialog" role="document">
		<div class="modal-content">
			<div class="modal-header">
				<h4 class="modal-title" id="modal_agreement">License Agreement</h4>
			</div>
			<div class="modal-body bg-danger">
				You must read and agree to the License Agreement.
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
			</div>
		</div>
	</div>
</div>


<div class="container">

	<div class="row">
		<div class="col-lg-7 purchasing-step wow slideInUp">

			<form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top" onsubmit="return purchase_validate()">
				<input type="hidden" name="cmd" value="_s-xclick">
				<input type="hidden" name="currency_code" value="USD">
				<input type="hidden" name="on0" value="Seats">
				
				<h2>Step 1 - Choose License</h2>
				<div style="width: 450px;">
					<div class="form-group">
						<label class="form-label form-label-lg">Provider:</label> 
						<select id="provider_type" name="hosted_button_id" class="form-control" onchange="selectProduct()">
							<option value="TJB3SWSLJEC7C">SQL Server/ Azure Provider</option>
							<option value="UCACT78NAMNLJ">Oracle Provider</option>
							<option value="76295G8T6N8EN">MySQL Provider</option>
							<option value="ASN8KBSAGR2DJ">PostgreSQL</option>
							<option value="GV579KMMBNEAU">SQL Compact Provider</option>
							<option value="LGP7STYXSNW7S">SQLite Provider</option>
							<option value="VXEBFHKXL56NE">ALL Providers</option>
						</select> 
					</div>
					<label class="form-label form-label-lg">Seat:</label> 
					<select id="product_option" name="os0" class="form-control">
						<option id="seat1" value="1 seat">Dapper Plus $599 (1 developer seat)</option>
						<option id="seat2_4" value="2-4 seats" selected>Dapper Plus $799 (2-4 developer seats)</option>
						<option id="seat5_9" value="5-9 seats">Dapper Plus $999 (5-9 developer seats)</option>
						<option id="seat10_14" value="10-14 seats">Dapper Plus $1199 (10-14 developer seats)</option>
						<option id="seat15_19" value="15-19 seats">Dapper Plus $1399 (15-19 developer seats)</option>
					</select> 
				</div>
				
				<h2>Step 2 - Purchase</h2>
				<div class="checkbox">
					<label>
						<input id="agree_agreement" type="checkbox">&nbsp;I have read and agree to the <a href="http://www.zzzprojects.com/license-agreement/" target="_blank">License Agreement</a>.
					</label>
				</div>
				<br />
				<button type="submit" class="btn btn-z btn-lg" onclick="ga('send', 'event', { eventAction: 'buy'});">
					<i class="fa fa-shopping-cart"></i>&nbsp;BUY NOW
				</button>
				
				<div class="more-option">*&nbsp;Read the FAQ below for alternative payment methods.</div>				
			</form>
			
		</div>
	
		<div class="col-lg-5">
		
			<div class="card card-layout-z1 wow slideInRight">
				<div class="card-header">
					<h2>What is included?</h2>
				</div>
				<div class="card-body">
					<h3>Bulk Operations</h3>
					<ul>
						<li><i class="fa fa-check-square-o"></i>&nbsp;Bulk Insert</li>
						<li><i class="fa fa-check-square-o"></i>&nbsp;Bulk Update</li>
						<li><i class="fa fa-check-square-o"></i>&nbsp;Bulk Delete</li>
						<li><i class="fa fa-check-square-o"></i>&nbsp;Bulk Merge</li>
					</ul>
					<h3>Bulk Actions</h3>
					<ul>
						<li><i class="fa fa-check-square-o"></i>&nbsp;Bulk Action Async</li>
						<li><i class="fa fa-check-square-o"></i>&nbsp;Bulk Also Action</li>
                      <li><i class="fa fa-check-square-o"></i>&nbsp;Bulk Then Action</li>
					</ul>
					<h3>License</h3>
					<ul>
						<li><i class="fa fa-check-square-o"></i>&nbsp;Commercial License</li>
						<li><i class="fa fa-check-square-o"></i>&nbsp;Royalty-Free</li>
						<li><i class="fa fa-check-square-o"></i>&nbsp;Support & Upgrades (1 year)</li>
					</ul>
				</div>
			</div>
		</div>
	</div>
</div>

<div class="container section-faq wow slideInUp">
	<div markdown="1">
---
## FAQ

### Which alternative payment methods are accepted?
We accept `PayPal`, `Cheque` and `Wire Transfer`.

We **DO NOT** accept bitcoin and credit card.

Please contact us for more information.

Email: <a href="mailto:sales@zzzprojects.com">sales@zzzprojects.com</a>

### Do you accept reseller?
Yes, contact us if you are a reseller or seeking for a reseller.

Email: <a href="mailto:sales@zzzprojects.com">sales@zzzprojects.com</a>

### What `2-4` developer seats mean?
It means that you can use the license for up 4 developers in your team.

The `5-9` developer seats mean you can use the license with up 9 developers.

You only pay for developer seats. You can use our library with an unlimited amount of application, environment, server, and client machine.

### I need more than `19 seats`, what can I do?
Please contact us with the number of seats required. We offer some additional great discounts or enterprise license.

Email: <a href="mailto:sales@zzzprojects.com">sales@zzzprojects.com</a>

### Is the license perpetual?
The product comes with a one year of support & upgrade but the license is perpetual (indefinitely use). So you are not forced to renew every year or renew at all.

Renewing come with a lot of benefits such as a 25%/35%/50% discount on purchase price, discounted or free product, etc.

### Why this library is not free and open source?
`ZZZ Projects` mission is focused on adding value to the `.NET Community` and supporting a lot of `free and open source` libraries.

However, this mission cannot be successful without being able to pay our developers for the time they pass to support & develop features for free and paid libraries.

#### Free Librairies

- [Html Agility Pack](http://html-agility-pack.net/){:target="_blank"}
- [Entity Framework Plus](http://entityframework-plus.net/){:target="_blank"}
- [Entity Framework DynamicFilter](https://github.com/zzzprojects/EntityFramework.DynamicFilters){:target="_blank"}
- [RefactorThis.GraphDiff](https://github.com/zzzprojects/GraphDiff){:target="_blank"}
- [Extension Methods](https://github.com/zzzprojects/Z.ExtensionMethods){:target="_blank"}

#### Website

- [.NET Fiddle](https://dotnetfiddle.net/){:target="_blank"}
- [SQL Fiddle](http://sqlfiddle.com/){:target="_blank"}
- [NuGet Must Haves](http://nugetmusthaves.com/){:target="_blank"}
- [Dapper Tutorial](http://dapper-tutorial.net/){:target="_blank"}

By contributing on paid libraries, you are also helping in keeping other libraries and website FREE.

</div>
</div>

<style>
.purchasing-step {
	margin-top: 60px;
}
.purchasing-step h2 {
	padding-bottom: 5px;
	margin-bottom: 20px;
	margin-top: 40px;
	font-size: 2.5rem;
	border-bottom: 1px solid #ddd;
}
.purchasing-step .more-option {
	font-style: italic;
	margin-top: 40px;
	margin-bottom: 40px;
}






</style>

<script>
function purchase_validate() {
	if($("#agree_agreement").prop('checked')) {
		return true;
	}

	$("#error_validation").modal('show')
	return false;
}
function selectProduct() {
	if($("#provider_type").val() == "VXEBFHKXL56NE") {
		$("#seat1").html("Dapper Plus $799 (1 developer seat)");
		$("#seat2_4").html("Dapper Plus $999 (2-4 developer seats)");
		$("#seat5_9").html("Dapper Plus $1199 (5-9 developer seats)");
		$("#seat10_14").html("Dapper Plus $1399 (10-14 developer seats)");
		$("#seat15_19").html("Dapper Plus $1599 (15-19 developer seats)");
	}
	else {
		$("#seat1").html("Dapper Plus $599 (1 developer seat)");
		$("#seat2_4").html("Dapper Plus $799 (2-4 developer seats)");
		$("#seat5_9").html("Dapper Plus $999 (5-9 developer seats)");
		$("#seat10_14").html("Dapper Plus $1199 (10-14 developer seats)");
		$("#seat15_19").html("Dapper Plus $1399 (15-19 developer seats)");
	}
}

selectProduct();
</script>
