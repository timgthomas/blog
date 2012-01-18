In April 2011, the jQuery team [announced][1] development on the popular jQuery
Templates plugin would be delayed indefinitely. In need of a replacement, I
began investigating alternatives and soon discovered [Underscore][2], the
"utility belt" library behind the awesome [Backbone.js][3] framework.

The Underscore library includes an easy-to-use templating feature that easily
integrates with any JSON data source. Sending JSON data to a browser is outside
the scope of this blog post, but, for reference, take a look at this collection
of books:

	[
	  {
	    "title":"Myst: The Book of Atrus",
	    "author":"Rand Miller"
	  },
	  {
	    "title":"The Hobbit",
	    "author":"J.R.R. Tolkien"
	  },
	  {
	    "title":"Stardust",
	    "author":"Neil Gaiman"
	  }
	]

In this example, we'll display this collection of books as a simple unordered
list, but don't let that stop you from experimenting!

The Data
========

To start, reference both the Underscore and jQuery libraries (the latter so we
have access to jQuery's DOM manipulation and asynchronous HTTP request
features). Then, get your JSON data in whatever manner best fits your
application (we'll use jQuery's `ajax()` method):

	$.ajax({
	  type: 'get',
	  url: 'path/to/your/json'
	}).done(function (data) {
	  // "data" is our JSON object; we'll be working in here.
	});

The Template
============

Now we need to define our Underscore template, which we'll do in a `<script>`
block (meaning browsers will ignore it while rendering the page, but we can
still reference it by its client ID) with the type of `text/template` (so your
fellow developers will know it's a template versus a standard bit of
JavaScript).

	<script id='tmpl-books' type='text/template'>
	  <ul>
	    <% for (var i = 0; i < books.length; i++) { %>
	      <% var book = books[i]; %>
	      <li>
	        <em><%= book.title %></em> by <%= book.author %>
	      </li>
	    <% } %>
	  </ul>
	</script>

If you've worked with tools like ASP.NET "WebForms" or Rails, you may recognize
the "bee sting" operators (`<%` and `%>`), which Underscore uses to both output
data to the rendered template and encapsulate behavior (using JavaScript). In
this template, we first loop through the "books" collection (which we'll define
in the next section), pluck out each book as the loop progresses, and print out
the title and author of each as an unordered list item.

[1]: http://api.jquery.com/category/plugins/templates/
[2]: http://documentcloud.github.com/underscore/
[3]: **Backbone.js**