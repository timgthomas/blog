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
	  // We'll use Underscore to compile our template
	  // here using "data", our JSON collection.
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
data to the rendered template and encapsulate behavior (as JavaScript). In this
template, we first loop through the "books" collection (which we'll define in
the next section), pluck out each book as the loop progresses, and print out the
title and author of each as an unordered list item.

You're free to inject as much JavaScript as you wish into your templates, but I
find they're most maintainable when the script is kept to a minimum (for me,
this means mostly just loops and ternary operators), like so:

	<% book.published ? print('(' + book.published + ')') : '' %>

(The `print()` function is a handy alternative to the `<%= %>` syntax for
outputting values inside other functions, like we're doing here.)

The Result
==========

Now that we've defined our JSON source and the template for displaying our data,
we need simply to tell Underscore to render the template and give us back the
output HTML (using Underscore's `template()` function).

Remember that we're inside jQuery's `ajax()` method in this example, and `data`
represents our JSON collection of books. We'll tell Underscore to put this data
inside the `books` collection, which we've referenced in our template.

	// Get the template's markup...
	var tmplMarkup = $('#tmpl-books').html();
	// ...tell Underscore to render the template...
	var compiledTmpl = _.template(tmplMarkup, { books : data });
	// ...and update part of your page:
	$('#target').html(compiledTmpl);

Underscore kindly compiles the template with our well-formed data and produces
the following output, ready for injection into our HTML page:

	<ul>
	  <li><em>Myst: The Book of Atrus</em> by Rand Miller</li>
	  <li><em>The Hobbit</em> by J.R.R. Tolkien</li>
	  <li><em>Stardust</em> by Neil Gaiman</li>
	</ul>

[1]: http://api.jquery.com/category/plugins/templates/
[2]: http://documentcloud.github.com/underscore/
[3]: **Backbone.js**