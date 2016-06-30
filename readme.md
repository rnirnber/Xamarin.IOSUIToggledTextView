## **UIToggledTextView Class for Xamarin** ##
**************************************************

Synopsis:

Derived from UIKit.UITextView, flashes different pieces of text data items on a user-defined interval. For each data item in the list, it has its own font-size. Automatically centers text vertically, since it's assumed that the class will be used for flashy, demonstrative purposes.

Sample usage:
>>var toggled_txt_view = new UITextView();
>
>>toggled_txt_view.AddBoundItem("Foo", 18f);

>>toggled_txt_view.AddBoundItem("Bar", 22f);

>>toggled_txt_view.AddBoundItem("Car", 32f);

>>// every 2 secs
>toggled_txt_view.StartToggling(2.0);
