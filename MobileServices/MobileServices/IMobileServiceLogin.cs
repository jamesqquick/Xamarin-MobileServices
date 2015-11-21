using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileServices
{
   public interface IMobileServiceLogin
    {
		void loginAsync(MobileServiceAuthenticationProvider provider);
    }
}
