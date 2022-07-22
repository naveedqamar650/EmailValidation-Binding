using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Behaviors.Binding
{
    public class EmailBinding : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += EmailEntryChanged;

            base.OnAttachedTo(entry);
        }

        private void EmailEntryChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;
            if (!string.IsNullOrEmpty(entry.Text))
            {
                string emailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                bool isMatched = Regex.IsMatch(entry.Text, emailRegex);
                if (isMatched)
                {
                    var stackLayout = (StackLayout)entry.Parent;
                    var label = (Label)stackLayout.Children[stackLayout.Children.Count - 1];
                    label.IsVisible = false;
                }
                else
                {
                    var stackLayout = (StackLayout)entry.Parent;
                    var label = (Label)stackLayout.Children[stackLayout.Children.Count - 1];
                    label.IsVisible = true;
                }
            }
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            base.OnDetachingFrom(entry);
        }
    }
}
