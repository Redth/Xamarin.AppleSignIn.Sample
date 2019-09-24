using System;
namespace XamarinFormsAppleSignIn
{
    public class AppleSignInButton : Xamarin.Forms.Button
    {
        public AppleSignInButton()
        {
            Clicked += AppleSignInButton_Clicked;
        }

        private void AppleSignInButton_Clicked(object sender, EventArgs e)
            => SignIn?.Invoke(sender, e);

        public event EventHandler SignIn;

        public void InvokeSignInEvent(object sender, EventArgs e)
            => SignIn?.Invoke(sender, e);

        public void Dispose()
        {
            Clicked -= AppleSignInButton_Clicked;
        }
    }
}
