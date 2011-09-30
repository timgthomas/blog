NOTE: This post's code was written for Windows Phone 7 and may or may not work
with other versions of Silverlight or WPF.

One of the screens in the Windows Phone 7 app I'm currently working on (we'll
call it `CombatForm`) contains some combat tools for two separate players,
implemented as a parent page with two child controls.  These controls–each one
an instance of the `CombatActions` control–need to change their state based on
a property of the parent screen (which is in turn manipulated by user input
elsewhere in the app).  After mulling over several options (including using the
application's event bus and a more synchronous approach of manually modifying
the controls' properties), I decided to use Silverlight's built-in data binding
features to implement this, meaning I needed to create a
[`DependencyProperty`][1].

Creating the `DependencyProperty` on the `CombatActions` control was pretty
straightforward.  Essentially, we're creating some metadata about the property
on the `UserControl` we want, then using some of the Silverlight API's calls to
expose the property:

	public partial class CombatActions : UserControl
	{
		// ...
	
		public static readonly DependencyProperty CanCastSpellsProperty =
			DependencyProperty.Register("CanCastSpells", typeof(bool),
			typeof(CombatActions), null);

		public bool CanCastSpells
		{
			get { return (bool)GetValue(CanCastSpellsProperty); }
			set { SetValue(CanCastSpellsProperty, value); }
		}
		
		// ...
	}

Ideally, I'd like to bind the parent property to the UserControl in XAML, which
_would_ have looked like this:

	<c:CombatActions x:Name="Actions" CanCastSpells="{Binding CanCastSpells}" />

Unfortunately, I spent more time than I'd care to admit trying to figure out
why that wasn't working.  Having given up any hope of a utopian XAML solution,
I attempted the binding in the parent control's code-behind:

	public class CombatForm : PhoneApplicationPage
	{
		public bool CanCastSpells { get; set; }
	
		public CombatForm()
		{
			// ...
			
			// In this example, we're binding the UserControl to a property on this
			// instance of CombatForm, so the DataContext is "this".
			DataContext = this;
			
			Actions.SetBinding(CombatActions.CanCastSpellsProperty, new Binding
				{
					Source = DataContext,
					Path = new PropertyPath("CanCastSpells"),
					Mode = BindingMode.TwoWay
				});
			
			// ...
		}
	}

Success!  The `CanCastSpells` property on the `CombatActions` controls can now
be successfully bound to the `CombatForm`'s property of the same name!  The key
was to create the binding programmatically (in the code-behind) rather than
declaratively (in the XAML).

[1]: http://msdn.microsoft.com/en-us/library/system.windows.dependencyproperty.aspx