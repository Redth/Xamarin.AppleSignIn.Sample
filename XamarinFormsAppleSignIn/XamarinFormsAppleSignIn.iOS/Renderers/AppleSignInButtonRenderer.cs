using System;
using AuthenticationServices;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(XamarinFormsAppleSignIn.AppleSignInButton), typeof(XamarinFormsAppleSignIn.iOS.Renderers.AppleSignInButtonRenderer))]

namespace XamarinFormsAppleSignIn.iOS.Renderers
{
    public class AppleSignInButtonRenderer : ViewRenderer<AppleSignInButton, ASAuthorizationAppleIdButton>
    {
        public static ASAuthorizationAppleIdButtonStyle ButtonStyle { get; set; } = ASAuthorizationAppleIdButtonStyle.Black;
        public static ASAuthorizationAppleIdButtonType ButtonType { get; set; } = ASAuthorizationAppleIdButtonType.Default;

        ASAuthorizationAppleIdButton button;

        protected override void OnElementChanged(ElementChangedEventArgs<AppleSignInButton> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Cleanup
                if (button != null)
                    button.TouchUpInside -= Button_TouchUpInside;
            }

            if (e.NewElement != null)
            {
                // Create
                if (button == null)
                {
                    button = CreateNativeControl();
                    button.TouchUpInside += Button_TouchUpInside;

                    SetNativeControl(button);
                }
            }
        }

        protected override ASAuthorizationAppleIdButton CreateNativeControl()
            => new ASAuthorizationAppleIdButton(ButtonType, ButtonStyle);

        void Button_TouchUpInside(object sender, EventArgs e)
            => Element.InvokeSignInEvent(sender, e);
    }
}
