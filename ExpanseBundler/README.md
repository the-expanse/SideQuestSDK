# Expanse Bundler

#### What is this for? 
 - The Expanse is a social VR platform that allows you to create custom content and game logic. 
 This editor plugin is intended to simplify the process of loading new content into The Expanse 
 by prepping and creating asset bundles for both desktop and android in one simple step. This 
 plugin will process your assets and scripts from a selected input folder and add them into the
 asset bundles before exporting. 
 
#### How do I use this plugin?
 - To access this plugin you need to click the `Tools` menu and then click `Expanse Bundler`.
 ![Menu Location](https://i.imgur.com/eYomakv.png)
 - The plugin provides 4 input options.
   - Input Directory: This is where you have all your input files - everything you want to put 
     into the bundles. Files include prefabs, audio, video, text and script files.
   - Output Directory: This is where your generated asset bundles will appear. You will have 
     two asset bundles created, one for android and one for desktop. The android bundle will 
     automatically append `_android` to the filename. 
   - Name: This is the name of the output asset bundle. `_android` will be appended to this 
     value for the android version of the asset bundle.
   - Remove Manifests: This option will automatically remove the extra manifest files and leave 
     you with just the two asset bundle files for desktop and android.
 ![Input Options](https://i.imgur.com/WyYAPOP.png)
 
#### What do you put into a bundle and how do I get them in? Is it just for scripts?
 You can place assets into the `Input` folder directly, not in sub folders. This includes things like prefabs, materials, shaders, images / audio / video clips and scripts. These will all be available for you to use at runtime in game or access from within your scripts. 
 
#### Does this bundle up the whole scene?
 You need to place your assets into the Input folder to be able to bundle them. Once you ahve them in place click build and it will take all assets in teh `Input` folder and place them inside the `Output` folder in the form of asset bundles. It will make one for android and one for windows. It will overwrite the existing items in the output folder if they have the same name. 
 
#### How do I know if it built OK?
 Once the asset bundles have been built, it will highlight them in the project window. If there are no errors on the console then every thing should be good to go. 
 
#### I have bundles I created with AltspaceVR, are these compatible?
 Yes you can load in bundles created with the altspace unity plugin without modification, you can extract the zip file created and use the desktop and android bundles included. Remember to rename the android bundle to `<NAME>_android` and place it in the same folder as the desktop bundle.
 
#### I have a 3D model, do i need to use this?
 You can load 3D models directly in game without needing to use unity to do so. We support GLTF and OBJ. You can import them using the same process as importing asset bundles, just select `GLTF` / `OBJ` instead of `Unity Asset Bundle`.
 
#### How do I use the asset bundles I export?
 - Once you have created your bundle files you will need to upload them to some publically accessible url so you can then load them into The Expanse. You can use github or similar or use your own server for hosting the files. 
![Demo](https://raw.githubusercontent.com/the-expanse/ExpanseAsset/master/demo.gif)
     
#### Where can I upload the bundles? Can I upload them to The Expanse servers?
 We do have a files CDN that we intended to allow users to upload content to. We currently use this for storing selfie photos taken in game and for other media asssets related to spaces and events. We are considering our options but with new EU regulations around upload filters coming into effect we want to avoid legal problems with copyrighted content - these are supposed to go into effect in early June 2019 so we are waiting until then to see how some other bigger sites handle these problems. 
     
#### Where can I get support for this plugin?
 - To ask questions or raise concerns you can use github issues or engage directly with us on our 
 [discord](https://discord.gg/xJ3M63W) or via our [website](https://theexpanse.app/support/).
 
 
  
 
