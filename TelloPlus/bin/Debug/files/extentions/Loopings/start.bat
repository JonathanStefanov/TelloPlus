[center]Hello There![/center]
In this topic I will explain how to create and submit a TelloPlus extension

[center]First: Code your app![/center]

You have to code an app that will do whatever you want the drone to do. This app can be written in every language that Windows supports (Sadly, TelloPlus doesn't support other os's :cry: , yet :D )
For this example I created an app that makes the DJI Sparl Tello take off and land.
[img]https://i.imgur.com/AgrmWT7.png[/img]

[center]Second: Create a start.bat script[/center]

You then have to create a batch script named "start.bat" in your app folder. This script will serve to run your program. In it, write this code:
[code]cd files/extensions/your_extension_name && your_app
pause[/code]
For this example, I created a python script so the code will be like this:
[img]https://i.imgur.com/VM1e7MG.png[/img]

[center]Third: Zip it![/center]

Now you have to zip it all! (Your app and the start.bat script). The name of the zip file doesn't matter.

[center]Fourth: Submit it![/center]

The last thing that you have to do is to Submit your extension by creating a thread in this section. In the thread, explain what the extension does and describe it.  Don't forget to link your zip file!
Every submission will be approved unless it doesn't work.

If you have any questions, feel free to contact me with a private message on this forum.
I hope that you will submit a lot of extensions! :D