# WifiQrCodeGenerator

This program is a simple QR Code Generator for Wifi connections. It outputs valid QR Codes for any open, WEP, WPA1, and WPA2 Wireless access point.
When this QR Code is scanned using an iOS or Android device's camera the user will be presented with an option to connect to the WiFi with the given
connection information contained within the QR Code.

# Reason for creation

There are already a lot of websites that you can go to to create QR Codes, the only problem is that you do not know what type of information is being
tracked about you and whether or not the information you enter into the website is simply being used to generate the QR Code or if it is also being stored
in some type of database. My hope for this program is to show that it is not necessary to have to sell your privacy for something as simple as generating a
QR Code, but additionally I wanted to have an open source project to show developers how simple it can be to create a QR Code program (as long as you have a good
library that you can depend on).

# Installing

I have releases for each specific operating system type. I have only generated 64 bit versions for both macOS and for linux distributions, but for Windows, both a 64bit and a 32bit version
of the program are available. Simply choose the zip file that matches your Operating System and download it. After you unzip the file and you can run the program in the unzipped archive directory.
The Current directory that you run the program in isn't picky, so if you add the unzipped folder into your `$PATH` variable then you should be able to run it in any terminal of your choosing
(Windows Terminal, Command Prompt, PowerShell, Bash, Zsh, etc.).

# Using

The below examples are valid run parameters for the program:

```bash
./WifiQrCodeGenerator
# Shows contextual help
```

```bash
./WifiQrCodeGenerator --version
# Shows the version information
```

```bash
./WifiQrCodeGenerator -h
# Shows contextual help
```

```bash
./WifiQrCodeGenerator -o "My QR Code.png" -s "My-SSID-Name" -p "My SSID Pre Shared Key" -a WPA
# Generates a QRCode that uses WPA Authentication to connect to the wifi access point named "My-SSID-Name"
# The PreShared Key (password) for the wifi is "My SSID Pre Shared Key". This is the password or PreShared Key that
# you would normally use to connect to the wifi access point.
```

## Before using on Linux

There is a dependency on libgdiplus for linux. Before running this program make sure that libgdiplus is installed.
On Ubuntu I was able to install libgdiplus by running apt:

```bash
sudo apt-get install libgdiplus
```

