# mbot-control

## Motivation
The [mBot](https://www.makeblock.com/mbot) from the company Makeblock is an entry level educational robot kit. The mBot can be programmed to perform autonomous tasks such as line following or collission detection.
However it is not possible to control the mBot non-autonomously, e.g via bluetooth or WiFi. Therefore I created this program to enable controlling the mBot remotely via a bluetooth connection.

## Installation
First, download or clone this repo.
Download and install mBlock version 3 from [here](https://mblock.makeblock.com/en-us/download/). The newest version of mBlock (version 5) cannot be used since the serial block is not available anymore. After installation, connect your mBot via USB cable to your PC and select your mBot via Connect -> Serial Port -> mBot. Click on File -> Load Project and open the file **bluetest_arduino.sb2**. Then click on **Upload to Arduino** to flash your mBot with this program.
Turn on your mBot. If everything worked correctly, your mBot should blink red and green alternately.

## Run it
Make sure that your mBot is visible in Windows.
Navigate to the bin/Release folder and execute mBotController.exe. 
The following window should pop up:


![image](https://user-images.githubusercontent.com/3988444/111902109-01ee5700-8a3c-11eb-97f1-09ba642b1f32.png)

Click on Update. You should get a list of available bluetooth devices in the dropdown, including your mBot. Select your mBot.
If the connection was successful, the label should change to **connected**. Furthermore, the blue blinking LED on your mBot should stop blinking.
Click on any of the **Forward**, **Backward**, **Left** and **Right** buttons. The mBot should start moving.
If not, select another characteristic from the second dropdown and click again on any of the 4 buttons.


Note that this program was written in C# and runs under Windows.

References:
- https://andreas-huppert.de/blogs/2018-03-09_mbot-bluetooth/ Andreas brought me on the right track with his bluetooth code. 
- https://sensboston.github.io/BLEConsole/ Helped me to understand how bluetooth works in general and how it can be used in C#.



