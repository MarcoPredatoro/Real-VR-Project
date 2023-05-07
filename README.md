# Marco Setup

### 1) Download Unity 

 Download Unity at https://unity.com/releases/editor/archive, look for Unity 2021.3.10. Please note that it is important to use the same Unity version across your project.)


### 2) Oculus Integration

Add Oculus Integration asset to your unity account
You will only need to do it once for your account.
1. Go to Asset Store online with the following link and login.
a. https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022
2. Add to my assets, Accept EULA, Open in Unity, Open.

#### 2.1) Import Oculus Integration
See https://developer.oculus.com/documentation/unity/unity-import/ for full documentation.
1. Window > Package Manager.
2. At the top: Packages: In Project > Change to: My Assets.
3. Find Oculus Integration > Download or Update > Import.
a. Latest version should be v.47 as of writing the document. 4. Import > Yes > Use OpenXR > Ok > Restart > Update > Restart.

#### 2.2) Configure Unity Settings
For Step 1-7: see https://developer.oculus.com/documentation/unity/unity-conf-settings/ for full documentation.
1. On the menu, go to File > Build Settings.
2. Under Platform, check Android is selected.
3. Select Development Build to test and debug the app. When you’re ready for the final build, clear the
selection as it may impact the app performance.
4. Press Player Settings...
a. In Company Name, type the name of your company. Unity uses this to locate the preferences file.
b. In Product Name, type the name of your app or product that you want it to appear on the menu bar when the app is running. Unity also uses this to locate the preferences file.
c. In Version, type the version number that identifies the iteration. For subsequent iterations, the number must be greater than the previous version number.
5. Then expand the Other Settings tab.
a. Under Rendering:
i. Check Color Space is Linear. It lets colors supplied to shaders within your scene brighten linearly as light intensities increase.
b. Under Identification:
i. In Minimum API Level, set the minimum Android version to Android 10 (API level 29)
for Oculus Quest and Oculus Quest 2. c. Under Configuration:
i. In the Scripting Backend list, select IL2CPP (Intermediate Language To C++) as it provides better support for apps across a wider range of platforms.
ii. Clear the ARMv7 checkbox and instead select the ARM64 checkbox. Only 64-bit apps are accepted on the Meta Store.
6. Go to Project Settings > Quality.
a. Click Medium.
b. In Anti Aliasing, select 4x. Unlike non-VR apps, VR apps must set the multisample anti- aliasing (MSAA) level appropriately high to compensate for stereo rendering, which reduces the effective horizontal resolution by 50%.
c. Select the Realtime Reflections Probes checkbox to update reflection probes during gameplay.
d. Select the Billboards Face Camera checkbox to force billboards to face the camera while rendering instead the camera plane.
8. Go to
a. Install XR Plugin Management.
b. Show Assets (Recommended) -> Clean Up (Recommended) -> Clean Up Package.
c. On the Android tab, select the Oculus checkbox to install the Oculus XR plugin.
d. See https://developer.oculus.com/documentation/unity/unity-xr-plugin/ for further details on
XR Plugin.

