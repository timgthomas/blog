HTML5's "data" attributes are a great way to store metadata about a particular
element in your markup without invalidating your HTML. They're easy to use (just
add "data-myvalue" as an attribute on your markup) and tools like jQuery can
[access the data stored therein][1] easily. Take this example:

	<input id='Email' name='Email' type='text' data-icon='envelope' />

We can get to this data with a simple jQuery call:

	var icon = $('a#lnk-email').data('icon');

However, if you're using ASP.NET MVC's input helpers (as I am on my current
project), you may run into an issue adding attributes to your input elements.
As a reminder, the syntax for one overload of the `TextBoxFor()` method, for
example, looks like this:

	@Html.TextBoxFor(
		x => x.Email, // A lambda expression pointing to a property on the model
		new {  }) // An anonymous object representing any HTML attributes to apply

The anonymous object above is the source of our problem. Why? That's an actual
block of C# code, where hyphens aren't allowed inside variable names. So
dropping-in a "data" attribute, like this:

	@Html.TextBoxFor(x => x.Email, new { data-icon = "envelope" })
	//                                       ^ The problem.

...throws a syntax error. Fortunately, the MVC team has provided us with an easy
workaround: replace the hyphen with an underscore, and you're good to go!

	@Html.TextBoxFor(x => x.Email, new { data_icon = "envelope" })
	//                                       ^ The workaround.

This is both valid C# _and_ renders out to our desired markup:

	<input id='Email' name='Email' type='text' data-icon='envelope' />

HTML5's "data" attributes are an excellent solution for embedding data in your
markup, and, thanks to a convenient method overload, even ASP.NET MVC users
aren't left out due to variable naming rules.

[1]: http://api.jquery.com/data/#data-html5