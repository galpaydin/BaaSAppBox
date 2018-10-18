# BAASBox.SampleApp

This is a sample app, demonstrating how to use BAASBox.CRUD.UI and BAASBox.Access to quickly build an app that can access a BAASBox instance and sign in to it.

For more information about either library, please see their respective Github repositories:
* https://github.com/instantiator/BAASBox.CRUD.UI
* https://github.com/instantiator/BAASBox.Access

## What it does

This app is ready to sign in to a BAASBox instance. It comes with a simple (empty!) user preferences class (`PersonalPreferences`). You can sign in (by authenticating against BAASBox), and sign out again.

The BAASBox.CRUD.UI library provides support for various different Page types:

* `AbstractNavigationPage` - a page responsible for managing the app's stack of pages - and also for removing the 'personal' (signed in) pages, when the `AuthState` reports that the user is no longer signed in.
* `AbstractSignInPage` - a page that allows the user to sign in to the configured instance of BAASBox.
* `AbstractPersonalContentPage` - a page that will update if the user's preferences change.
* `AbstractCrudPage` - a page that can display/edit/update/delete an object from a BAASBox collection.

# How to get this sample up and running

Once loaded into Xamarin Studio (untested in Visual Studio!), this sample will compile and run on Android. You will see the initial sign in screen, but you won't be able to sign in to anything - as it is configured to access https://baasbox.example.com on port 443.

You can edit these settings in `SampleAppConfig`. Point the app at an instance of BAASBox that you have running. Best practise is to access it over https. Setting up your BAASBox server (or a proxy) for https is beyond the scope of this document, but essential to keep your users safe when accessing it over the internet.

## What you'll see

<img src="https://raw.githubusercontent.com/instantiator/BAASBox.SampleApp/master/screenshots/001-sign-in.png" width="250px" />
<img src="https://raw.githubusercontent.com/instantiator/BAASBox.SampleApp/master/screenshots/002-signed-in-notification.png" width="250px" />
<img src="https://raw.githubusercontent.com/instantiator/BAASBox.SampleApp/master/screenshots/003-signed-in-page.png" width="250px" />
