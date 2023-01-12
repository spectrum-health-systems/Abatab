<div align="center">

  <img src="../images/Logo/AbatabManualLogo.png" alt="Abatab Manual" width="512">
  <br>
  <br>
  <h1>
    Version 23.0
  </h1>

</div>

# Importing Abatab into your environment

In order for myAvatar™ to use Abatab, you'll need to import Abatab into your myAvatar™ environments. Here is how you do it.

# Confirming the Abatab WSDL

Before attempting to import Abatab into myAvatar™, you should make sure that you have a valid **W**eb **S**ervice **D**escription **L**anguage (**WSDL**) URL. To do this, paste the URL of the Abatab WSDL in a web browser and attempt to access the URL.

For example, pointing a browser to `https://your-organization.com/MyAvatoolWebService.asmx?WSDL` should display XML that looks something like this:

<h6 align="center">

  <img src="../images/importing-abatab/wsdl-xml-example-799x393.png" width="600">
  <br>
  An example of a WSDL file
  <br>

</h6>

If the WSDL file *is diplayed* in the browser, that URL is what you are going to need going forward.

If the WSDL file *is not displayed*, you'll need to get a valid WSDL location before continuing.

# Importing the Abatab WSDL

Any form can be used to import a web service, and once a web service has been imported it can be used by any form that allows ScriptLink events.

We will use the *Admissions* form to import the Abatab WSDL:

1. Open the **Form Designer** form
2. Choose the "Admissions" form from the **Forms** dropdown
3. Choose the XXX tab from the **Tabs** dropdown
4. Click the **Show Tab** button
5. You will now see the form tab in designer mode. In the upper left of myAvatar™ you will see a **Settings** button:

<h6 align="center">

  <img src="../../images/Importing/scriptlink-form-designer-settings-button-364x335.png" width="300">
  <br>
  The "Settings" button.
  <br>
</h6>

6. Clicking the **Settings** button will bring you to the ScriptLink options page. Right now we are interested in the **Import WSDL for ScriptLink** section:

<h6 align="center">

  <img src="../../images/Importing/scriptlink-options-import-wsdl-847x375.png" width="747">
  <br>
  The ScriptLink options page.
  <br>
</h6>
<br>

7. Copy/paste the Abatab WSDL URL into the **Import WSDL for ScriptLink** field in myAvatar™
2. Click the **Import** button.

You should get a popup letting you know the WSDL was imported successfully.

<!-- Reference Links -->

[AbatabUrl]: https://github.com/spectrum-health-systems/Abatab
[AvatarUrl]: https://www.ntst.com/Offerings/myAvatar

[man-GettingStarted-Home]: ./man-GettingStarted-Home.md
[man-Hosting-Home]: ./man-Hosting-Home.md
[man-Importing-Home]: ./man-Importing-Home.md
[man-Configuration-Home]: ./man-Configuration-Home.md
[man-Using-Home]: ./man-Using-Home.md
[man-ScriptLink-Home]: ./man-ScriptLink-Home.md
[man-AdditionalInformation-Home]: ./man-AdditionalInformation-Home.md


[AbatabUrl]: https://github.com/spectrum-health-systems/Abatab
[AvatarUrl]: https://www.ntst.com/Offerings/myAvatar
[man-getting-started]: ./man-getting-started-home.md
[man-hosting]: ./man-hosting-home.md
[man-importing]: ./man-importing-home.md
[man-configuration]: ./man-configuration-home.md
[man-using]: ./man-using-home.md
[man-additional-information]: ./man-additional-information-home.md
[a-pretty-cool-program-url]: https://github.com/APrettyCoolProgram
