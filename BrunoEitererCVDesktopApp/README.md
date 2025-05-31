# BrunoeitererCVDesktopApp
This is a desktop app made with C# and WinUi 3, cotaining my CV/portfolio.

## BrunoEitererCV
This folder contains the main application code.

## Executor
This folder contains a support application, whose only functionality is to execute the main application.
I've added this because the single-file publish support for WinUi 3 is poor, and I didn't want to distribute the application in a folder together with several DLLs.
To achieve a satisfactory result, I'm publishing the main application in a Dependencies folder, and the Executor is placed in the main folder, making the experience a lot cleaner for the users.
