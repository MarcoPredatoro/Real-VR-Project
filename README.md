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
5. Then expand the Other Settings tab.
a. Under Rendering:
i. Check Color Space is Linear.
b. Under Identification:
i. In Minimum API Level, check the minimum Android version is set to Android 10 (API level 29)
for Oculus Quest and Oculus Quest 2. 
c. Under Configuration:
i. In the Scripting Backend list, check IL2CPP (Intermediate Language To C++) is selected.
ii. Clear the ARMv7 checkbox and instead select the ARM64 checkbox. 
6. Go to Project Settings > Quality.
a. Click Medium.
b. In Anti Aliasing, check 4x is selected.
c. Check if the Realtime Reflections Probes checkbox is selected
d. Check if the Billboards Face Camera checkbox is selected 
7. Go to
a. Install XR Plugin Management.
b. Show Assets (Recommended) -> Clean Up (Recommended) -> Clean Up Package.
c. On the Android tab, select the Oculus checkbox to install the Oculus XR plugin.
d. See https://developer.oculus.com/documentation/unity/unity-xr-plugin/ for further details on
XR Plugin.

### 3) Install other required Packages 

#### 3.1) PUN2 - installation 
visit this link and download the [PUN 2 - Free](https://assetstore.unity.com/packages/tools/network/pun-2-free-119922) package.

#### 3.2) Blood Splatter Package Installation 
visit this link and download the blood splatter (https://assetstore.unity.com/packages/2d/textures-materials/blood-splatter-decal-package-7518).

#### 3.2) XR interaction toolkit
1. Window > Package Manager.
2. At the top: Packages: In Project > Change to: Unity Registry.
3. Find XR Interaction Toolkit > Download or Update > Import.

### 4) Play 

1. To beign playing, wear the headset and allow debbuing and access to the device.
2. With the headset on click the App Library
3. Navigate to the drop down menu on the top right and click Unkown Sources
4. You should see the application tha you just built
5. Run the app and play the game !









    


