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
 
#### How do I use the asset bundles I export?
 - Once you have created your bundle files you will need to upload them to some publically accessible url so you can then load them into The Expanse. You can use github or similar or use your own server for hosting the files. 
![Demo](https://raw.githubusercontent.com/the-expanse/ExpanseAsset/master/demo.gif)
     
#### Where can I get support for this plugin?
 - To ask questions or raise concerns you can use github issues or engage directly with us on our 
 [discord](https://discord.gg/xJ3M63W) or via our [website](https://theexpanse.app/support/).
 
 
  
 
