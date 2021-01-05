@ECHO OFF
bitsadmin.exe /transfer "AES" "https://lucas7yoshi.github.io/aes.html" "%cd%\AES.txt" >nul
set /p aes=<AES.txt
